using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectLibrary.Config;
using ProjectLibrary.Database;
using TeamplateHotel.Models;

namespace TeamplateHotel.Controllers
{
    public class BookingController : Controller
    {
        [HttpGet]
        public ActionResult MakeReservation(string checkInDate,string checkOutDate, int? Child, int? Adult,int? Id)
        {
            using (var db = new MyDbDataContext())
            {
                var bookRoom = new BookRoom();

                if (checkInDate !=null && checkOutDate != null && Child !=null && Adult!=null )
                {
                    bookRoom.CheckIn = DateTime.ParseExact(checkInDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    bookRoom.CheckOut = DateTime.ParseExact(checkOutDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    bookRoom.Adult = (int)Adult;
                    bookRoom.Child = (int)Child;
                    
                }
                else
                {
                    if(checkInDate != null && checkOutDate != null && Child == null && Adult == null)
                    {
                        bookRoom.CheckIn = DateTime.ParseExact(checkInDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        bookRoom.CheckOut = DateTime.ParseExact(checkOutDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        bookRoom.Adult = 1;
                        bookRoom.Child = 0;
                    }
                    else
                    {
                        bookRoom.Adult = 1;
                        bookRoom.Child = 0;
                        bookRoom.CheckIn = DateTime.Now;
                        bookRoom.CheckOut = DateTime.Now.AddDays(1);
                    }
                    
                }
                if (bookRoom.CheckOut <= bookRoom.CheckIn)
                {
                    bookRoom.CheckOut = bookRoom.CheckIn.AddDays(1);
                }
                var optionNumber = new List<SelectListItem>();
                for (var i=0;i<11;i++)
                {
                    optionNumber.Add(new SelectListItem
                    {
                        Text = i.ToString(),
                        Value = i.ToString()
                    }) ;
                }
                List<ListRoomBooking> listRoomBookings =
                    db.Rooms.Where(a => a.Status && a.LanguageID == Request.Cookies["LanguageID"].Value).Select(a => new ListRoomBooking
                    {
                        RoomId = a.ID,
                        NameRoom = a.Title,
                        Price = a.Price,
                        PricePremium = a.PricePremium,
                        MaxPeople = a.MaxPeople,
                        Number = 0,
                        NumberPremium = 0,
                        Content = a.Content,
                    }).ToList();
                bookRoom.ListRoomBookings = listRoomBookings;
                if(Id == null)
                {
                    ViewBag.RoomId = db.Rooms.Where(a => a.Status && a.LanguageID == Request.Cookies["LanguageID"].Value).Select(a => a.ID).FirstOrDefault();
                }
                else
                {
                    ViewBag.RoomId = Id;
                }
                ViewBag.OptionNumber = optionNumber;
                ViewBag.OptionAdult = bookRoom.Adult;
                ViewBag.OptionChild = bookRoom.Child;

                return View(bookRoom);
            }
        }

        [HttpPost]
        public ActionResult SendBooking(BookRoom model)
        {
            string status = "success";
            if (ModelState.IsValid)
            {
                try
                {
                    using (var db = new MyDbDataContext())
                    {
                        Hotel hotel = CommentController.DetailHotel(Request.Cookies["LanguageID"].Value);
                        string codeBooking = hotel.CodeBooking + "1";
                        if (db.BookRooms.Any())
                        {
                            codeBooking = hotel.CodeBooking +
                                          (db.BookRooms.OrderByDescending(a => a.ID).FirstOrDefault().ID + 1);
                        }
                        model.Code = codeBooking;
                        TimeSpan Time = model.CheckOut - model.CheckIn;
                        int TongSoNgay = Time.Days;
                        int night = 0;
                        if (TongSoNgay == 1)
                        {
                            night = 1;
                        }
                        else
                        {
                            night = TongSoNgay - 1;
                        }
                        string infoBooking=string.Empty;
                        decimal totelPrice = 0;
                        
                        foreach (ListRoomBooking item in model.ListRoomBookings)
                        {
                            var s = CommentController.PriceNet(item.RoomId);
                            if (s != "")
                            {
                                decimal pricenet = decimal.Parse(CommentController.PriceNet(item.RoomId));
                                if (item.Number > 0 && item.NumberPremium > 0)
                                {
                                    infoBooking += item.NameRoom + " : Basic = " + item.Number + ", Premium = " + item.NumberPremium + "; ";
                                    totelPrice += (decimal)item.Price * item.Number * night - pricenet / 100 * (decimal)item.Price * night * item.Number;
                                    totelPrice += (decimal)item.PricePremium * item.NumberPremium * night - pricenet / 100 * (decimal)item.PricePremium * night * item.NumberPremium;
                                }
                                else
                                {
                                    if (item.Number > 0)
                                    {
                                        infoBooking += item.NameRoom + " : Basic = " + item.Number + "; ";

                                        totelPrice += (decimal)item.Price * item.Number * night - pricenet / 100 * (decimal)item.Price * night * item.Number;
                                    }
                                    else
                                    {
                                        if (item.NumberPremium > 0)
                                        {
                                            infoBooking += item.NameRoom + " : Premium = " + item.NumberPremium + "; ";
                                            totelPrice += (decimal)item.PricePremium * item.NumberPremium * night - pricenet / 100 * (decimal)item.PricePremium * night * item.NumberPremium;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (item.Number > 0 && item.NumberPremium > 0)
                                {
                                    infoBooking += item.NameRoom + " : Basic = " + item.Number + ", Premium = " + item.NumberPremium + "; ";
                                    totelPrice += (decimal)item.Price * item.Number * night;
                                    totelPrice += (decimal)item.PricePremium * item.NumberPremium * night ;
                                }
                                else
                                {
                                    if (item.Number > 0)
                                    {
                                        infoBooking += item.NameRoom + " : Basic = " + item.Number + "; ";

                                        totelPrice += (decimal)item.Price * item.Number * night ;
                                    }
                                    else
                                    {
                                        if (item.NumberPremium > 0)
                                        {
                                            infoBooking += item.NameRoom + " : Premium = " + item.NumberPremium + "; ";
                                            totelPrice += (decimal)item.PricePremium * item.NumberPremium * night ;
                                        }
                                    }
                                }
                            }
                             
                        }
                        model.TotalMoney = totelPrice;
                        model.DateBook = DateTime.Now;
                        model.InfoBooking = infoBooking;

                        db.BookRooms.InsertOnSubmit(model);
                        db.SubmitChanges();
                        //Gửi email xác nhận đặt phòng
                        SendEmail sendEmail =
                        db.SendEmails.FirstOrDefault(
                            a => a.Type == TypeSendEmail.BookRoom && a.LanguageID == Request.Cookies["LanguageID"].Value);

                        sendEmail.Title = sendEmail.Title.Replace("{HotelName}", hotel.Name);
                        string content = sendEmail.Content;
                        content = content.Replace("{Code}", model.Code);
                        content = content.Replace("{Gender}", model.Gender);
                        content = content.Replace("{FullName}", model.FullName);
                        content = content.Replace("{Email}", model.Email);
                        content = content.Replace("{Tel}", model.Phone);
                        content = content.Replace("{Address}", model.Address);
                        content = content.Replace("{City}", model.City);
                        content = content.Replace("{Country}", model.Country);
                        content = content.Replace("{Smoking}", model.Smoking ? "Yes" : "No");
                        content = content.Replace("{ArrivalFlight}", model.ArrivalFlight);
                        content = content.Replace("{ArrivalTime}", model.ArrivalTime);
                        content = content.Replace("{Request}", model.Request);
                        content = content.Replace("{InfoBooking}", model.InfoBooking);
                        content = content.Replace("{CheckIn}", model.CheckIn.ToString("MMMM, dd, yyyy"));
                        content = content.Replace("{CheckOut}", model.CheckOut.ToString("MMMM, dd, yyyy"));
                        content = content.Replace("{Adult}", model.Adult.ToString());
                        content = content.Replace("{Child}", model.Child.ToString());
                        content = content.Replace("{TotalPrice}", model.TotalMoney.ToString("N"));
                        content = content.Replace("{HotelName}", hotel.Name);
                        content = content.Replace("{HotelEmail}", hotel.Email);
                        content = content.Replace("{HotelTel}", hotel.Tel);
                        content = content.Replace("{Website}", hotel.Website);

                        MailHelper.SendMail(model.Email, sendEmail.Title, content);
                        MailHelper.SendMail(hotel.Email, hotel.Name + " (" + model.Code+")- Booking room of " + model.FullName, content);
                    }
                }
                catch(Exception ex)
                {
                    status = "error";
                }
            }

            return Redirect("/Booking/Messages/?status=" + status);
        }

        [HttpGet]
        public ActionResult Messages()
        {
            using (var db = new MyDbDataContext())
            {
                SendEmail sendEmail =
                       db.SendEmails.FirstOrDefault(
                           a => a.Type == TypeSendEmail.BookRoom && a.LanguageID == Request.Cookies["LanguageID"].Value);

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
    }
}