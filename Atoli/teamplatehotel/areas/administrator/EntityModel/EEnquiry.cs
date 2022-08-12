using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeamplateHotel.Areas.Administrator.EntityModel
{
    public class EEnquiry
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [DisplayName("Yêu cầu")]
        public string Enquiry { get; set; }
    }
}
