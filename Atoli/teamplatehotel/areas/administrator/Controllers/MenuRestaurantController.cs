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
    public class MenuRestaurantController : Controller
    {
        //
        // GET: /Administrator/MenuRestaurant/

        public ActionResult Index()
        {
            ViewBag.Messages = CommentController.Messages(TempData["Messages"]);
            ViewBag.Title = "Trang thực đơn";
            return View();
        }

        [HttpPost]
        public ActionResult UpdateIndex()
        {
            using (var db = new MyDbDataContext())
            {
                var records =
                    db.MenuRestaurants.Join(db.ListMenus.Where(a => a.LanguageID == Request.Cookies["lang_client"].Value),
                        a => a.MenuID,
                        b => b.ID, (a, b) => new { a }).ToList();
                foreach (var record in records)
                {
                    string itemAdv = Request.Params[string.Format("Sort[{0}].Index", record.a.ID)];
                    int index;
                    int.TryParse(itemAdv, out index);
                    record.a.Index = index;
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
                    var values =
                        db.MenuRestaurants.Join(db.ListMenus.Where(a => a.LanguageID == Request.Cookies["lang_client"].Value),
                            a => a.MenuID, b => b.ID, (a, b) => new { a, b });
                    List<ShowArticle> records = values.Select(a => new ShowArticle
                    {
                        ID = a.a.ID,
                        Title = a.a.Title,
                        TitleMenu = a.b.Title,
                        Index = a.a.Index,
                        Status = a.a.Status,
                    }).OrderBy(a => a.Index).Skip(jtStartIndex).Take(jtPageSize).ToList();
                    //Return result to jTable
                    return Json(new { Result = "OK", Records = records, TotalRecordCount = values.Count() });
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
            LoadData();
            ViewBag.Title = "Thêm thực đơn";
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(EMenuRestaurant model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var menuRestaurant = new MenuRestaurant
                        {
                            MenuID = model.MenuID,
                            Title = model.Title,
                            Image = model.Image,
                            Content = model.Content,
                            Index = 0,
                            Status = model.Status,
                            Price = model.Price,
                            //Link = model.Link
                        };

                        db.MenuRestaurants.InsertOnSubmit(menuRestaurant);
                        db.SubmitChanges();

                        TempData["Messages"] = "Thêm thực đơn thành công";
                        return RedirectToAction("Index");
                    }
                    catch (Exception exception)
                    {
                        LoadData();
                        ViewBag.Messages = "Error: " + exception.Message;
                        return View();
                    }
                }
                LoadData();
                return View();
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.Title = "Cập nhật thực đơn";
            using (var db = new MyDbDataContext())
            {
                MenuRestaurant detailMenuRes = db.MenuRestaurants.FirstOrDefault(a => a.ID == id);

                if (detailMenuRes == null)
                {
                    TempData["Messages"] = "Thực đơn không tồn tại";
                    return RedirectToAction("Index");
                }

                var menuRestaurant = new EMenuRestaurant
                {
                    ID = detailMenuRes.ID,
                    MenuID = (int)detailMenuRes.MenuID,
                    Title = detailMenuRes.Title,
                    Image = detailMenuRes.Image,
                    Content = detailMenuRes.Content,
                    Status = detailMenuRes.Status,
                    Price = detailMenuRes.Price,
                    //Link = detailArticle.Link,
                };
                LoadData();
                return View(menuRestaurant);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(EMenuRestaurant model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        MenuRestaurant menuRestaurant = db.MenuRestaurants.FirstOrDefault(b => b.ID == model.ID);
                        if (menuRestaurant != null)
                        {
                            menuRestaurant.MenuID = model.MenuID;
                            menuRestaurant.Title = model.Title;
                            menuRestaurant.Image = model.Image;
                            menuRestaurant.Content = model.Content;
                            menuRestaurant.Status = model.Status;
                            menuRestaurant.Price = model.Price;
                            //article.Link = model.Link;

                            db.SubmitChanges();
                            TempData["Messages"] = "Cập nhật bài viết thành công";
                            return RedirectToAction("Index");
                        }
                    }
                    catch (Exception exception)
                    {
                        LoadData();
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
                    MenuRestaurant del = db.MenuRestaurants.FirstOrDefault(c => c.ID == id);
                    if (del != null)
                    {
                        db.MenuRestaurants.DeleteOnSubmit(del);
                        db.SubmitChanges();
                        return Json(new { Result = "OK", Message = "Xóa thực đơn thành công" });
                    }
                    return Json(new { Result = "ERROR", Message = "Thực đơn không tồn tại" });
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
            List<ListMenu> menus = CommentController.ListMenus(Request.Cookies["lang_client"].Value);
            
            listMenu.AddRange(menus.Select(a => new SelectListItem
            {
                Text = a.Title,
                Value = a.ID.ToString()
            }).ToList());
            ViewBag.ListMenu = listMenu;
        }

    }
}
