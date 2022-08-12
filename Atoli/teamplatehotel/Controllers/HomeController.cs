using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectLibrary.Config;
using ProjectLibrary.Database;
using TeamplateHotel.Models;
using PagedList;

namespace TeamplateHotel.Controllers
{
    public class HomeController : BasicController
    {
        [HttpGet]
        public ActionResult Index(object aliasMenuSub, object idSub, object aliasSub, Search search , int? page, int? pageSize)
        {
            var db = new MyDbDataContext();
            Hotel hotel = CommentController.DetailHotel(Request.Cookies["LanguageID"].Value);
            ViewBag.MetaTitle = hotel.MetaTitle;
            ViewBag.MetaDesctiption = hotel.MetaDescription;
            
            if (aliasMenuSub.ToString() == "System.Object")
            {
                return View("Index");
            }
            if (aliasMenuSub.ToString() == "SelectLanguge")
            {
                Language language = db.Languages.FirstOrDefault(a =>a.ID == idSub.ToString());
                if (language == null)
                {
                    language = db.Languages.FirstOrDefault();
                }
                HttpCookie langCookie = Request.Cookies["LanguageID"];
                langCookie.Value = language.ID;
                langCookie.Expires = DateTime.Now.AddDays(10);
                HttpContext.Response.Cookies.Add(langCookie);
                return Redirect("/");
            }

            // xác định menu => tìm ra Kiểu hiển thị của menu
            Menu menu = db.Menus.FirstOrDefault(a => a.Alias == aliasMenuSub.ToString());
            if (menu == null)
            {
                return View("404");
            }
            //Seo
            ViewBag.MetaTitle = menu.MetaTitle;
            ViewBag.MetaDesctiption = menu.MetaDescription;
            ViewBag.Menu = menu;

            switch (menu.Type)
            {
                case SystemMenuType.Article:
                    goto Trangbaiviet;
                case SystemMenuType.RoomRate:
                    goto TrangRoom; 
                case SystemMenuType.Service:
                    goto Service;
                case SystemMenuType.RoomSearch:
                    goto RoomSearch; 
                case SystemMenuType.Restaurant:
                    return View("Restautant");
                case SystemMenuType.FQAS:
                    return View("FQAS");
                case SystemMenuType.Orther:
                    return View("Orther");
                case SystemMenuType.About:
                    return View("About");
                case SystemMenuType.Booking:
                    return RedirectToAction("MakeReservation", "Booking");
                case SystemMenuType.Contact:
                    Random random = new Random();
                    int iNumber = random.Next(10000, 99999);
                    Session["Captcha"] = iNumber.ToString();
                    return View("Contact");
                case SystemMenuType.Gallery:
                    return View("Gallery");
                default:
                    return View("Index");
            }

            #region "Trang bài viết"
            Trangbaiviet:
            if (idSub.ToString() != "System.Object")
            {
                int idArticle;
                int.TryParse(idSub.ToString(), out idArticle);
                DetailArticle detailArticle = CommentController.Detail_Article(idArticle);
                Article article = db.Articles.FirstOrDefault(b => b.ID == idArticle);
                CommentController.Plus(idArticle);
                ViewBag.MetaTitle = detailArticle.Article.MetaTitle;
                ViewBag.MetaDesctiption = detailArticle.Article.MetaDescription;
                ViewBag.OGImage = detailArticle.Article.Image;
                return View("Article/DetailArticle", detailArticle);
            }
            //Danh sách bài viết
            List<Article> articles = CommentController.GetArticles(menu.ID);
            if (articles.Count == 1)
            {
                DetailArticle detailArticle = CommentController.Detail_Article(articles[0].ID);
                Article article = db.Articles.FirstOrDefault(b => b.ID == articles[0].ID);
                CommentController.Plus(article.ID);
                ViewBag.MetaTitle = detailArticle.Article.MetaTitle;
                ViewBag.MetaDesctiption = detailArticle.Article.MetaDescription;
                ViewBag.OGImage = detailArticle.Article.Image;
                return View("Article/DetailArticle", detailArticle);
            }
            int pagenumber1 = page ?? 1;
            int pagesize1 = pageSize ?? 6;
            IPagedList<Article> list1 = articles.ToPagedList(pagenumber1, pagesize1);
            return View("Article/ListArticle", list1);

        #endregion

        //Trường hợp: Room
        #region "Kiểu Room & rate"
        TrangRoom:
            if (idSub.ToString() != "System.Object")
            {
                int id;
                int.TryParse(idSub.ToString(), out id);
                //Kiểm tra xem alias truyền đến có phải là 1 bài viết không
                var articleRoom = db.Articles.FirstOrDefault(a => a.ID == id);
                if (articleRoom != null)
                {
                    ViewBag.MetaTitle = articleRoom.MetaTitle;
                    ViewBag.MetaDesctiption = articleRoom.MetaDescription;
                    return View("Article/DetailArticle", CommentController.Detail_Article(id));
                }
                //chi tiết Room
                DetailRoom detailRoom = CommentController.Detail_Room(id, menu.ID);
                ViewBag.MetaTitle = detailRoom.Room.MetaTitle;
                ViewBag.MetaDesctiption = detailRoom.Room.MetaDescription;
                
                return View("Room/DetailRoom", detailRoom);
            }
                //Lấy bài viết RoomRate
                var articlrByRoomRate = db.Articles.FirstOrDefault(a => a.MenuID == menu.ID);
                if (articlrByRoomRate != null)
                {
                    articlrByRoomRate.MenuAlias = articlrByRoomRate.Menu.Alias;
                }
                ViewBag.ArticleByRoomRate = articlrByRoomRate;
                int pagenumber = page ?? 1;
                int pagesize = pageSize ?? 6;
                IPagedList<Room> list = CommentController.GetRooms(menu.ID).ToPagedList(pagenumber, pagesize);
                return View("Room/ListRoom",list);
        #endregion
        //Trường hợp: Room
        #region "Kiểu RoomSearch"
        RoomSearch:
            List<int> sqm = new List<int>() { 40, 50, 60, 80 };
            ViewBag.RoomSpace = sqm;
            List<Amenity> op = CommentController.GetAmetities(Request.Cookies["LanguageID"].Value);
            ViewBag.Amenity = op;
            return View("RoomSearch", CommentController.ListRooms(Request.Cookies["LanguageID"].Value));
            #endregion
            //Trang Service
            #region "Trang Service"
            Service:
            if (idSub.ToString() != "System.Object")
            {
                int idArticle;
                int.TryParse(idSub.ToString(), out idArticle);
                DetailService detailService = CommentController.Detail_Service(idArticle);
                ViewBag.MetaTitle = detailService.Service.MetaTitle;
                ViewBag.MetaDesctiption = detailService.Service.MetaDescription;
                return View("Service/DetailService", detailService);
            }
            //Danh sách bài viết
            List<Service> services = CommentController.GetServices(menu.ID);
            if (services.Count == 1)
            {
                DetailService detailService = CommentController.Detail_Service(services[0].ID);
                ViewBag.MetaTitle = detailService.Service.MetaTitle;
                ViewBag.MetaDesctiption = detailService.Service.MetaDescription;
                return View("Service/DetailService", detailService);
            }
            int pagenumber2 = page ?? 1;
            int pagesize2 = pageSize ?? 6;
            IPagedList<Service> list2 = services.ToPagedList(pagenumber2, pagesize2);
            return View("Service/ListService",list2);
            #endregion
        }
    }
}