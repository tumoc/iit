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
    public class QuestionController : Controller
    {
        //
        // GET: /Administrator/Question/
        public ActionResult Index()
        {
            ViewBag.Messages = CommentController.Messages(TempData["Messages"]);
            ViewBag.Title = "Trang câu hỏi";
            return View();
        }

        [HttpPost]
        public ActionResult UpdateIndex()
        {
            using (var db = new MyDbDataContext())
            {
                var records =
                    db.Questions.Where(a => a.LanguageID == Request.Cookies["lang_client"].Value).ToList();
                foreach (var record in records)
                {
                    string itemAdv = Request.Params[string.Format("Sort[{0}].Index", record.ID)];
                    int index;
                    int.TryParse(itemAdv, out index);
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
                    var listArticle =
                        db.Questions.Where(a => a.LanguageID == Request.Cookies["lang_client"].Value);
                    List<ShowArticle> records = listArticle.Select(a => new ShowArticle
                    {
                        ID = a.ID,
                        Title = a.Title,
                        Index = a.Index,
                        Status = a.Status,
                        Home = a.Home,
                    }).OrderBy(a => a.Index).Skip(jtStartIndex).Take(jtPageSize).ToList();
                    //Return result to jTable
                    return Json(new { Result = "OK", Records = records, TotalRecordCount = listArticle.Count() });
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
            ViewBag.Title = "Thêm câu hỏi";
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(EQuestion model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var article = new Question
                        {
                            Title = model.Title,
                            Content = model.Content,
                            Index = 0,
                            Status = model.Status,
                            Home = model.Home,
                            LanguageID = Request.Cookies["lang_client"].Value,
                            //Link = model.Link
                        };
                        db.Questions.InsertOnSubmit(article);
                        db.SubmitChanges();

                        TempData["Messages"] = "Thêm thành công";
                        return RedirectToAction("Index");
                    }
                    catch (Exception exception)
                    {
                        ViewBag.Messages = "Error: " + exception.Message;
                        return View();
                    }
                }
                return View();
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.Title = "Cập nhật câu hỏi";
            using (var db = new MyDbDataContext())
            {
                Question detailArticle = db.Questions.FirstOrDefault(a => a.ID == id);

                if (detailArticle == null)
                {
                    TempData["Messages"] = "Câu hỏi không tồn tại";
                    return RedirectToAction("Index");
                }

                var artile = new EQuestion
                {
                    ID = detailArticle.ID,
                    Title = detailArticle.Title,
                    Content = detailArticle.Content,
                    Status = detailArticle.Status,
                    Home = detailArticle.Home,
                };
                return View(artile);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(EQuestion model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        Question article = db.Questions.FirstOrDefault(b => b.ID == model.ID);
                        if (article != null)
                        {
                            article.Title = model.Title;
                            article.Content = model.Content;
                            article.Status = model.Status;
                            article.Home = model.Home;
                            db.SubmitChanges();
                            TempData["Messages"] = "Cập nhật thành công";
                            return RedirectToAction("Index");
                        }
                    }
                    catch (Exception exception)
                    {
                        ViewBag.Messages = "Lỗi: " + exception.Message;
                        return View();
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
                    Question del = db.Questions.FirstOrDefault(c => c.ID == id);
                    if (del != null)
                    {
                        db.Questions.DeleteOnSubmit(del);
                        db.SubmitChanges();
                        return Json(new { Result = "OK", Message = "Xóa câu hỏi thành công" });
                    }
                    return Json(new { Result = "ERROR", Message = "Câu hỏi không tồn tại" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }

    }
}
