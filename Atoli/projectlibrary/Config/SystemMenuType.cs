using System.Collections.Generic;

namespace ProjectLibrary.Config
{
    public class SystemMenuType
    {
        public const int Home = 1;
        public const int Article = 2;
        public const int RoomRate = 3;
        public const int Contact = 5;
        public const int Booking = 6;
        public const int Gallery = 7;
        public const int OutSite = 9;
        public const int Service = 10;
        public const int About = 11;
        public const int RoomSearch = 12;
        public const int Restaurant = 13;
        public const int FQAS = 14;
        public const int Orther = 15;

        public static Dictionary<int, string> CategoryType = new Dictionary<int, string>()
                                                                 {
                                                                     {Home, "Trang chủ"},
                                                                     {Article, "Trang bài viết"},
                                                                     {RoomRate, "Trang phòng"},
                                                                     {Service, "Trang dịch vụ"},
                                                                     {OutSite, "Trang link ra ngoài"},
                                                                     {Contact, "Trang liên hệ"},
                                                                     {Booking, "Trang đặt phòng"},
                                                                     {Gallery, "Trang gallery"},
                                                                     {About, "Trang About"},
                                                                     {RoomSearch, "Trang Tìm phòng"},
                                                                     {Restaurant, "Trang nhà hàng"},
                                                                     {FQAS, "Trang câu hỏi"},
                                                                     {Orther, "Khác"},
                                                                 };
    }
}
