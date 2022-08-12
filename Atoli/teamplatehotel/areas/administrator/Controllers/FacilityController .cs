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
    public class FacilityController : BaseController
    {
        // GET: /Administrator/Facility/
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
                List<Facility> records = db.Facilities.Where(r => r.ID !=0).ToList();
                foreach (Facility record in records)
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
                    List<Facility> list = db.Facilities.Where(a => a.ID !=0&& a.LanguageID == Request.Cookies["lang_client"].Value).ToList();
                    var records = list.Select(a => new
                    {
                        a.ID,
                        a.Title,
                        a.Index,
                    }).OrderBy(a => a.Index).Skip(jtStartIndex).Take(jtPageSize).ToList();
                    //Return result to jTable
                    return Json(new {Result = "OK", Records = records, TotalRecordCount = list.Count});
                }
            }
            catch (Exception ex)
            {
                return Json(new {Result = "ERROR", ex.Message});
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Thêm tiện ích cơ bản";
            var eBasic = new EFacility();
            return View(eBasic);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(EFacility model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var Facility = new Facility
                        {
                            LanguageID = Request.Cookies["lang_client"].Value,
                            Title = model.Title,
                            Content = model.Content,
                            Index = 0,
                            Hot = model.Hot,
                            Image = model.Image,
                            Premium = model.Premium,
                        };

                        db.Facilities.InsertOnSubmit(Facility);
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
                Facility detailFacility = db.Facilities.FirstOrDefault(a => a.ID == id);
                if (detailFacility == null)
                {
                    TempData["Messages"] = "Tiện ích không tồn tại";
                    return RedirectToAction("Index");
                }
                ViewBag.Title = "Sửa tiện ích";
                var Facility = new EFacility
                {
                    ID = detailFacility.ID,
                    Title = detailFacility.Title,
                    Index = detailFacility.Index,
                    Image = detailFacility.Image,
                    Content = detailFacility.Content,
                    Premium = detailFacility.Premium,
                    Hot = detailFacility.Hot,
                };
                return View(Facility);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(EFacility model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        Facility Facility = db.Facilities.FirstOrDefault(b => b.ID == model.ID);
                        if (Facility != null)
                        {
                            Facility.Title = model.Title;
                            Facility.Content = model.Content;
                            Facility.Premium = model.Premium;
                            Facility.Image = model.Image;
                            Facility.Hot = model.Hot;
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
                    Facility del = db.Facilities.FirstOrDefault(c => c.ID == id);
                    if (del != null)
                    {
                        db.Facilities.DeleteOnSubmit(del);
                        db.SubmitChanges();
                        return Json(new {Result = "OK", Message = "Xóa tiện ích thành công"});
                    }
                    return Json(new {Result = "ERROR", Message = "Tiện ích không tồn tại"});
                }
            }
            catch (Exception ex)
            {
                return Json(new {Result = "ERROR", ex.Message});
            }
        }
    }
}