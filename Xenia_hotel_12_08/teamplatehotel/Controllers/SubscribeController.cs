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
    public class SubscribeController : Controller
    {
        [HttpPost]
        public JsonResult Send(ESubscribe model)
        {
            using (var db = new MyDbDataContext())
            {

                if (ModelState.IsValid)
                {
                    try
                    {
                        var sb = new Subscribe
                        {
                            CreateDate = DateTime.Now,
                            Email = model.Email
                        };
                        var Sub = db.Subscribes.Where(a => a.Email == model.Email).FirstOrDefault();
                        if (Sub == null)
                        {
                            db.Subscribes.InsertOnSubmit(sb);
                            db.SubmitChanges();
                            return Json(new { success = true, Message = "Subscribe Successed!" });
                        }
                    }
                    catch (Exception exception)
                    {
                        ViewBag.Messages = "Error: " + exception.Message;
                        return Json(new { success = false, Message = "Email đã tồn tại!" });
                    }
                }
                return Json(new { success = false, Message = "Email đã tồn tại!" });
            }
        }

    }
}
