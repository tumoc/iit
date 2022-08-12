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
    public class FeedBackController : Controller
    {
        //
        // GET: /Administrator/FeedBack/

        public ActionResult Index()
        {
            ViewBag.Messages = CommentController.Messages(TempData["Messages"]);
            ViewBag.Title = "Trang quản lý đánh giá";
            return View();
        }

        [HttpPost]
        public ActionResult UpdateIndex()
        {
            using (var db = new MyDbDataContext())
            {
                List<FeedBack> records = db.FeedBacks.Where(r => r.langaugeID == Request.Cookies["lang_client"].Value).ToList();
                foreach(FeedBack record in records)
                {
                    string itemFeedback = Request.Params[string.Format("Sort[{0}].Index", record.ID)];
                    int index;
                    int.TryParse(itemFeedback, out index);
                    record.Index = index;
                    db.SubmitChanges();
                }
                TempData["Messages"] = "Sắp xếp đánh giá thành công";
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
                    List<FeedBack> list = db.FeedBacks.Where(a => a.langaugeID == Request.Cookies["lang_client"].Value).ToList();
                    var records = list.Select(a => new
                    {
                        a.ID,
                        a.Name,
                        a.Star,
                        a.CreateDate,
                        a.Content,
                        a.Index
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
            ViewBag.Title = "Thêm đánh giá";
            var eFeedBack = new EFeedBack();
            var optionRoom = new List<SelectListItem>();
            using (var db = new MyDbDataContext())
            {
                List<Room> rooms = db.Rooms.Where(a => a.Status && a.LanguageID == Request.Cookies["LanguageID"].Value).ToList();
                foreach (var item in rooms)
                {
                    optionRoom.Add(new SelectListItem
                    {
                        Text = item.Title,
                        Value = item.ID.ToString()
                    });
                }
            }
            ViewBag.optionRoom = optionRoom;
            return View(eFeedBack);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(EFeedBack model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var feedBack = new FeedBack
                        {
                            langaugeID = Request.Cookies["lang_client"].Value,
                            Avatar = model.Avatar,
                            Star = model.Star,
                            Name = model.Name,
                            RoomId = model.RoomID,
                            Index = 0,
                            CreateDate = DateTime.Now,
                            Content = model.Content,
                        };

                        db.FeedBacks.InsertOnSubmit(feedBack);
                        db.SubmitChanges();

                        TempData["Messages"] = "Thêm đánh giá thành công.";
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
                FeedBack detailFeedBack = db.FeedBacks.FirstOrDefault(a => a.ID == id);
                if (detailFeedBack == null)
                {
                    TempData["Messages"] = "Đánh giá không tồn tại";
                    return RedirectToAction("Index");
                }
                var optionRoom = new List<SelectListItem>();
                    List<Room> rooms = db.Rooms.Where(a => a.Status && a.LanguageID == Request.Cookies["LanguageID"].Value).ToList();
                    foreach (var item in rooms)
                    {
                        optionRoom.Add(new SelectListItem
                        {
                            Text = item.Title,
                            Value = item.ID.ToString()
                        });
                    }
                ViewBag.optionRoom = optionRoom;
                ViewBag.Title = "Sửa đánh giá";
                var feedBack = new EFeedBack
                {
                    ID = detailFeedBack.ID,
                    Name = detailFeedBack.Name,
                    Avatar = detailFeedBack.Avatar,
                    Star = detailFeedBack.Star,
                    RoomID = (int)detailFeedBack.RoomId,
                    Index = detailFeedBack.Index,
                    Content = detailFeedBack.Content,
                    CreateDate = DateTime.Now,
                };
                return View(feedBack);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(EFeedBack model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        FeedBack feedBack = db.FeedBacks.FirstOrDefault(b => b.ID == model.ID);
                        if (feedBack != null)
                        {
                            feedBack.Name = model.Name;
                            feedBack.Avatar = model.Avatar;
                            feedBack.Star = model.Star;
                            feedBack.Content = model.Content;
                            feedBack.RoomId = model.RoomID;
                            db.SubmitChanges();
                            TempData["Messages"] = "Sửa đánh giá thành công";
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
                    FeedBack del = db.FeedBacks.FirstOrDefault(c => c.ID == id);
                    if (del != null)
                    {
                        db.FeedBacks.DeleteOnSubmit(del);
                        db.SubmitChanges();
                        return Json(new { Result = "OK", Message = "Xóa đánh giá thành công" });
                    }
                    return Json(new { Result = "ERROR", Message = "Đánh giá không tồn tại" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }

    }
}
