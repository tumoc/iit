using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TeamplateHotel.Areas.Administrator.EntityModel
{
    public class EOnepay
    {
        public int PaymentConfigOnePayID { get; set; }

        public string MerchantId { get; set; }

        public string MethodName { get; set; }


        public string AccessCode { get; set; }

        public string Hashcode { get; set; }
        public string WebSite { get; set; }

        [DisplayName("Cổng Nội Địa")]

        public bool? NoiDia { get; set; }
        [DisplayName("Cổng Quốc Tế")]

        public bool? QuocTe { get; set; }



    }
}