﻿using System;
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
    public class ArticleController : BaseController
    {
        // GET: /Administrator/Article/
        public ActionResult Index()
        {
            ViewBag.Messages = CommentController.Messages(TempData["Messages"]);
            ViewBag.Title = "Trang bài viết";
            return View();
        }

        [HttpPost]
        public ActionResult UpdateIndex()
        {
            using (var db = new MyDbDataContext())
            {
                var records =
                    db.Articles.Join(db.Menus.Where(a => a.LanguageID == Request.Cookies["lang_client"].Value),
                        a => a.MenuID,
                        b => b.ID, (a, b) => new {a}).ToList();
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
                    var listArticle =
                        db.Articles.Join(db.Menus.Where(a => a.LanguageID == Request.Cookies["lang_client"].Value),
                            a => a.MenuID, b => b.ID, (a, b) => new {a, b});
                    List<ShowArticle> records = listArticle.Select(a => new ShowArticle
                    {
                        ID = a.a.ID,
                        Title = a.a.Title,
                        TitleMenu = a.b.Title,
                        Index = a.a.Index,
                        Status = a.a.Status,
                        Home = a.a.Home,
                        Hot = a.a.Hot,
                        Customer = a.a.Customer,
                        Authur = a.a.Authur,
                    }).OrderBy(a => a.Index).Skip(jtStartIndex).Take(jtPageSize).ToList();
                    //Return result to jTable
                    return Json(new {Result = "OK", Records = records, TotalRecordCount = listArticle.Count()});
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
            LoadData();
            ViewBag.Title = "Thêm bài viết";
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(EArticle model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(model.Alias))
                    {
                        model.Alias = StringHelper.ConvertToAlias(model.Alias);
                    }
                    try
                    {
                        var article = new Article
                        {
                            MenuID = model.MenuID,
                            Title = model.Title,
                            Alias = model.Alias,
                            Image = model.Image,
                            Description = model.Description,
                            Authur = model.Authur,
                            Content = model.Content,
                            Index = 0,
                            view = 0,
                            MetaTitle = string.IsNullOrEmpty(model.MetaTitle) ? model.Title : model.MetaTitle,
                            MetaDescription =
                                string.IsNullOrEmpty(model.MetaDescription) ? model.Title : model.Description,
                            Status = model.Status,
                            Home = model.Home,
                            Customer = model.Customer,
                            Hot = model.Hot,
                            Datetime = DateTime.Now,
                            //Link = model.Link
                        };

                        db.Articles.InsertOnSubmit(article);
                        db.SubmitChanges();
                        //Thêm tien ich
                        if (model.EAmenityItems != null)
                        {
                            foreach (EAmenityItem itemAmentity in model.EAmenityItems)
                            {
                                var articleAmenity = new ArticleAmenity
                                {
                                    AmentityID = itemAmentity.Id,
                                    ArticleID = article.ID,
                                };
                                db.ArticleAmenities.InsertOnSubmit(articleAmenity);
                            }
                            db.SubmitChanges();
                        }
                        TempData["Messages"] = "Thêm bài viết thành công";
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
            ViewBag.Title = "Cập nhật bài viết";
            using (var db = new MyDbDataContext())
            {
                Article detailArticle = db.Articles.FirstOrDefault(a => a.ID == id);

                if (detailArticle == null)
                {
                    TempData["Messages"] = "Bài viết không tồn tại";
                    return RedirectToAction("Index");
                }

                var artile = new EArticle
                {
                    ID = detailArticle.ID,
                    MenuID = detailArticle.MenuID,
                    Title = detailArticle.Title,
                    Alias = detailArticle.Alias,
                    Image = detailArticle.Image,
                    Description = detailArticle.Description,
                    Content = detailArticle.Content,
                    MetaTitle = detailArticle.MetaTitle,
                    MetaDescription = detailArticle.MetaDescription,
                    Status = detailArticle.Status,
                    Home = detailArticle.Home,
                    Customer = detailArticle.Customer,
                    Hot = detailArticle.Hot,
                    Authur = detailArticle.Authur,
                    //Link = detailArticle.Link,
                };
                artile.EAmenityItems = db.ArticleAmenities.Where(a => a.ArticleID == detailArticle.ID).Select(a => new EAmenityItem
                {
                    Id = a.ID
                }).ToList();
                LoadData();
                return View(artile);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(EArticle model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(model.Alias))
                    {
                        model.Alias = StringHelper.ConvertToAlias(model.Alias);
                    }
                    try
                    {
                        Article article = db.Articles.FirstOrDefault(b => b.ID == model.ID);
                        if (article != null)
                        {
                            article.MenuID = model.MenuID;
                            article.Title = model.Title;
                            article.Alias = model.Alias;
                            article.Image = model.Image;
                            article.Description = model.Description;
                            article.Content = model.Content;
                            article.MetaTitle = string.IsNullOrEmpty(model.MetaTitle) ? model.Title : model.MetaTitle;
                            article.MetaDescription = string.IsNullOrEmpty(model.MetaDescription)
                                ? model.Title
                                : model.MetaDescription;
                            article.Status = model.Status;
                            article.Home = model.Home;
                            article.Hot = model.Hot;
                            article.Customer = model.Customer;
                            article.Authur = model.Authur;
                            //article.Link = model.Link;
                            db.SubmitChanges();
                            db.ArticleAmenities.DeleteAllOnSubmit(db.ArticleAmenities.Where(a => a.ArticleID == article.ID).ToList());
                            //Thêm tien ich 
                            if (model.EAmenityItems != null)
                            {
                                foreach (EAmenityItem itemAmentity in model.EAmenityItems)
                                {
                                    var articleAmenity = new ArticleAmenity
                                    {
                                        AmentityID = itemAmentity.Id,
                                        ArticleID = article.ID,
                                    };
                                    db.ArticleAmenities.InsertOnSubmit(articleAmenity);
                                }
                                db.SubmitChanges();
                            }
                            
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
                    Article del = db.Articles.FirstOrDefault(c => c.ID == id);
                    if (del != null)
                    {
                        db.ArticleAmenities.DeleteAllOnSubmit(db.ArticleAmenities.Where(a => a.ArticleID == del.ID).ToList());
                        db.Articles.DeleteOnSubmit(del);
                        db.SubmitChanges();
                        return Json(new {Result = "OK", Message = "Xóa bài viết thành công"});
                    }
                    return Json(new {Result = "ERROR", Message = "Bài viết không tồn tại"});
                }
            }
            catch (Exception ex)
            {
                return Json(new {Result = "ERROR", ex.Message});
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
                    a =>
                        a.Type == SystemMenuType.Article ||
                        a.Type == SystemMenuType.RoomRate ||
                        a.Type == SystemMenuType.Service ||
                        a.Type == SystemMenuType.About ||
                        a.Type == SystemMenuType.Orther ||
                        a.Type == SystemMenuType.Restaurant ||
                        a.Type == SystemMenuType.Home && a.Location== SystemMenuLocation.MainMenu).ToList();

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
                Value = a.ID.ToString()
            }).ToList());

            ViewBag.ListMenu = listMenu;
        }
    }
}