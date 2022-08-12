using System.Web.Mvc;
using System.Web.Routing;

namespace TeamplateHotel
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Booking2", "Booking/SendBooking", new
            {
                controller = "Booking",
                action = "SendBooking",
            });
            routes.MapRoute("Booking3", "Booking/Messages", new
            {
                controller = "Booking",
                action = "Messages",
            });
            //booking room
            routes.MapRoute("Booking1", "booking", new
            {
                controller = "Booking",
                action = "MakeReservation",
            });

            //contact
            routes.MapRoute("Contact", "Contact/SubmitContact", new
            {
                controller = "SendContact",
                action = "SubmitContact",
            });
            //contact
            routes.MapRoute("Contact Messages", "Contact/Messages", new
            {
                controller = "SendContact",
                action = "Messages",
            });

            //Booking tour 
            routes.MapRoute("BookTour1", "BookTour/SendBooking", new
            {
                controller = "BookingTour",
                action = "SendBooking",
            });
            routes.MapRoute("BookTour2", "BookTour/Messages", new
            {
                controller = "BookingTour",
                action = "Messages",
            });

            //onepay
            routes.MapRoute("Submit-InvoidOnePay", "BookTour/SubmitInvoidOnePay", new
            {
                controller = "BookingTour",
                action = "SubmitInvoidOnePay",
            });
            routes.MapRoute("Message-OnePay", "BookTour/MessageOnePay", new
            {
                controller = "BookingTour",
                action = "MessageOnePay",
            });

            //Booking tour 
            routes.MapRoute("BookTour3", "BookTour/{id}/{alias}", new
            {
                controller = "BookingTour",
                action = "BookTour",
                id = UrlParameter.Optional,
                alias = UrlParameter.Optional
            });
            //Booking restaurant
            routes.MapRoute("BookRestaurant", "BookingRestaurant/BookRestaurant", new
            {
                controller = "BookingRestaurant",
                action = "BookRestaurant",
            });
            //
            routes.MapRoute("BookRestaurant1", "BookRestaurant/SendBooking", new
            {
                controller = "BookingRestaurant",
                action = "SendBooking",
            });
            routes.MapRoute("BookRestaurant2", "BookRestaurant/Messages", new
            {
                controller = "BookingRestaurant",
                action = "Messages",
            });
            routes.MapRoute("BookRestaurant3", "MenuWine", new
            {
                controller = "BookingRestaurant",
                action = "MenuWine",
            });
            routes.MapRoute("Subscribe", "Subscribe/Send", new
            {
                controller = "Subscribe",
                action = "Send",
            });
            routes.MapRoute("Default", "{aliasMenuSub}/{idSub}/{aliasSub}", new
            {
                controller = "Home",
                action = "Index",
                aliasMenuSub = UrlParameter.Optional,
                idSub = UrlParameter.Optional,
                aliasSub = UrlParameter.Optional
            }
                );
        }
    }
}