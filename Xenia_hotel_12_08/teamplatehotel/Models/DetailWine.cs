using System.Collections.Generic;
using ProjectLibrary.Database;

namespace TeamplateHotel.Models
{
    public class DetailWine
    {
        public Wine  Wine { get; set; }
        public List<Wine> Wines { get; set; }
    }
}