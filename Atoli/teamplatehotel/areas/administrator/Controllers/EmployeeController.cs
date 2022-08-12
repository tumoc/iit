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
    public class EmployeeController : Controller
    {
        //
        // GET: /Administrator/Employee/
        public ActionResult Index()
        {
            ViewBag.Messages = CommentController.Messages(TempData["Messages"]);
            ViewBag.Title = "Trang quản lý nhân viên";
            return View();
        }

        [HttpPost]
        public ActionResult UpdateIndex()
        {
            using (var db = new MyDbDataContext())
            {
                List<Employee> records = db.Employees.Where(r => r.ID != 0).ToList();
                foreach (Employee record in records)
                {
                    string itemEmployee = Request.Params[string.Format("Sort[{0}].Index", record.ID)];
                    int index;
                    int.TryParse(itemEmployee, out index);
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
                    List<Employee> list = db.Employees.Where(a => a.ID != 0 && a.LanguageID == Request.Cookies["lang_client"].Value).ToList();
                    var records = list.Select(a => new
                    {
                        a.ID,
                        a.Name,
                        a.Position,
                        a.Index,
                        a.Image,
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
            ViewBag.Title = "Thêm nhân viên";
            var eEmployee = new EEmployee();
            return View(eEmployee);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(EEmployee model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var employee = new Employee
                        {
                            LanguageID = Request.Cookies["lang_client"].Value,
                            Name = model.Name,
                            Image = model.Image,
                            Index = 0,
                            Position = model.Position,
                            facebook = model.facebook,
                            twitter = model.twitter,
                            instagram = model.instagram,
                            printerest = model.printerest,
                        };

                        db.Employees.InsertOnSubmit(employee);
                        db.SubmitChanges();

                        TempData["Messages"] = "Thêm thành công.";
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
                Employee detailEmployee = db.Employees.FirstOrDefault(a => a.ID == id);
                if (detailEmployee == null)
                {
                    TempData["Messages"] = "nhân viên không tồn tại";
                    return RedirectToAction("Index");
                }
                ViewBag.Title = "Sửa tiện ích";
                var employee = new EEmployee
                {
                    ID = detailEmployee.ID,
                    Name = detailEmployee.Name,
                    Image = detailEmployee.Image,
                    Index = detailEmployee.Index,
                    Position = detailEmployee.Position,
                    facebook = detailEmployee.facebook,
                    twitter = detailEmployee.twitter,
                    instagram = detailEmployee.instagram,
                    printerest = detailEmployee.printerest,
                };
                return View(employee);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(EEmployee model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        Employee employee = db.Employees.FirstOrDefault(b => b.ID == model.ID);
                        if (employee != null)
                        {
                            employee.Name = model.Name;
                            employee.Image = model.Image;
                            employee.Position = model.Position;
                            employee.facebook = model.facebook;
                            employee.twitter = model.twitter;   
                            employee.instagram = model.instagram;   
                            employee.printerest = model.printerest;

                            db.SubmitChanges();

                            TempData["Messages"] = "Sửa thành công";
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
                    Employee del = db.Employees.FirstOrDefault(c => c.ID == id);
                    if (del != null)
                    {

                        db.Employees.DeleteOnSubmit(del);
                        db.SubmitChanges();
                        return Json(new { Result = "OK", Message = "Xóa thành công" });
                    }
                    return Json(new { Result = "ERROR", Message = "Nhân viên không tồn tại" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }

    }
}
