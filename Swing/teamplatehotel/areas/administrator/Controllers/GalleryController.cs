using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectLibrary.Config;
using ProjectLibrary.Database;
using ProjectLibrary.Utility;
using TeamplateHotel.Areas.Administrator.EntityModel;
using TeamplateHotel.Areas.Administrator.ModelShow;

namespace TeamplateHotel.Areas.Administrator.Controllers
{
    public class GalleryController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Trang gallery";
            ViewBag.Messages = CommentController.Messages(TempData["Messages"]);
            
            return View();
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                using (var db = new MyDbDataContext())
                {
                    var list = db.Galleries.ToList();
                    List<ShowArticle> records = list.Select(a => new ShowArticle
                    {
                        ID = a.ID,
                        Title = a.Title,
                        TitleMenu = db.Menus.Where(b => b.ID == a.MenuId).Select(b => b.Title).FirstOrDefault(),
                        Index = a.Index,
                        Image = a.LargeImage,
                    }).OrderBy(a => a.Index).Skip(jtStartIndex).Take(jtPageSize).ToList();

                    //Return result to jTable
                    return Json(new {Result = "OK", Records = records, TotalRecordCount = list.Count()});
                }
            }
            catch (Exception ex)
            {
                return Json(new {Result = "ERROR", message = ex.Message});
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Thêm ảnh";
            var eGallery = new EGallery();
            var db = new MyDbDataContext();
            List<SelectListItem> list = new List<SelectListItem>();
            List<Menu> menus = db.Menus.ToList();
            menus =
                MenuController.GetListMenu(0, Request.Cookies["lang_client"].Value).Where(
                    a =>
                        a.Type == SystemMenuType.RoomRate ||
                        a.Type == SystemMenuType.Service ||
                        a.Type == SystemMenuType.About ).ToList();

            foreach (Menu menu in menus)
            {
                string sub = "";
                for (int i = 0; i < menu.Level; i++)
                {
                    sub += "|--";
                }
                menu.Title = sub + menu.Title;
            }
            list.AddRange(menus.OrderBy(a => a.Location).Select(a => new SelectListItem
            {
                Text = a.Title,
                Value = a.ID.ToString()
            }).ToList());
            ViewBag.ListMenu = list;
            return View(eGallery);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(EGallery model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var insert = new Gallery
                        {
                            Title = model.Title,
                            MenuId = model.MenuId,
                            Index = 0,
                            LargeImage = model.Image,
                            SmallImage = ReturnSmallImage.GetImageSmall(model.Image),

                        };
                        
                        db.Galleries.InsertOnSubmit(insert);
                        db.SubmitChanges();
                        TempData["Messages"] = "Thêm gallery thành công.";
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
                Gallery gallery = db.Galleries.FirstOrDefault(a => a.ID == id);
                if (gallery == null)
                {
                    TempData["Messages"] = "Hình ảnh không tồn tại";
                    return RedirectToAction("Index");
                }
                ViewBag.Title = "Sửa hình ảnh";
                var gallery1 = new EGallery
                {
                    ID = gallery.ID,
                    Title = gallery.Title,
                    Image = gallery.LargeImage,
                    Index = gallery.Index,
                    MenuId=gallery.MenuId,
                };
                List<SelectListItem> list = new List<SelectListItem>();
                List<Menu> menus = db.Menus.ToList();
                menus =
                    MenuController.GetListMenu(0, Request.Cookies["lang_client"].Value).Where(
                        a =>
                            a.Type == SystemMenuType.RoomRate ||
                            a.Type == SystemMenuType.Service ||
                            a.Type == SystemMenuType.About).ToList();

                foreach (Menu menu in menus)
                {
                    string sub = "";
                    for (int i = 0; i < menu.Level; i++)
                    {
                        sub += "|--";
                    }
                    menu.Title = sub + menu.Title;
                }
                list.AddRange(menus.OrderBy(a => a.Location).Select(a => new SelectListItem
                {
                    Text = a.Title,
                    Value = a.ID.ToString()
                }).ToList());
                ViewBag.ListMenu = list;
                return View(gallery1);
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(EGallery model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        Gallery edit = db.Galleries.FirstOrDefault(b => b.ID == model.ID);
                        string imageSmall = "/Files/_thumbs" + model.Image.Substring(6, model.Image.Length - 6);
                        if (edit != null)
                        {
                            edit.Title = model.Title;
                            edit.LargeImage = model.Image;
                            edit.SmallImage = imageSmall;
                            edit.MenuId = model.MenuId;
                            db.SubmitChanges();

                            TempData["Messages"] = "Sửa gallery thành công";
                            return RedirectToAction("Index");
                        }
                        return Json(new {Result = "ERROR", Message = "Gallery không tồn tại" });
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
                    Gallery del = db.Galleries.FirstOrDefault(c => c.ID == id);
                    if (del != null)
                    {
                        db.Galleries.DeleteOnSubmit(del);
                        db.SubmitChanges();
                        return Json(new {Result = "OK", Message = "Xóa gallery thành công"});
                    }
                    return Json(new {Result = "ERROR", Message = "Gallery không tồn tại"});
                }
            }
            catch (Exception ex)
            {
                return Json(new {Result = "Error", Message = "Error: " + ex.Message});
            }
        }

        [HttpPost]
        public ActionResult UpdateIndex()
        {
            using (var db = new MyDbDataContext())
            {
                List<Gallery> records = db.Galleries.ToList();
                foreach (Gallery record in records)
                {
                    string itemAdv = Request.Params[string.Format("Sort[{0}].Index", record.ID)];
                    int index;
                    int.TryParse(itemAdv, out index);
                    record.Index = index;
                    db.SubmitChanges();
                }
                TempData["Messages"] = "Sắp xếp gallery thành công";
                return RedirectToAction("Index");
            }
        }
    }
}