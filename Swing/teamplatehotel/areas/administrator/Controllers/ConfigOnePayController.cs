//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.Mvc;
//using ProjectLibrary.Database;
//using TeamplateHotel.Areas.Administrator.EntityModel;

//namespace TeamplateHotel.Areas.Administrator.Controllers
//{
//    public class ConfigOnePayController : BaseController
//    {
//        public ActionResult Index()
//        {
//            ViewBag.Title = "Trang config Onepay";
//            ViewBag.Messages = CommentController.Messages(TempData["Messages"]);
//            return View();
//        }

//        [HttpPost]
//        public JsonResult List(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null )
//        {
//            try
//            {
//                using (var db = new MyDbDataContext())
//                {

//                    List<EOnepay> list = db.PaymentConfigOnePays.Select(a => new EOnepay()
//                    {
//                        PaymentConfigOnePayID = a.PaymentConfigOnePayID,
//                        MerchantId = a.MerchantId,
//                        MethodName = a.MethodName,
//                        AccessCode = a.AccessCode,
//                        Hashcode = a.Hashcode,
//                        WebSite = a.WebSite,
//                        NoiDia =  a.NoiDia,
//                        QuocTe = a.QuocTe,

//                    }).Skip(jtStartIndex).Take(jtPageSize).ToList();
//                    //Return result to jTable
//                    return Json(new { Result = "OK", Records = list, TotalRecordCount = list.Count });
//                }
//            }
//            catch (Exception ex)
//            {
//                return Json(new { Result = "ERROR", message = ex.Message });
//            }
//        }
        

//        //[HttpGet]
//        //public ActionResult Config()
//        //{
//        //    ViewBag.Title = "Thêm Payment Config OnePay";
//        //    using (var db = new MyDbDataContext())
//        //    {
//        //        PaymentConfigOnePay Config = db.PaymentConfigOnePays.FirstOrDefault();
//        //        return View(Config);
//        //    }
//        //}
//        [HttpPost]
//        [ValidateInput(false)]
//        public JsonResult Create(EOnepay model)
//        {
//            using (var db = new MyDbDataContext())
//            {
//                if (ModelState.IsValid)
//                {
//                    try
//                    {
//                        var insert = new PaymentConfigOnePay();
//                        {
//                            insert.MerchantId = model.MerchantId;
//                            insert.AccessCode = model.AccessCode;
//                            insert.Hashcode = model.Hashcode;
//                            insert.MethodName = model.MethodName;
//                            insert.WebSite = model.WebSite;
//                        };

//                        db.PaymentConfigOnePays.InsertOnSubmit(insert);
//                        db.SubmitChanges();
//                        string message = "Thêm Payment Config OnePay thành công";
 
//                        return Json(new { Result = "OK", Message = message, Record = model });
//                    }
//                    catch (Exception exception)
//                    {
//                        return Json(new { Result = "Error", Message = "Error: " + exception.Message });
//                    }
//                }
//                return
//                    Json(
//                        new
//                        {
//                            Result = " Error",
//                            Errors = ModelState.Errors(),
//                            Message = "Dữ liệu đầu vào không đúng định dang"
//                        }, JsonRequestBehavior.AllowGet);
//            }
//        }

//        [HttpPost]
//        [ValidateInput(false)]
//        public JsonResult Edit(EOnepay model)
//        {
//            using (var db = new MyDbDataContext())
//            {
//                if (ModelState.IsValid)
//                {
//                    try
//                    {
//                        PaymentConfigOnePay edit = db.PaymentConfigOnePays.FirstOrDefault(b => b.PaymentConfigOnePayID == model.PaymentConfigOnePayID);
//                        //string imageSmall = "/Files/_thumbs" + model.Image.Substring(6, model.Image.Length - 6);
//                        if (edit != null)
//                        {
//                            edit.MerchantId = model.MerchantId;
//                            edit.MethodName = model.MethodName;
//                            edit.AccessCode = model.AccessCode;
//                            edit.Hashcode = model.Hashcode;
//                            edit.WebSite = model.WebSite;
//                            db.SubmitChanges();

//                            string message = "Chỉnh sửa Payment Config OnePay thành công";
//                            return Json(new { Result = "OK", Message = message, Record = model });
//                        }
//                        return Json(new { Result = "ERROR", Message = "Không tồn tại" });
//                    }
//                    catch (Exception exception)
//                    {
//                        return Json(new { Result = "Error", Message = "Error: " + exception.Message });
//                    }
//                }
//                return
//                    Json(
//                        new
//                        {
//                            Result = " Error",
//                            Errors = ModelState.Errors(),
//                            Message = "Dữ liệu đầu vào không đúng định dạng"
//                        }, JsonRequestBehavior.AllowGet);
//            }
//        }

//        [HttpPost]
//        public JsonResult Delete(int id)
//        {
//            try
//            {
//                using (var db = new MyDbDataContext())
//                {
//                    FeedBack del = db.FeedBacks.FirstOrDefault(c => c.ID == id);
//                    if (del != null)
//                    {
//                        db.FeedBacks.DeleteOnSubmit(del);
//                        db.SubmitChanges();
//                        return Json(new { Result = "OK", Message = "Xóa thành công" });
//                    }
//                    return Json(new { Result = "ERROR", Message = "Không tồn tại" });
//                }
//            }
//            catch (Exception ex)
//            {
//                return Json(new { Result = "Error", Message = "Error: " + ex.Message });
//            }
//        }


//        //[HttpPost]
//        //[ValidateInput(false)]
//        //public ActionResult UpdateConfig(PaymentConfigOnePay model)
//        //{
//        //    using (var db = new MyDbDataContext())
//        //    {
//        //        if (ModelState.IsValid)
//        //        {
//        //            try
//        //            {
//        //                PaymentConfigOnePay Config = db.PaymentConfigOnePays.FirstOrDefault();
//        //                if (Config == null)
//        //                {
//        //                    Config = new PaymentConfigOnePay();
//        //                    db.PaymentConfigOnePays.InsertOnSubmit(Config);
//        //                    db.SubmitChanges();
//        //                    ViewBag.Messages = "Thêm Payment Config OnePay thành công";
//        //                    return RedirectToAction("Config");
//        //                }
//        //                Config.AccessCode = model.AccessCode;
//        //                Config.Hashcode = model.Hashcode;
//        //                Config.MerchantId = model.MerchantId;
//        //                Config.WebSite = model.WebSite;

//        //                db.SubmitChanges();
//        //                ViewBag.Messages = "Chỉnh sửa Payment Config OnePay thành công";
//        //                return RedirectToAction("Config");
//        //            }
//        //            catch (Exception exception)
//        //            {
//        //                ViewBag.Messages = "Lỗi: " + exception.Message;
//        //                return View();
//        //            }
//        //        }
//        //        return View(model);
//        //    }
//        //}
//    }
//}