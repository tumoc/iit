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
    public class AwardController : Controller
    {
        //
        // GET: /Administrator/Award/

        public ActionResult Index()
        {
            ViewBag.Messages = CommentController.Messages(TempData["Messages"]);
            ViewBag.Title = "Trang quản lý giải thưởng";
            return View();
        }

        [HttpPost]
        public ActionResult UpdateIndex()
        {
            using (var db = new MyDbDataContext())
            {
                List<Award> records = db.Awards.Where(r => r.ID != 0).ToList();
                foreach (Award record in records)
                {
                    string itemRoom = Request.Params[string.Format("Sort[{0}].Index", record.ID)];
                    int index;
                    int.TryParse(itemRoom, out index);
                    record.Index = index;
                    db.SubmitChanges();
                }
                TempData["Messages"] = "Sắp xếp thành công";
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
                    List<Award> list = db.Awards.Where(a => a.ID != 0 && a.LanguageID == Request.Cookies["lang_client"].Value).ToList();
                    var records = list.Select(a => new
                    {
                        a.ID,
                        a.Title,
                        a.Index,
                        a.Image,
                        a.Status
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
            ViewBag.Title = "Thêm giải thưởng";
            var eAmenity = new EAward();
            return View(eAmenity);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(EAward model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var amenity = new Award
                        {
                            LanguageID = Request.Cookies["lang_client"].Value,
                            Title = model.Title,
                            Image = model.Image,
                            Index = 0,
                            Status = model.Status
                        };

                        db.Awards.InsertOnSubmit(amenity);
                        db.SubmitChanges();

                        TempData["Messages"] = "Thêm thành công.";
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
                Award detailAmenity = db.Awards.FirstOrDefault(a => a.ID == id);
                if (detailAmenity == null)
                {
                    TempData["Messages"] = "Giải thưởng không tồn tại";
                    return RedirectToAction("Index");
                }
                ViewBag.Title = "Sửa tiện ích";
                var amenity = new EAward
                {
                    ID = detailAmenity.ID,
                    Title = detailAmenity.Title,
                    Image = detailAmenity.Image,
                    Index = detailAmenity.Index,
                    Status = detailAmenity.Status,
                };
                return View(amenity);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(EAward model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        Award amenity = db.Awards.FirstOrDefault(b => b.ID == model.ID);
                        if (amenity != null)
                        {
                            amenity.Title = model.Title;
                            amenity.Image = model.Image;
                            amenity.Status = model.Status;
                            db.SubmitChanges();

                            TempData["Messages"] = "Sửa thành công";
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
                    Award del = db.Awards.FirstOrDefault(c => c.ID == id);
                    if (del != null)
                    {

                        db.Awards.DeleteOnSubmit(del);
                        db.SubmitChanges();
                        return Json(new { Result = "OK", Message = "Xóa thành công" });
                    }
                    return Json(new { Result = "ERROR", Message = "Giải thưởng không tồn tại" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }

    }
}
