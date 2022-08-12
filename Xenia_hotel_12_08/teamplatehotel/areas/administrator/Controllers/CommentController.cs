﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectLibrary.Config;
using ProjectLibrary.Database;
using ProjectLibrary.Security;
using TeamplateHotel.Models;

namespace TeamplateHotel.Areas.Administrator.Controllers
{
    public class CommentController : BaseController
    {
        //////////////////////// Room ///////////////////////////////////
        public static List<SelectListItem> ListRoom()
        {
            //check logged
            using (var db = new MyDbDataContext())
            {
                var listRoom = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Text = "Lựa chọn phòng",
                        Value = "0"
                    }
                };
                listRoom.AddRange(
                    db.Rooms.Select(
                        a => new SelectListItem {Text = a.Title, Value = a.ID.ToString(CultureInfo.InvariantCulture)})
                        .ToList());
                return listRoom;
            }
        }
        //Danh sách ngôn ngữ
        public static List<Language> ListLanguage()
        {
            using (var db = new MyDbDataContext())
            {
                return db.Languages.ToList();
            }
        }
        //Ngôn ngữ hiện tại
        public static string CurentLanguage(string languageId)
        {
            using (var db = new MyDbDataContext())
            {
                var firstOrDefault = db.Languages.FirstOrDefault(a=>a.ID == languageId);
                if (firstOrDefault != null)
                    return firstOrDefault.Name ?? "";
                else
                {
                    return "";
                }
            }
        }
        //lấy họ tên người đăng nhập
        public static string GetFullName(string cookie)
        {
            using (var db = new MyDbDataContext())
            {
                string cookieClient = cookie;
                string deCodecookieClient = CryptorEngine.Decrypt(cookieClient, true);
                string userName = deCodecookieClient.Substring(0, deCodecookieClient.IndexOf("||"));
                return db.Users.FirstOrDefault(a => a.UserName == userName).FullName;
            }
        }
        //lấy danh sách menu theo theo kiểu menu
        [HttpPost]
        public JsonResult GetListMenu(int typeMenu, string languageID)
        {
            //check logged
            var listMenu = new List<Menu>();

            listMenu = MenuController.GetListMenu(SystemMenuLocation.ListLocationMenu().ToList()[0].LocationId, languageID);
            listMenu = listMenu.Where(a => a.Type == typeMenu).ToList();

            foreach (Menu menu in listMenu)
            {
                string titleMenu = "";
                for (int i = 1; i <= menu.Level; i++)
                {
                    titleMenu += "|--";
                }
                menu.Title = titleMenu + menu.Title;
            }
            return Json(new {Result = "OK", ListMenu = listMenu.Select(a => new {MenuId = a.ID, a.Title}).ToList()});
        }
        public static List<Amenity> GetAmetities(string lan)
        {
            using (var db = new MyDbDataContext())
            {
                List<Amenity> amenities = db.Amenities.Where(a => a.Status && a.languageID == lan).ToList();
                return amenities;
            }
        }

        public static List<int> GetListAmenityID(int id)
        {
            using (var db = new MyDbDataContext())
            {
                List<int> amenities = db.RoomAmenities.Where(a => a.RoomID == id).Select(a => (int)a.AmenityID).ToList();
                return amenities;
            }
        }
        public static List<int> ListAmenityID(int id)
        {
            using (var db = new MyDbDataContext())
            {
                List<int> amenities = db.ArticleAmenities.Where(a => a.ArticleID == id).Select(a => (int)a.AmenityID).ToList();
                return amenities;
            }
        }
        //Show messages
        public static string Messages(object messages)
        {
            if (messages != null)
                return messages.ToString();
            return "";
        }
    }
}