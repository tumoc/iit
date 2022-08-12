using System;
using System.Linq;
using System.Web.Mvc;
using ProjectLibrary.Database;

namespace TeamplateHotel.Areas.Administrator.Controllers
{
    public class BookRestaurantController : BaseController
    {
        //
        // GET: /Administrator/BookTour/
        public ActionResult Index()
        {
            ViewBag.Messages = CommentController.Messages(TempData["Messages"]);
            ViewBag.Title = "Trang đặt service";

            return View();
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                var db = new MyDbDataContext();
                var records = db.BookingRestaurants.Select(a => new
                {
                    a.ID,
                    a.Code,
                    a.Gender,
                    a.FullName,
                    Departure = a.Departure.ToShortDateString(),
                    a.Country,
                    Tour = a.InfoBooking,
                    a.Email,
                }).Skip(jtStartIndex).Take(jtPageSize).ToList();
                //Return result to jTable
                return Json(new {Result = "OK", Records = records, TotalRecordCount = db.BookingRestaurants.Count()});
            }
            catch (Exception ex)
            {
                return Json(new {Result = "ERROR", ex.Message});
            }
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var db = new MyDbDataContext();
            BookingRestaurant del = db.BookingRestaurants.FirstOrDefault(a => a.ID == id);
            if (del == null)
            {
                return Json(new {Result = "ERROR", Message = "Đặt service này không tồn tại"});
            }
            db.BookingRestaurants.DeleteOnSubmit(del);
            db.SubmitChanges();
            return Json(new {Result = "OK", Message = "Xóa đặt service thành công"});
        }

        [HttpGet]
        public ActionResult Detail(int Id)
        {
            var db = new MyDbDataContext();
            BookingRestaurant detail = db.BookingRestaurants.FirstOrDefault(a => a.ID == Id);
            if (detail == null)
            {
                TempData["Messages"] = "Đặt service không tồn tại";
                return RedirectToAction("Index");
            }
            return View("Detail", detail);
        }
    }
}