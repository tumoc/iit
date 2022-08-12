using ProjectLibrary.Config;
using ProjectLibrary.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web.Mvc;
using TeamplateHotel.Handler;
using TeamplateHotel.Models;

namespace TeamplateHotel.Controllers
{
    public class BookingTourController : Controller
    {
        // GET: /BookingTour/
        [HttpGet]
        public ActionResult BookTour()
        {
            using (var db = new MyDbDataContext())
            {
                var bookTour = new BookTour();
                Tour tour = db.Tours.FirstOrDefault();
                if (tour == null)
                {
                    var hotel = CommentController.DetailHotel(Request.Cookies["LanguageID"].Value);
                    ViewBag.Messages = "Error! Can not find the selected tous. For more information, please contact us by email: <a href='mailto:" + hotel.Email + "'>" + hotel.Email + "</a> or phone number: < href='tel:" + hotel.Tel + "'>" + hotel.Tel + "</a>";
                    return View("Messages");
                }


                ViewBag.type = null;
                var optionTour = new List<SelectListItem>();
                List<ShowObject> tours = db.Tours.Where(a => a.Status)
                    .Join(db.Menus.Where(a => a.LanguageID == Request.Cookies["LanguageID"].Value), a => a.MenuID, b => b.ID,
                    (a, b) => new ShowObject()
                    {
                        Title = a.Title
                    }).ToList();
                foreach (var item in tours)
                {
                    optionTour.Add(new SelectListItem
                    {
                        Text = item.Title,
                        Value = item.Title
                    });
                }
                ViewBag.optionTour = optionTour;
                bookTour.ID = tour.ID;
                //bookTour.Price = tour.Price;
                bookTour.InfoBooking = tour.Title;

                return View("BookTour", bookTour);
            }
        }

        [HttpPost]
        public ActionResult SendBooking(BookTour model)
        {
            string status = "success";
            try
            {
                using (var db = new MyDbDataContext())
                {
                    Tour tour = db.Tours.FirstOrDefault(a => a.ID == model.ID);
                    Hotel hotel = CommentController.DetailHotel(Request.Cookies["LanguageID"].Value);
                    if (tour == null)
                    {
                        ViewBag.Messages = "Error! Can not find the selected tous. For more information, please contact us by email: <a href='mailto:" + hotel.Email + "'>" + hotel.Email + "</a> or phone number: <a href='tel:" + hotel.Tel + "'>" + hotel.Tel + "</a>";
                        return View("Messages");
                    }

                    //xác định xem tour có phải là option không
                    string inforBooking = "";

                    inforBooking = tour.Title;


                    string codeBooking = hotel.CodeBooking + "1";
                    if (db.BookTours.Any())
                    {
                        codeBooking = hotel.CodeBooking + "" +
                                      (db.BookTours.OrderByDescending(a => a.ID).FirstOrDefault().ID + 1);
                    }
                    // inforBooking += ", ";
                    BookTour bookTour = new BookTour();
                    bookTour.ID = model.ID;
                    bookTour.Code = codeBooking;
                    bookTour.ID = tour.ID;
                    bookTour.Departure = model.Departure;
                    bookTour.CreateDate = DateTime.Now;
                    bookTour.Gender = model.Gender;
                    bookTour.FullName = model.FullName;
                    bookTour.Tel = model.Tel;
                    bookTour.Country = model.Country;
                    bookTour.Address = model.Address;
                    bookTour.Email = model.Email;
                    bookTour.Request = model.Request;

                    bookTour.InfoBooking = inforBooking;
                    //bookTour.Price = (float)tour.Price;
                    //float price = (float)bookTour.Price;

                    db.BookTours.InsertOnSubmit(bookTour);
                    db.SubmitChanges();

                    SendEmail sendEmail =
                   db.SendEmails.FirstOrDefault(a => a.Type == TypeSendEmail.BookTour && a.LanguageID == Request.Cookies["LanguageID"].Value);

                    sendEmail.Title = sendEmail.Title.Replace("{TourName}", tour.Title);
                    string content = sendEmail.Content;
                    content = content.Replace("{HotelName}", hotel.Name);
                    content = content.Replace("{Code}", bookTour.Code);
                    content = content.Replace("{Departure}", bookTour.Departure.ToString());
                    content = content.Replace("{InfoBooking}", bookTour.InfoBooking);
                    //content = content.Replace("{TotalPrice}", bookTour.Price.ToString());
                    content = content.Replace("{Gender}", model.Gender);
                    content = content.Replace("{FullName}", model.FullName);
                    content = content.Replace("{Tel}", model.Tel);
                    content = content.Replace("{Country}", model.Country);
                    content = content.Replace("{Email}", model.Email);
                    content = content.Replace("{Request}", model.Request);


                    //content = content.Replace("{TotalPrice}", price.ToString());
                    //price = price * (float)0.3;
                    //content = content.Replace("{paid}", price.ToString());
                    //infor Hotel
                    content = content.Replace("{Add}", hotel.Address);
                    content = content.Replace("{Hotline}", hotel.Hotline);
                    content = content.Replace("{EmailHotel}", hotel.Email);
                    content = content.Replace("{Website}", hotel.Website);
                    content = content.Replace("{Deposit}", " 30 %");

                    MailHelper.SendMail(model.Email, sendEmail.Title, content);
                    MailHelper.SendMail(hotel.Email, tour.Title + " (" + bookTour.Code + ")- Booking tour of " + model.FullName, content);

                    //if (QuocTe == 2)
                    //{
                    //    return RedirectToAction("SubmitInvoidOnePay",
                    //        new
                    //        {
                    //            //vpc_Customer_Id = bookTour.ID,
                    //            //vpc_Customer_Phone = bookTour.Tel,
                    //            //vpc_Customer_Email = bookTour.Email,
                    //            idOrder = bookTour.Code,
                    //            email = model.Email,
                    //            deposit = (Math.Round(price, 2)) * 100
                    //        });
                    //}


                }
            }
            catch (Exception ex)
            {
                status = "error";
                Trace.WriteLine(ex.Message);
            }

            return Redirect("/BookTour/Messages?status=" + status);
        }
        [HttpGet]
        public ActionResult Messages()
        {
            using (var db = new MyDbDataContext())
            {
                SendEmail sendEmail =
                       db.SendEmails.FirstOrDefault(
                           a => a.Type == TypeSendEmail.BookTour && a.LanguageID == Request.Cookies["LanguageID"].Value);

                string status = Request.Params["status"];
                ViewBag.Messages = "";
                if (string.IsNullOrEmpty(status) == false)
                {
                    if (status.Equals("success"))
                    {
                        ViewBag.Messages = sendEmail.Success;
                    }
                    else
                    {
                        ViewBag.Messages = sendEmail.Error;
                    }
                }
                else
                {
                    ViewBag.Messages = sendEmail.Error;
                }
                return View();
            }
        }

        //public ActionResult SubmitInvoidOnePay(string idOrder, double deposit, string email /*,string vpc_Customer_Id ,string vpc_Customer_Phone ,string vpc_Customer_Email*/)
        //{
        //    PaymentConfigOnePay pay = new PaymentConfigOnePay();
        //    using (var db = new MyDbDataContext())
        //    {
        //        pay = db.PaymentConfigOnePays.FirstOrDefault();
        //    }
        //    if (pay != null)
        //    {
        //        string ip = GetLocalIPAddress();

        //        VPCRequest conn = new VPCRequest("https://mtf.onepay.vn/vpcpay/vpcpay.op");

        //        conn.SetSecureSecret(pay.Hashcode);
        //        conn.AddDigitalOrderField("AgainLink", "http://onepay.vn");
        //        conn.AddDigitalOrderField("Title", "onepay paygate");
        //        conn.AddDigitalOrderField("vpc_Locale", "en");
        //        //conn.AddDigitalOrderField("vpc_CurrencyCode ", "");
        //        conn.AddDigitalOrderField("vpc_Version", "2");
        //        conn.AddDigitalOrderField("vpc_Command", "pay");
        //        conn.AddDigitalOrderField("vpc_Merchant", pay.MerchantId);
        //        conn.AddDigitalOrderField("vpc_AccessCode", pay.AccessCode);
        //        conn.AddDigitalOrderField("vpc_MerchTxnRef", idOrder);
        //        conn.AddDigitalOrderField("vpc_OrderInfo", idOrder);
        //        conn.AddDigitalOrderField("vpc_Amount", deposit.ToString());
        //        conn.AddDigitalOrderField("vpc_ReturnURL", pay.WebSite + "/BookTour/MessageOnePay?email=" + email);
        //        conn.AddDigitalOrderField("vpc_TicketNo", ip);
        //        //conn.AddDigitalOrderField("vpc_Customer_Id", vpc_Customer_Id);
        //        //conn.AddDigitalOrderField("vpc_Customer_Phone", vpc_Customer_Phone);
        //        //conn.AddDigitalOrderField("vpc_Customer_Email", vpc_Customer_Email);


        //        String url = conn.Create3PartyQueryString();
        //        return Redirect(url);
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        //[HttpGet]
        //public ActionResult MessageOnePay(string email, string vpc_OrderInfo, string vpc_TxnResponseCode, string vpc_SecureHash , float vpc_Amount)
        //{
        //    PaymentConfigOnePay paymentConfig = new PaymentConfigOnePay();
        //    Hotel hotel = CommentController.DetailHotel(Request.Cookies["LanguageID"].Value);
        //    var db = new MyDbDataContext();
        //    paymentConfig = db.PaymentConfigOnePays.FirstOrDefault();

        //    int state = 0;
        //    string message = "";
        //    var conn = new VPCRequest("https://mtf.onepay.vn/vpcpay/vpcpay.op");
        //    conn.SetSecureSecret(paymentConfig.Hashcode);
        //    // Xu ly tham so tra ve va kiem tra chuoi du lieu ma hoa
        //    string hashvalidateResult = conn.Process3PartyResponse(Request.QueryString);
        //    // Lay gia tri tham so tra ve tu cong thanh toan
        //    var merchTxnRef = conn.GetResultField("vpc_MerchTxnRef", "Unknown");
        //    if (hashvalidateResult == "CORRECTED" && vpc_TxnResponseCode.Trim() == "0")
        //    {
        //        message = "Transaction was paid successful";
        //        state = 1;
        //    }
        //    else if (hashvalidateResult == "INVALIDATED" && vpc_TxnResponseCode.Trim() == "0")
        //    {
        //        message = "Transaction is pending";
        //        state = 2;
        //    }
        //    else
        //    {
        //        message = "Transaction was not paid successful";
        //        state = 3;
        //    }
        //    ViewBag.Message = message;
        //    ViewBag.State = state;

        //    if (state == 1 || state == 2)
        //    {
        //        float amout =  vpc_Amount / 100;

        //        var model = db.BookTours.Where(a => a.Code.ToString() == vpc_OrderInfo).FirstOrDefault();

        //        BookTourOnePay bookTour = new BookTourOnePay();
        //        bookTour.ID = model.ID;
        //        bookTour.Code = vpc_OrderInfo;
        //        bookTour.Departure = model.Departure;
        //        bookTour.CreateDate = DateTime.Now;
        //        bookTour.Gender = model.Gender;
        //        bookTour.FullName = model.FullName;
        //        bookTour.Tel = model.Tel;
        //        bookTour.Country = model.Country;
        //        bookTour.Email = model.Email;
        //        bookTour.Request = model.Request;
        //        bookTour.Price = model.Price;
        //        bookTour.Status = "Successful";
        //        bookTour.InfoBooking = model.InfoBooking;
        //        bookTour.DepositAmount =  amout;
        //        //decimal price = (decimal)bookTour.Price;

        //        db.BookTourOnePays.InsertOnSubmit(bookTour);
        //        db.SubmitChanges();

        //    }

        //    SendEmail sendEmail =
        //         db.SendEmails.FirstOrDefault(a => a.Type == TypeSendEmail.OnePayTransaction && a.LanguageID == Request.Cookies["LanguageID"].Value);

        //    sendEmail.Title = sendEmail.Title.Replace("{message}", message);
        //    string content = sendEmail.Content;
        //    content = content.Replace("{message}", message);
        //    content = content.Replace("{Code}", vpc_OrderInfo);

        //    //infor Hotel
        //    content = content.Replace("{Add}", hotel.Address);
        //    content = content.Replace("{Hotline}", hotel.Hotline);
        //    content = content.Replace("{EmailHotel}", hotel.Email);
        //    content = content.Replace("{Website}", hotel.Website);
        //    content = content.Replace("{Deposit}", " 30 %");

        //    // do something
        //    MailHelper.SendMail(email, message, content);
        //    MailHelper.SendMail(hotel.Email, message + "Booking  of: " + vpc_OrderInfo, content);


        //    if (state == 1)
        //    {
        //        return View();
        //    }
        //    return View();
        //}

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
                Console.WriteLine(ip);
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

    }
}
