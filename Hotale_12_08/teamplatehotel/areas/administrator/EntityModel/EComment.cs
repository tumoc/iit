using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeamplateHotel.Areas.Administrator.EntityModel
{
    public class EComment
    {
        public int ID { get; set; }
        public int ArticleID { get; set; }
        public string languageID { get; set; }
        public DateTime CreateDate { get; set; }
        public string Website { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [DisplayName("Bình luận")]
        public string Comment { get; set; }


    }
}