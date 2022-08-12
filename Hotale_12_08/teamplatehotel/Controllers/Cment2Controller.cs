using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectLibrary.Config;
using ProjectLibrary.Database;
using TeamplateHotel.Areas.Administrator.EntityModel;
using TeamplateHotel.Models;

namespace TeamplateHotel.Controllers
{
    public class Cment2Controller : Controller
    {
        [HttpPost]
        public JsonResult Send(EComment model)
        {
            using (var db = new MyDbDataContext())
            {
                string s = Request.Cookies["lang_client"].Value;
                if (ModelState.IsValid)
                {
                    try
                    {
                        var cmt = new Comment
                        {
                            Name = model.Name,
                            Email = model.Email,
                            ArticleID = model.ArticleID,
                            Website = model.Website,
                            Comment1 = model.Comment,
                            CreateDate = DateTime.Now,
                            languageID = Request.Cookies["lang_client"].Value,
                            //Link = model.Link
                        };

                        db.Comments.InsertOnSubmit(cmt);
                        db.SubmitChanges();
                        return Json(new { success = true });
                    }
                    catch (Exception exception)
                    {
                        ViewBag.Messages = "Error: " + exception.Message;
                        return Json(new { success = false });
                    }
                }
                return Json(new { success = false });
            }
        }
    }
}