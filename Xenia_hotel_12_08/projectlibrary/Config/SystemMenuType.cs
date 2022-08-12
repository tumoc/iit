using System.Collections.Generic;

namespace ProjectLibrary.Config
{
    public class SystemMenuType
    {
        public const int Home = 1;
        public const int Article = 2;
        public const int RoomRate = 3;
        public const int Tour = 4;
        public const int Contact = 5;
        public const int Booking = 6;
        public const int Gallery = 7;
        public const int Location = 8;
        public const int OutSite = 9;
        public const int Service = 10;
        public const int Activities = 11;
        public const int Restaurant = 12;
        public const int Spa = 13;
        public const int BookingTour = 14;
        public const int BookingRestaurant = 15;
        public const int Gym = 16;

        public static Dictionary<int, string> CategoryType = new Dictionary<int, string>()
                                                                 {
                                                                     {Home, "Trang chủ"},
                                                                     {Article, "Trang bài viết"},
                                                                     {RoomRate, "Trang phòng"},
                                                                     {Tour, "Trang tours"},
                                                                     {Service, "Trang dịch vụ"},
                                                                     {Contact, "Trang liên hệ"},
                                                                     {Booking, "Trang đặt phòng"},
                                                                     {Gallery, "Trang gallery"},
                                                                     {Location, "Trang vị trí"},
                                                                     {OutSite, "Trang link ra ngoài"},
                                                                     {Activities, "Trang hoạt động"},
                                                                     {Restaurant, "Trang nhà hàng"},
                                                                     {Spa, "Trang Spa"},
                                                                     {BookingTour, "Trang BookingTour"},
                                                                     {BookingRestaurant, "Trang BkRestaurant"},
                                                                     {Gym, "Trang Thể thao"},
                                                                 };
    }
}
