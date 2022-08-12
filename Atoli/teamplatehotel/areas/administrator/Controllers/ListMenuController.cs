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
    public class ListMenuController : Controller
    {
        //
        // GET: /Administrator/ListMenu/

        public ActionResult Index()
        {
            ViewBag.Messages = CommentController.Messages(TempData["Messages"]);
            ViewBag.Title = "Trang quản lý danh mục";
            return View();
        }

        [HttpPost]
        public ActionResult UpdateIndex()
        {
            using (var db = new MyDbDataContext())
            {
                List<ListMenu> records = db.ListMenus.Where(r => r.ID != 0).ToList();
                foreach (ListMenu record in records)
                {
                    string itemMenu = Request.Params[string.Format("Sort[{0}].Index", record.ID)];
                    int index;
                    int.TryParse(itemMenu, out index);
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
                    List<ListMenu> list = db.ListMenus.Where(a => a.ID != 0 && a.LanguageID == Request.Cookies["lang_client"].Value).ToList();
                    var records = list.Select(a => new
                    {
                        a.ID,
                        a.Title,
                        a.Index,
                        a.Time,
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
            ViewBag.Title = "Thêm menu";
            var eListMenu = new EListMenu();
            return View(eListMenu);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(EListMenu model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var listMenu = new ListMenu
                        {
                            LanguageID = Request.Cookies["lang_client"].Value,
                            Title = model.Title,
                            Time = model.Time,
                            Index = 0,
                        };

                        db.ListMenus.InsertOnSubmit(listMenu);
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
                ListMenu detailListMenu = db.ListMenus.FirstOrDefault(a => a.ID == id);
                if (detailListMenu == null)
                {
                    TempData["Messages"] = "Danh mục không tồn tại";
                    return RedirectToAction("Index");
                }
                ViewBag.Title = "Sửa tiện ích";
                var listMenu = new EListMenu
                {
                    ID = detailListMenu.ID,
                    Title = detailListMenu.Title,
                    Time = detailListMenu.Time,
                    Index = detailListMenu.Index,
                };
                return View(listMenu);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(EListMenu model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        ListMenu listMenu = db.ListMenus.FirstOrDefault(b => b.ID == model.ID);
                        if (listMenu != null)
                        {
                            listMenu.Title = model.Title;
                            listMenu.Time = model.Time;

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
                    ListMenu del = db.ListMenus.FirstOrDefault(c => c.ID == id);
                    if (del != null)
                    {

                        db.ListMenus.DeleteOnSubmit(del);
                        db.SubmitChanges();
                        return Json(new { Result = "OK", Message = "Xóa thành công" });
                    }
                    return Json(new { Result = "ERROR", Message = "Danh mục không tồn tại" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }

    }
}
