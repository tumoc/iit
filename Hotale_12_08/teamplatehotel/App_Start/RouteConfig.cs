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
            //search
            routes.MapRoute("Search", "Home/Search", new
            {
                controller = "Home",
                action = "Search",
            });
            //comment
            routes.MapRoute("Comment", "Cment2/Send", new
            {
                controller = "Cment2",
                action = "Send",
            }); 
            //enquiry
            routes.MapRoute("Enquiry", "Enquiry/Create", new
            {
                controller = "Enquiry",
                action = "Create",
            });
            //subscribe
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