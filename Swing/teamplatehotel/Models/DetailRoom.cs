using System.Collections.Generic;
using ProjectLibrary.Database;

namespace TeamplateHotel.Models
{
    public class DetailRoom
    {
        public Room Room { get; set; }
        public List<Room> Rooms { get; set; }
        public List<RoomGallery> RoomGalleries { get; set; }
        public List<RoomAmenity> RoomAmenities { get; set; }
    }
}