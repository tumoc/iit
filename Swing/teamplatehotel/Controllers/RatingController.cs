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
    public class RatingController : Controller
    {
        [HttpPost]
        public JsonResult Send(EFeedBack model)
        {
            using (var db = new MyDbDataContext())
            {
                    try
                    {
                        var feedBack = new FeedBack
                        {
                            RoomId = model.RoomID,
                            Name = model.Name,
                            Email = model.Email,
                            Avatar= model.Avatar,
                            Tel = model.Tel,
                            Star = model.Star,
                            Content = model.Content,
                            CreateDate = DateTime.Now,
                            Index = 0,
                            langaugeID = Request.Cookies["lang_client"].Value,
                            //Link = model.Link
                        };

                        db.FeedBacks.InsertOnSubmit(feedBack);
                        db.SubmitChanges();
                        return Json(new { success = true});
                    }
                    catch (Exception exception)
                    {
                        ViewBag.Messages = "Error: " + exception.Message;
                        return Json(new { success = false });
                    }
            }
        }

    }
}
