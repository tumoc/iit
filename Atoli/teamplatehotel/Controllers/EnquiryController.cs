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
    public class EnquiryController : Controller
    {
        [HttpPost]
        public JsonResult Create(EEnquiry model)
        {
            using (var db = new MyDbDataContext())
            {
                
                if (ModelState.IsValid)
                {
                    try
                    {
                        var cmt = new Enquiry
                        {
                            Name = model.Name,
                            Email = model.Email,
                            Enquiry1 = model.Enquiry,
                            CreateDate = DateTime.Now,
                            //Link = model.Link
                        };

                        db.Enquiries.InsertOnSubmit(cmt);
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