//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using ProjectLibrary.Database;

//namespace TeamplateHotel.Areas.Administrator.Controllers
//{
//    public class BookTourOnePayController : BaseController
//    {
//        //
//        // GET: /Administrator/BookTourOnePay/

//        public ActionResult Index()
//        {
//            ViewBag.Messages = CommentController.Messages(TempData["Messages"]);
//            ViewBag.Title = "Trang đặt tour thanh toán qua OnePay";

//            return View();
//        }

//        [HttpPost]
//        public JsonResult List(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
//        {
//            try
//            {
//                var db = new MyDbDataContext();
//                var records = db.BookTourOnePays.Select(a => new
//                {
//                    a.ID,
//                    a.Code,
//                    a.Gender,
//                    a.FullName,
//                    Departure = a.Departure.ToShortDateString(),
//                    a.Tel,
//                    Tour = a.InfoBooking,
//                    a.Price,
//                    a.DepositAmount,
//                    a.Status,
//                }).Skip(jtStartIndex).Take(jtPageSize).ToList();
//                //Return result to jTable
//                return Json(new { Result = "OK", Records = records, TotalRecordCount = db.BookTours.Count() });
//            }
//            catch (Exception ex)
//            {
//                return Json(new { Result = "ERROR", ex.Message });
//            }
//        }

//        [HttpGet]
//        public ActionResult Detail(int Id)
//        {
//            var db = new MyDbDataContext();
//            BookTourOnePay detail = db.BookTourOnePays.FirstOrDefault(a => a.ID == Id);
//            if (detail == null)
//            {
//                TempData["Messages"] = "Đặt tour không tồn tại";
//                return RedirectToAction("Index");
//            }
//            return View("Detail", detail);
//        }

//    }
//}
