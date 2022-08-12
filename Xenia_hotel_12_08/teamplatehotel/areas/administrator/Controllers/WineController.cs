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
    public class WineController : BaseController
    {
        // GET: /Administrator/Room/
        public ActionResult Index()
        {
            ViewBag.Messages = CommentController.Messages(TempData["Messages"]);
            ViewBag.Title = "Trang quảng lý rượu";
            return View();
        }

        [HttpPost]
        public ActionResult UpdateIndex()
        {
            using (var db = new MyDbDataContext())
            {
                List<Wine> records = db.Wines.Where(r => r.LanguageID == Request.Cookies["lang_client"].Value).ToList();
                foreach (Wine record in records)
                {
                    string itemWine = Request.Params[string.Format("Sort[{0}].Index", record.ID)];
                    int index;
                    int.TryParse(itemWine, out index);
                    record.Index = index;
                    db.SubmitChanges();
                }
                TempData["Messages"] = "Sắp xếp phòng thành công";
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
                    List<Wine> list = db.Wines.Where(a => a.LanguageID == Request.Cookies["lang_client"].Value).ToList();
                    var records = list.Select(a => new
                    {
                        a.ID,
                        a.Title,
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
            ViewBag.Title = "Thêm rượu";
            var eWine = new EWine();
            return View(eWine);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(EWine model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var wine = new Wine
                        {
                            LanguageID = Request.Cookies["lang_client"].Value,
                            Title = model.Title,
                            Image = model.Image,
                            Price = model.Price,
                            Index = 0,
                            Fromto = model.Fromto,
                            Status = model.Status,
                        };

                        db.Wines.InsertOnSubmit(wine);
                        db.SubmitChanges();

                        TempData["Messages"] = "Thêm rượu thành công.";
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
                Wine detailWine = db.Wines.FirstOrDefault(a => a.ID == id);
                if (detailWine == null)
                {
                    TempData["Messages"] = "Phòng không tồn tại";
                    return RedirectToAction("Index");
                }
                ViewBag.Title = "Sửa phòng";
                var room = new EWine
                {
                    ID = detailWine.ID,
                    Title = detailWine.Title,
                    Image = detailWine.Image,
                    Price = detailWine.Price,
                    Index = detailWine.Index,
                    Fromto = detailWine.Fromto,
                    Status = detailWine.Status,
                };

                return View(room);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(EWine model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        Wine room = db.Wines.FirstOrDefault(b => b.ID == model.ID);
                        if (room != null)
                        {
                            room.Title = model.Title;
                            room.Image = model.Image;
                            room.Price = model.Price;
                            room.Fromto = model.Fromto;
                            room.Status = model.Status;

                            db.SubmitChanges();
                            TempData["Messages"] = "Sửa rượu thành công";
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
                    Wine del = db.Wines.FirstOrDefault(c => c.ID == id);
                    if (del != null)
                    {

                        db.Wines.DeleteOnSubmit(del);
                        db.SubmitChanges();
                        return Json(new {Result = "OK", Message = "Xóa phòng thành công"});
                    }
                    return Json(new {Result = "ERROR", Message = "Phòng không tồn tại"});
                }
            }
            catch (Exception ex)
            {
                return Json(new {Result = "ERROR", ex.Message});
            }
        }
    }
}