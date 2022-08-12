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
    public class HotelRuleController : BaseController
    {
        // GET: /Administrator/HotelRule/
        public ActionResult Index()
        {
            ViewBag.Messages = CommentController.Messages(TempData["Messages"]);
            ViewBag.Title = "Trang nội quy";
            return View();
        }

        [HttpPost]
        public ActionResult UpdateIndex()
        {
            using (var db = new MyDbDataContext())
            {
                List<HotelRule> records = db.HotelRules.Where(r => r.languageID == Request.Cookies["lang_client"].Value).ToList();
                foreach (HotelRule record in records)
                {
                    string itemHotelRule = Request.Params[string.Format("Sort[{0}].Index", record.ID)];
                    int index;
                    int.TryParse(itemHotelRule, out index);
                    record.Index = index;
                    db.SubmitChanges();
                }
                TempData["Messages"] = "Sắp xếp nội quy thành công";
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
                    List<HotelRule> list = db.HotelRules.Where(a => a.languageID == Request.Cookies["lang_client"].Value).ToList();
                    var records = list.Select(a => new
                    {
                        a.ID,
                        a.Rule,
                        a.Index,
                        a.Status
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
            ViewBag.Title = "Thêm nội quy";
            var eHotelRule = new EHotelRule();
            return View(eHotelRule);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(EHotelRule model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var hotelRule = new HotelRule
                        {
                            languageID = Request.Cookies["lang_client"].Value,
                            Rule = model.Rule,
                            Index = 0,
                            Status = model.Status,
                        };

                        db.HotelRules.InsertOnSubmit(hotelRule);
                        db.SubmitChanges();

                        TempData["Messages"] = "Thêm nội quy thành công.";
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
                HotelRule detailRule = db.HotelRules.FirstOrDefault(a => a.ID == id);
                if (detailRule == null)
                {
                    TempData["Messages"] = "Nội quy không tồn tại";
                    return RedirectToAction("Index");
                }
                ViewBag.Title = "Sửa nội quy";
                var hotelRule = new EHotelRule()
                {
                    ID = detailRule.ID,
                    Rule = detailRule.Rule,
                    Index = detailRule.Index,
                    Status = detailRule.Status
                };
                return View(hotelRule);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(EHotelRule model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        HotelRule hotelRule = db.HotelRules.FirstOrDefault(b => b.ID == model.ID);
                        if (hotelRule != null)
                        {
                            hotelRule.Rule = model.Rule;
                            hotelRule.Status = model.Status;

                            db.SubmitChanges();
                            TempData["Messages"] = "Sửa nội quy thành công";
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
                    HotelRule del = db.HotelRules.FirstOrDefault(c => c.ID == id);
                    if (del != null)
                    {
                        db.HotelRules.DeleteOnSubmit(del);
                        db.SubmitChanges();
                        return Json(new {Result = "OK", Message = "Xóa nội quy thành công"});
                    }
                    return Json(new {Result = "ERROR", Message = "Nội quy không tồn tại"});
                }
            }
            catch (Exception ex)
            {
                return Json(new {Result = "ERROR", ex.Message});
            }
        }
    }
}