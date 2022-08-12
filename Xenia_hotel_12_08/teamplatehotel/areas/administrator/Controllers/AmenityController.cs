using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectLibrary.Config;
using ProjectLibrary.Database;
using ProjectLibrary.Utility;
using TeamplateHotel.Areas.Administrator.EntityModel;

namespace TeamplateHotel.Areas.Administrator.Controllers
{
    public class AmenityController : BaseController
    {
        // GET: /Administrator/Amenity/
        public ActionResult Index()
        {
            ViewBag.Messages = CommentController.Messages(TempData["Messages"]);
            ViewBag.Title = "Trang quản lý tiện ích";
            return View();
        }

        [HttpPost]
        public ActionResult UpdateIndex()
        {
            using (var db = new MyDbDataContext())
            {
                List<Amenity> records = db.Amenities.Where(r => r.ID != 0).ToList();
                foreach (Amenity record in records)
                {
                    string itemRoom = Request.Params[string.Format("Sort[{0}].Index", record.ID)];
                    int index;
                    int.TryParse(itemRoom, out index);
                    record.Index = index;
                    db.SubmitChanges();
                }
                TempData["Messages"] = "Sắp xếp tiện ích thành công";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                using (var db = new MyDbDataContext())
                {
                    List<Amenity> list = db.Amenities.Where(a => a.ID != 0 && a.languageID == Request.Cookies["lang_client"].Value).ToList();
                    var records = list.Select(a => new
                    {
                        a.ID,
                        a.Title,
                        a.Index,
                        a.Status,
                        a.Home
                    }).OrderBy(a => a.Index).Skip(jtStartIndex).Take(jtPageSize).ToList();
                    //Return result to jTable
                    return Json(new { Result = "OK", Records = records, TotalRecordCount = list.Count });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Thêm tiện ích";
            var eAmenity = new EAmenity();
            return View(eAmenity);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(EAmenity model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var amenity = new Amenity
                        {
                            languageID = Request.Cookies["lang_client"].Value,
                            Title = model.Title,
                            Image = model.Image,
                            Description = model.Description,
                            Index = 0,
                            Status = model.Status,
                            Home = model.Home
                        };

                        db.Amenities.InsertOnSubmit(amenity);
                        db.SubmitChanges();

                        TempData["Messages"] = "Thêm tiện ích thành công.";
                        return RedirectToAction("Index");
                    }
                    catch (Exception exception)
                    {
                        ViewBag.Messages = "Error: " + exception.Message;
                        return View(model);
                    }
                }
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            using (var db = new MyDbDataContext())
            {
                Amenity detailAmenity = db.Amenities.FirstOrDefault(a => a.ID == id);
                if (detailAmenity == null)
                {
                    TempData["Messages"] = "Tiện ích không tồn tại";
                    return RedirectToAction("Index");
                }
                ViewBag.Title = "Sửa tiện ích";
                var amenity = new EAmenity
                {
                    ID = detailAmenity.ID,
                    Title = detailAmenity.Title,
                    Description = detailAmenity.Description,
                    Image = detailAmenity.Image,
                    Index = detailAmenity.Index,
                    Status = detailAmenity.Status,
                    Home = detailAmenity.Home
                };
                return View(amenity);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(EAmenity model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        Amenity amenity = db.Amenities.FirstOrDefault(b => b.ID == model.ID);
                        if (amenity != null)
                        {
                            amenity.Title = model.Title;
                            amenity.Image = model.Image;
                            amenity.Description = model.Description;
                            amenity.Status = model.Status;
                            amenity.Home = model.Home;

                            db.SubmitChanges();

                            TempData["Messages"] = "Sửa tiện ích thành công";
                            return RedirectToAction("Index");
                        }
                    }
                    catch (Exception exception)
                    {
                        ViewBag.Messages = "Error: " + exception.Message;
                        return View(model);
                    }
                }
                return View(model);
            }
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                using (var db = new MyDbDataContext())
                {
                    Amenity del = db.Amenities.FirstOrDefault(c => c.ID == id);
                    if (del != null)
                    {

                        db.Amenities.DeleteOnSubmit(del);
                        db.SubmitChanges();
                        return Json(new { Result = "OK", Message = "Xóa tiện ích thành công" });
                    }
                    return Json(new { Result = "ERROR", Message = "Tiện ích không tồn tại" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }
    }
}