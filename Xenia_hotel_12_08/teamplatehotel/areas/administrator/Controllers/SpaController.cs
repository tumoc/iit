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
    public class SpaController : BaseController
    {
        // GET: /Administrator/Spa/
        public ActionResult Index()
        {
            ViewBag.Messages = CommentController.Messages(TempData["Messages"]);
            ViewBag.Title = "Trang Spa";
            return View();
        }

        [HttpPost]
        public ActionResult UpdateIndex()
        {
            using (var db = new MyDbDataContext())
            {
                List<Spa> records = db.Spas.Where(r => r.LanguageID == Request.Cookies["lang_client"].Value).ToList();
                foreach (Spa record in records)
                {
                    string itemSpa = Request.Params[string.Format("Sort[{0}].Index", record.ID)];
                    int index;
                    int.TryParse(itemSpa, out index);
                    record.Index = index;
                    db.SubmitChanges();
                }
                TempData["Messages"] = "Sắp xếp spa thành công";
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
                    List<Spa> list = db.Spas.Where(a => a.LanguageID == Request.Cookies["lang_client"].Value).ToList();
                    var records = list.Select(a => new
                    {
                        a.ID,
                        a.Title,
                        a.Index,
                        a.Status,
                        a.Home
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
            ViewBag.Title = "Thêm Spa";
            var eSpa = new ESpa();
            return View(eSpa);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ESpa model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(model.Alias))
                    {
                        model.Alias = StringHelper.ConvertToAlias(model.Title);
                    }
                    try
                    {
                        var spa = new Spa
                        {
                            LanguageID = Request.Cookies["lang_client"].Value,
                            Title = model.Title,
                            Alias = model.Alias,
                            Image = model.Image,
                            Price = model.Price,
                            Index = 0,
                            Description = model.Description,
                            Content = model.Content,
                            MetaTitle = string.IsNullOrEmpty(model.MetaTitle) ? model.Title : model.MetaTitle,
                            Status = model.Status,
                            Home = model.Home
                        };

                        db.Spas.InsertOnSubmit(spa);
                        db.SubmitChanges();

                        TempData["Messages"] = "Thêm spa thành công.";
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
                Spa detailSpa = db.Spas.FirstOrDefault(a => a.ID == id);
                if (detailSpa == null)
                {
                    TempData["Messages"] = "Spa không tồn tại";
                    return RedirectToAction("Index");
                }
                ViewBag.Title = "Sửa phòng";
                var spa = new ESpa
                {
                    ID = detailSpa.ID,
                    Title = detailSpa.Title,
                    Alias = detailSpa.Alias,
                    Image = detailSpa.Image,
                    Price = (decimal)detailSpa.Price,
                    Index = detailSpa.Index,
                    Description = detailSpa.Description,
                    Content = detailSpa.Content,
                    MetaTitle = detailSpa.MetaTitle,
                    Status = detailSpa.Status,
                    Home = detailSpa.Home
                };
                return View(spa);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(ESpa model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        Spa spa = db.Spas.FirstOrDefault(b => b.ID == model.ID);
                        if (spa != null)
                        {
                            spa.Title = model.Title;
                            spa.Alias = model.Alias;
                            spa.Image = model.Image;
                            spa.Price = model.Price;
                            spa.Description = model.Description;
                            spa.Content = model.Content;
                            spa.MetaTitle = string.IsNullOrEmpty(model.MetaTitle) ? model.Title : model.MetaTitle;
                            spa.Status = model.Status;
                            spa.Home = model.Home;

                            db.SubmitChanges();                           
                            TempData["Messages"] = "Sửa spa thành công";
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
                    Spa del = db.Spas.FirstOrDefault(c => c.ID == id);
                    if (del != null)
                    {
                        db.Spas.DeleteOnSubmit(del);
                        db.SubmitChanges();
                        return Json(new {Result = "OK", Message = "Xóa spa thành công"});
                    }
                    return Json(new {Result = "ERROR", Message = "Spa không tồn tại"});
                }
            }
            catch (Exception ex)
            {
                return Json(new {Result = "ERROR", ex.Message});
            }
        }
    }
}