using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectLibrary.Config;
using ProjectLibrary.Database;
using ProjectLibrary.Utility;
using TeamplateHotel.Areas.Administrator.EntityModel;
using TeamplateHotel.Areas.Administrator.ModelShow;

namespace TeamplateHotel.Areas.Administrator.Controllers
{
    public class UsefullinkController : Controller
    {
        //
        // GET: /Administrator/Usefullink/

        [HttpPost]
        public ActionResult UpdateIndex()
        {
            using (var db = new MyDbDataContext())
            {
                var records =
                    db.Usefullinks.Where(a => a.LanguageID == Request.Cookies["lang_client"].Value).ToList();
                foreach (var record in records)
                {
                    string itemAdv = Request.Params[string.Format("Sort[{0}].Index", record.Id)];
                    int index;
                    int.TryParse(itemAdv, out index);
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
                    var listArticle =
                        db.Usefullinks.Where(a => a.LanguageID == Request.Cookies["lang_client"].Value);
                    List<ShowArticle> records = listArticle.Select(a => new ShowArticle
                    {
                        ID = a.Id,
                        Name = a.Name,
                        Index = a.Index,
                        Status = a.Stauts,
                    }).OrderBy(a => a.Index).Skip(jtStartIndex).Take(jtPageSize).ToList();
                    //Return result to jTable
                    return Json(new { Result = "OK", Records = records, TotalRecordCount = listArticle.Count() });
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
            ViewBag.Title = "Thêm usefullink";
            LoadData();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(EUsefullink model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var article = new Usefullink
                        {
                            Name = model.Name,
                            Description = model.Description,
                            Index = 0,
                            Stauts = model.Status,
                            LanguageID = Request.Cookies["lang_client"].Value,
                            Alias = model.Alias,
                            Link = model.Link,
                        };
                        db.Usefullinks.InsertOnSubmit(article);
                        db.SubmitChanges();

                        TempData["Messages"] = "Thêm thành công";
                        return RedirectToAction("Index");
                    }
                    catch (Exception exception)
                    {
                        ViewBag.Messages = "Error: " + exception.Message;
                        return View();
                    }
                }
                return View();
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.Title = "Cập nhật usefullink";

            using (var db = new MyDbDataContext())
            {
                Usefullink detailArticle = db.Usefullinks.FirstOrDefault(a => a.Id == id);

                if (detailArticle == null)
                {
                    TempData["Messages"] = "Usefullink không tồn tại";
                    return RedirectToAction("Index");
                }

                var artile = new EUsefullink
                {
                    ID = detailArticle.Id,
                    Name = detailArticle.Name,
                    Description = detailArticle.Description,
                    Status = detailArticle.Stauts,
                    Link = detailArticle.Link,
                    Alias = detailArticle.Alias,
                };
                LoadData();
                return View(artile);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(EUsefullink model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        Usefullink article = db.Usefullinks.FirstOrDefault(b => b.Id == model.ID);
                        if (article != null)
                        {
                            article.Name = model.Name;
                            article.Description = model.Description;
                            article.Stauts = model.Status;
                            article.Alias = model.Alias;
                            article.Link = model.Link;
                            db.SubmitChanges();
                            TempData["Messages"] = "Cập nhật thành công";
                            return RedirectToAction("Index");
                        }
                    }
                    catch (Exception exception)
                    {
                        ViewBag.Messages = "Lỗi: " + exception.Message;
                        return View();
                    }
                }
                LoadData();
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
                    Usefullink del = db.Usefullinks.FirstOrDefault(c => c.Id == id);
                    if (del != null)
                    {
                        db.Usefullinks.DeleteOnSubmit(del);
                        db.SubmitChanges();
                        return Json(new { Result = "OK", Message = "Xóa thành công" });
                    }
                    return Json(new { Result = "ERROR", Message = "Usefullink không tồn tại" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }

        public void LoadData()
        {
            var listMenu = new List<SelectListItem>
            {
                new SelectListItem {Value = "0", Text = "Lựa chọn chuyên mục"}
            };
            var menus = new List<Menu>();

            menus =
                MenuController.GetListMenu(0, Request.Cookies["lang_client"].Value).Where(
                    a => a.Location == SystemMenuLocation.MainMenu).ToList();

            foreach (Menu menu in menus)
            {
                string sub = "";
                for (int i = 0; i < menu.Level; i++)
                {
                    sub += "|--";
                }
                menu.Title = sub + menu.Title;
            }
            listMenu.AddRange(menus.OrderBy(a => a.Location).Select(a => new SelectListItem
            {
                Text = a.Title,
                Value = a.Alias.ToString()
            }).ToList());

            ViewBag.ListMenu = listMenu;
        }

    }
}
