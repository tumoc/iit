using System;
using System.Collections.Generic;
using System.Linq;
using ProjectLibrary.Config;
using ProjectLibrary.Database;
using TeamplateHotel.Models;

namespace TeamplateHotel.Controllers
{
    public class CommentController : BasicController
    {

        //danh sach ngon ngu
        public static List<Language> GetLanguages()
        {
            using (var db = new MyDbDataContext())
            {
                List<Language> languages = db.Languages.ToList();
                return languages;
            }
        }
        //Chi tiết khách sạn
        public static Hotel DetailHotel(string languageKey)
        {
            using (var db = new MyDbDataContext())
            {
                var hotel =
                    db.Hotels.FirstOrDefault(a => a.LanguageID == languageKey) ??
                    new Hotel();
                return hotel;
            }
        }
        //Danh sách Main menu
        public static List<Menu> GetMainMenus(string languageKey)
        {
            using (var db = new MyDbDataContext())
            {
                List<Menu> menus = db.Menus.Where(a => a.Status && a.Location == SystemMenuLocation.MainMenu &&
                                                       a.LanguageID == languageKey).OrderBy(a => a.Index).ToList();
                return menus;
            }
        }
        //Danh sách Second menu
        public static List<Menu> GetSecondMenus(string languageKey)
        {
            using (var db = new MyDbDataContext())
            {
                List<Menu> menufooter = db.Menus.Where(a => a.Status && a.Location == SystemMenuLocation.SecondMenu &&
                                                       a.LanguageID == languageKey).ToList();
                return menufooter;
            }
        }
        public static string PriceNet(int room)
        {
            using (var db = new MyDbDataContext())
            {
                string pricenet = db.Rooms.Where(a => a.ID == room).Select(a => a.PriceNet).FirstOrDefault().ToString();
                return pricenet;
            }
        }

        //Danh sách Second menu
        public static List<Gallery> Gallery(string languageKey)
        {
            using (var db = new MyDbDataContext())
            {
                List<Gallery> galleries = db.Galleries.OrderBy(a => a.Index).ToList();
                return galleries;
            }
        }
        //get plugin
        public static Plugin GetPluigPlugin()
        {
            using (var db = new MyDbDataContext())
            {
                return db.Plugins.FirstOrDefault() ?? new Plugin();
            }
        }
        //Danh sach slider
        public static List<Slider> GetListSlider(string languageKey, int menuId = 0)
        {
            using (var db = new MyDbDataContext())
            {
                List<Slider> sliders = db.Sliders.Where(a => a.LanguageID == languageKey && a.Status).ToList();
                List<Slider> sliderIsChoise = new List<Slider>();

                //lấy banner theo menu
                var menu = db.Menus.FirstOrDefault(a => a.ID == menuId);
                if (menu != null)
                {
                    foreach (var slider in sliders)
                    {
                        if (slider.MenuIDs.Length > 0)
                        {
                            int[] menuIds =
                                slider.MenuIDs.Substring(0, slider.MenuIDs.Length - 1).Split(',').Select(
                                    n => Convert.ToInt32(n)).ToArray();

                            if (menuIds.Contains(menu.ID))
                            {
                                sliderIsChoise.Add(slider);
                            }
                        }
                    }
                }
                else
                {
                    //lấy menu theo trang chủ
                    var menuHome = db.Menus.FirstOrDefault(a => a.Type == SystemMenuType.Home && a.LanguageID == languageKey);
                    if (menuHome != null)
                    {
                        foreach (var slider in sliders)
                        {
                            if (slider.MenuIDs.Length > 0)
                            {
                                int[] menuIds =
                           slider.MenuIDs.Substring(0, slider.MenuIDs.Length - 1).Split(',').Select(
                               n => Convert.ToInt32(n)).ToArray();

                                if (menuIds.Contains(menuHome.ID))
                                {
                                    sliderIsChoise.Add(slider);
                                }
                            }
                        }
                    }

                }
                if (sliderIsChoise.Count == 0)
                {
                    sliderIsChoise = sliders.Where(a => string.IsNullOrEmpty(a.MenuIDs)).ToList();
                }
                return sliderIsChoise;
                //lấy menu hiển thị tất cả
            }
        }

        public static Slider GetBaner(int menuid)
        {
            using (var db = new MyDbDataContext())
            {
                Slider baner = db.Sliders.Where(a => a.Status && a.MenuIDs == menuid.ToString()).FirstOrDefault();
                return baner;
            }
        }
        //Danh sach quang cao
        public static List<Advertising> GetAdvertisings(string lan)
        {
            using (var db = new MyDbDataContext())
            {
                List<Advertising> advertisings = db.Advertisings.Where(a => a.Status && a.LanguageID==lan).ToList();
                return advertisings;
            }
        }
        public static List<ShowObject> GetRoomAmetities(int id)
        {
            using (var db = new MyDbDataContext())
            {
                List<ShowObject> amenities = db.Amenities.Where(a => a.Status)
                    .Join(db.RoomAmenities.Where(a => a.RoomID == id), a => a.ID, b => b.AmenityID, (a, b) => new ShowObject
                    {
                        ID = a.ID,
                        Title = a.Title,
                        Image = a.Image,
                    }).ToList();
                return amenities;
            }
        }
        public static List<ShowObject> GetArticleAmetities(int id)
        {
            using (var db = new MyDbDataContext())
            {
                List<ShowObject> amenities = db.Amenities.Where(a => a.Status)
                    .Join(db.ArticleAmenities.Where(a => a.ArticleID == id), a => a.ID, b => b.AmenityID, (a, b) => new ShowObject
                    {
                        ID = a.ID,
                        Title = a.Title,
                        Image = a.Image,
                        Description= a.Description,
                    }).ToList();
                return amenities;
            }
        }
        //Danh sách bài viết theo chuyên mục
        public static List<Article> GetArticles(int menuId)
        {
            using (var db = new MyDbDataContext())
            {
                List<Article> articles = db.Articles.Where(a => a.MenuID == menuId && a.Status).OrderBy(a => a.Index).ToList();
                foreach (var article in articles)
                {
                    article.MenuAlias = article.Menu.Alias;
                }
                return articles;
            }
        }
        public static List<Wine> GetWines(string lan)
        {
            using (var db = new MyDbDataContext())
            {
                List<Wine> wines = db.Wines.Where(a => a.Status && a.LanguageID==lan ).OrderBy(a => a.Index).ToList();
                return wines;
            }
        }
        public static List<Article> GetCustomerArticles(int menuId)
        {
            using (var db = new MyDbDataContext())
            {
                List<Article> articles = db.Articles.Where(a => a.MenuID == menuId && a.Status && a.Customer).OrderBy(a => a.Index).ToList();
                foreach (var article in articles)
                {
                    article.MenuAlias = article.Menu.Alias;
                }
                return articles;
            }
        }
        public static List<Article> RecentArticles(int menuId)
        {
            using (var db = new MyDbDataContext())
            {
                List<Article> articles = db.Articles.Where(a => a.MenuID == menuId && a.Status).OrderBy(a => a.Datetime).ToList();
                foreach (var article in articles)
                {
                    article.MenuAlias = article.Menu.Alias;
                }
                return articles;
            }
        }
        public static List<ShowObject> listCategory(string lan)
        {
            using (var db = new MyDbDataContext())
            {
                List<ShowObject> menus = db.Articles.Where(a => a.Status)
                        .Join(db.Menus.Where(a => a.Status && a.Location == SystemMenuLocation.MainMenu && a.LanguageID ==lan), a => a.MenuID, b => b.ID,
                            (a, b) => new ShowObject
                            {
                                ID = a.ID,
                                Title = a.Title,
                                //Content = a.Content
                            }).OrderByDescending(a => a.ID).ToList();
                return menus;
            }
        }
        //Bai viet mới
        //public static List<ShowObject> NewArticles(string languageKey)
        //{
        //    using (var db = new MyDbDataContext())
        //    {
        //        List<ShowObject> articleHots = db.Articles.Where(a => a.New && a.Status)
        //                .Join(db.Menus.Where(a => a.LanguageID == languageKey), a => a.MenuID, b => b.ID,
        //                    (a, b) => new ShowObject
        //                    {
        //                        ID = a.ID,
        //                        Alias = a.Alias,
        //                        MenuAlias = b.Alias,
        //                        Title = a.Title,
        //                        Index = a.Index,
        //                        Image = a.Image,
        //                        Description = a.Description,
        //                        //Content = a.Content
        //                    }).OrderByDescending(a => a.ID).ToList();
        //        return articleHots;
        //    }
        //}
        //Chi tiết bài viết
        public static DetailArticle Detail_Article(int id)
        {
            using (var db = new MyDbDataContext())
            {
                Article article = db.Articles.FirstOrDefault(a => a.ID == id && a.Status) ?? new Article();
                List<Article> articles = db.Articles.Where(a => a.MenuID == article.MenuID && a.Status && a.ID != article.ID).OrderBy(a => a.Index).ToList();
                foreach (var item in articles)
                {
                    item.MenuAlias = article.Menu.Alias;
                }
                DetailArticle detailArticle = new DetailArticle()
                {
                    Article = article,
                    Articles = articles
                };
                return detailArticle;
            }
        }

        //public static List<ShowObject> tourshowhome(string languageKey)
        //{
        //    using (var db = new MyDbDataContext())
        //    {
        //        List<ShowObject> tourHot = db.Tours.Where(a => a.ShowHome && a.Status)
        //                .Join(db.Menus.Where(a => a.LanguageID == languageKey), a => a.MenuID, b => b.ID,
        //                    (a, b) => new ShowObject
        //                    {
        //                        ID = a.ID,
        //                        Alias = a.Alias,
        //                        MenuAlias = b.Alias,
        //                        Title = a.Title,
        //                        Index = a.Index,
        //                        Image = a.Image,
        //                        Description = a.Description,
        //                        //Content = a.Content
        //                    }).OrderByDescending(a => a.ID).ToList();
        //        return tourHot;
        //    }
        //}

        //public static List<ShowObject> TourHot(string languageKey)
        //{
        //    using (var db = new MyDbDataContext())
        //    {
        //        List<ShowObject> tourHot = db.Tours.Where(a => (bool)a.Hot && a.Status)
        //                .Join(db.Menus.Where(a => a.LanguageID == languageKey), a => a.MenuID, b => b.ID,
        //                    (a, b) => new ShowObject
        //                    {
        //                        ID = a.ID,
        //                        Alias = a.Alias,
        //                        MenuAlias = b.Alias,
        //                        Title = a.Title,
        //                        Index = a.Index,
        //                        Image = a.Image,
        //                        Description = a.Description,
        //                        //Content = a.Content
        //                    }).OrderByDescending(a => a.ID).ToList();
        //        return tourHot;
        //    }
        //}

        //public static List<Menu> Newservice(string languageKey)
        //{
        //    using (var db = new MyDbDataContext())
        //    {
        //        List<Menu> listMenu = db.Menus.Where(x => x.Index == 1 && x.Level == 2 && x.Image != null && x.LanguageID == languageKey).ToList();
        //        return listMenu;
        //    }
        //}


        //Danh sách phòng
        public static List<Room> GetRooms(int menuId)
        {
            using (var db = new MyDbDataContext())
            {
                var menu = db.Menus.FirstOrDefault(a => a.ID == menuId);
                List<Room> rooms = db.Rooms.Where(a => a.Status && a.LanguageID == menu.LanguageID).OrderBy(a => a.Index).ToList();
                foreach (var room in rooms)
                {
                    room.MenuAlias = menu.Alias;
                }
                return rooms;
            }
        }
        //Chi tiết phòng
        public static DetailRoom Detail_Room(int id, int menuId)
        {
            using (var db = new MyDbDataContext())
            {
                var menu = db.Menus.FirstOrDefault(a => a.ID == menuId);
                Room room = db.Rooms.FirstOrDefault(a => a.ID == id && a.Status) ?? new Room();
                List<RoomGallery> roomGalleries = db.RoomGalleries.Where(a => a.RoomId == room.ID).ToList();
                List<Room> rooms = db.Rooms.Where(a => a.Status && a.ID != room.ID && a.LanguageID == menu.LanguageID).OrderBy(a => a.Index).ToList();

                foreach (var item in rooms)
                {
                    item.MenuAlias = menu.Alias;
                }
                DetailRoom detailRoom = new DetailRoom()
                {
                    Room = room,
                    RoomGalleries = roomGalleries,
                    Rooms = rooms
                };
                return detailRoom;
            }
        }
        public static Room GetRoomByName(string roomname, string lan)
        {
            using (var db = new MyDbDataContext())
            {
                Room room = db.Rooms.Where(a => a.Title == roomname && a.LanguageID == lan).FirstOrDefault();
                return room;
            }
        }

        //link trang spa
        public static Menu LinkSpa(string lan)
        {
            using ( var db = new MyDbDataContext())
            {
                Menu link = db.Menus.Where(a=>a.Type==SystemMenuType.Spa &&a.LanguageID==lan).FirstOrDefault();
                return link;
            }
        }
        //link trang restaurant
        public static Menu LinkRestaurant(string lan)
        {
            using ( var db = new MyDbDataContext())
            {
                Menu link = db.Menus.Where(a=>a.Type==SystemMenuType.Restaurant &&a.LanguageID==lan).FirstOrDefault();
                return link;
            }
        } 
        //link trang Gym
        public static Menu LinkGym(string lan)
        {
            using ( var db = new MyDbDataContext())
            {
                Menu link = db.Menus.Where(a=>a.Type==SystemMenuType.Gym &&a.LanguageID==lan).FirstOrDefault();
                return link;
            }
        }
        //link trang Room
        public static Menu LinkRoom(string lan)
        {
            using ( var db = new MyDbDataContext())
            {
                Menu link = db.Menus.Where(a=>a.Type==SystemMenuType.RoomRate &&a.LanguageID==lan).FirstOrDefault();
                return link;
            }
        }
        //Chi tiet Spa
        public static DetailSpa Detail_Spa(int id, int menuId)
        {
            using (var db = new MyDbDataContext())
            {
                var menu = db.Menus.FirstOrDefault(a => a.ID == menuId);
                Spa spa = db.Spas.FirstOrDefault(a => a.ID == id && a.Status) ?? new Spa();
                List<Spa> spas = db.Spas.Where(a => a.Status && a.ID != spa.ID && a.LanguageID == menu.LanguageID).OrderBy(a => a.Index).ToList();

                foreach (var item in spas)
                {
                    item.MenuAlias = menu.Alias;
                }
                DetailSpa detailSpa = new DetailSpa()
                {
                    Spa = spa,
                    Spas = spas
                };
                return detailSpa;
            }
        }
        public static List<Spa> GetSpas(int menuId)
        {
            using (var db = new MyDbDataContext())
            {
                var menu = db.Menus.FirstOrDefault(a => a.ID == menuId);
                List<Spa> spas = db.Spas.Where(a => a.Status && a.LanguageID == menu.LanguageID).OrderBy(a => a.Index).ToList();
                foreach (var spa in spas)
                {
                    spa.MenuAlias = menu.Alias;
                }
                return spas;
            }
        }
        //Danh sách dich vu
        public static List<Service> GetServices(int menuId)
        {
            using (var db = new MyDbDataContext())
            {
                List<Service> restaurants = db.Services.Where(a => a.Status && a.MenuID == menuId).OrderBy(a => a.Index).ToList();
                foreach (var restaurant in restaurants)
                {
                    restaurant.MenuAlias = restaurant.Menu.Alias;
                }
                return restaurants;
            }
        }

        public static List<ShowObject> GetServices(string lan)
        {
            using (var db = new MyDbDataContext())
            {
                List<ShowObject> services = db.Services.Where(a => a.Status)
                    .Join(db.Menus.Where(a=>a.LanguageID ==lan), a =>a.MenuID,b=>b.ID, (a,b) => new ShowObject
                    {
                        ID = a.ID,
                        Alias = a.Alias,
                        MenuAlias = b.Alias,
                        Title = a.Title,
                        Index = a.Index,
                        Image = a.Image,
                        Description = a.Description,
                        Content = a.Content,
                    })
                    .OrderBy(a => a.Index).ToList();
                return services;
            }
        }

        //Chi tiết dich vu
        public static DetailService Detail_Service(int id)
        {
            using (var db = new MyDbDataContext())
            {
                Service service = db.Services.FirstOrDefault(a => a.ID == id && a.Status) ?? new Service();
                List<ServiceGallery> restaurantGalleries = db.ServiceGalleries.Where(a => a.ServiceID == service.ID).ToList();
                List<Service> restaurants = db.Services.Where(a => a.Status && a.ID != service.ID).OrderBy(a => a.Index).ToList();
                foreach (var item in restaurants)
                {
                    item.MenuAlias = service.Menu.Alias;
                }
                DetailService detailRestaurant = new DetailService()
                {
                    Service = service,
                    ServiceGalleries = restaurantGalleries,
                    Services = restaurants
                };
                return detailRestaurant;
            }
        }

        //Danh sách tours
        public static List<Tour> GetTours(int menuId)
        {
            using (var db = new MyDbDataContext())
            {
                List<Tour> tours = db.Tours.Where(a => a.Status && a.MenuID == menuId).OrderBy(a => a.Index).ToList();
                foreach (var tour in tours)
                {
                    tour.MenuAlias = tour.Menu.Alias;
                }
                return tours;
            }
        } 
        //Chi tiết tour
        public static DetailTour Detail_Tour(int id)
        {
            using (var db = new MyDbDataContext())
            {
                Tour tour = db.Tours.FirstOrDefault(a => a.ID == id && a.Status) ?? new Tour();
                List<TourGallery> tourGalleries = db.TourGalleries.Where(a => a.TourID == tour.ID).ToList();
                List<TabTour> tabTours = db.TabTours.Where(a => a.TourID == tour.ID).ToList();
                List<Tour> tours = db.Tours.Where(a => a.Status && a.ID != tour.ID).OrderBy(a => a.Index).ToList();
                foreach (var item in tours)
                {
                    item.MenuAlias = item.Menu.Alias;
                }
                DetailTour detailTour = new DetailTour()
                {
                    Tour = tour,
                    TourGalleries = tourGalleries,
                    Tours = tours,
                    TabTours = tabTours
                };
                return detailTour;
            }
        }

        ///////////// Trang home ////////////////////////
        //Bai viet welcome
        public static ShowObject WellcomeArticle(string languageKey)
        {
            using (var db = new MyDbDataContext())
            {
                return
                    db.Articles.Where(a => a.Home && a.Status)
                        .Join(db.Menus.Where(a => a.LanguageID == languageKey), a => a.MenuID, b => b.ID,
                            (a, b) => new ShowObject()
                            {
                                ID = a.ID,
                                Alias = a.Alias,
                                MenuAlias = b.Alias,
                                Title = a.Title,
                                Index = a.Index,
                                Image = a.Image,
                                Description = a.Description
                            }).FirstOrDefault();
            }
        }
        ///////////// Trang home ////////////////////////
        //Bai viet welcome
        public static ShowObject WellcomeServer(string languageKey)
        {
            using (var db = new MyDbDataContext())
            {
                return
                    db.Services.Where(a => a.Home && a.Status)
                        .Join(db.Menus.Where(a => a.LanguageID == languageKey), a => a.MenuID, b => b.ID,
                            (a, b) => new ShowObject
                            {
                                ID = a.ID,
                                Alias = a.Alias,
                                MenuAlias = b.Alias,
                                Title = a.Title,
                                Index = a.Index,
                                Image = a.Image,
                                Description = a.Description,
                            }).FirstOrDefault();
            }
        }
        public static List<ServiceGallery> listServer(int id)
        {
            using (var db = new MyDbDataContext())
            {
                return
                    db.ServiceGalleries
                        .Join(db.Services.Where(a => a.ID == id), a => a.ServiceID, b => b.ID,
                            (a, b) => a).ToList();
            }
        }
        //Bai viet hot
        public static List<ShowObject> HotArticles(string languageKey)
        {
            using (var db = new MyDbDataContext())
            {
                List<ShowObject> articleHots = db.Articles.Where(a => a.Hot && a.Status)
                        .Join(db.Menus.Where(a => a.LanguageID == languageKey), a => a.MenuID, b => b.ID,
                            (a, b) => new ShowObject
                            {
                                ID = a.ID,
                                Alias = a.Alias,
                                MenuAlias = b.Alias,
                                Title = a.Title,
                                Index = a.Index,
                                Image = a.Image,
                                //Link = a.Link,
                                Description = a.Description,
                            }).ToList();
                return articleHots;
            }
        }
        //Bai viet gioi thieu
        public static Article HotArticle(int menuId)
        {
            using (var db = new MyDbDataContext())
            {
                 return db.Articles.Where(a => a.MenuID == menuId && a.Hot).OrderBy(a => a.Index).FirstOrDefault();
            }
        }
        public static Article GreetArticles(int menuId)
        {
            using (var db = new MyDbDataContext())
            {
                return db.Articles.Where(a => a.MenuID == menuId && a.Home).OrderBy(a => a.Index).FirstOrDefault();
            }
        }
        public static ShowObject WellcomeArticles(string languageKey)
        {
            using (var db = new MyDbDataContext())
            {
                ShowObject article = db.Articles.Where(a => a.Home)
                    .Join(db.Menus.Where(a=>a.LanguageID==languageKey),a=>a.MenuID,b=>b.ID,(a,b)=> new ShowObject
                    {
                        ID = a.ID,
                        Alias = a.Alias,
                        MenuAlias = b.Alias,
                        Title = a.Title,
                        Index = a.Index,
                        Image = a.Image,
                        Description = a.Description,
                        Content = a.Content,
                    }).OrderBy(a=>a.Index).FirstOrDefault();
                return  article;
            }
        }
        //Bai viet Customer
        public static List<ShowObject> CustomerArticles(string languageKey)
        {
            using (var db = new MyDbDataContext())
            {
                List<ShowObject> CustomerArticle = db.Articles.Where(a => a.Customer && a.Status && a.Home)
                        .Join(db.Menus.Where(a => a.LanguageID == languageKey), a => a.MenuID, b => b.ID,
                            (a, b) => new ShowObject
                            {
                                ID = a.ID,
                                Alias = a.Alias,
                                MenuAlias = b.Alias,
                                Title = a.Title,
                                Index = a.Index,
                                Image = a.Image,
                                Description = a.Description,
                                Content = a.Content,
                                //Link = a.Link
                            }).ToList();
                return CustomerArticle;
            }
        }
        //phòng show home

        public static List<ShowObject> RoomShowHome(string languageKey)
        {
            using (var db = new MyDbDataContext())
            {
                var memu =
                    db.Menus.FirstOrDefault(a => a.Type == SystemMenuType.RoomRate && a.LanguageID == languageKey) ??
                    new Menu();
                List<ShowObject> roomShowHome = db.Rooms.Where(a => a.Home && a.Status && a.LanguageID == languageKey).Select(a => new ShowObject
                {
                    ID = a.ID,
                    Alias = a.Alias,
                    MenuAlias = memu.Alias,
                    Title = a.Title,
                    Index = a.Index,
                    Image = a.Image,
                    Description = a.Description,
                    Price = a.Price,
                    PriceNet = (a.PriceNet == null) ? 0 : (decimal)a.PriceNet,
                }).ToList();
                return roomShowHome;
            }
        }

        public static List<ShowObject> Newservice(string lang)
        {
           
                using (var db = new MyDbDataContext())
                {
                    List<ShowObject> serviceList = db.Services.Where(a => a.Home && a.Status)
                        .Join(db.Menus.Where(a => a.LanguageID == lang), a => a.MenuID, b => b.ID,
                            (a, b) => new ShowObject
                            {
                                ID = a.ID,
                                Alias = a.Alias,
                                MenuAlias = b.Alias,
                                Title = a.Title,
                                Index = a.Index,
                                Image = a.Image,
                                Description = a.Description,
                            }).ToList();
                    return serviceList;
                }
             
        }
    }
}