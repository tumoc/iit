using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectLibrary.Database;

namespace TeamplateHotel.Areas.Administrator.EntityModel
{
    public class EFacility
    {
        public int ID { get; set; }

        public string LanguageID { get; set; }

        [DisplayName("Tên tiện ích")]
        [MaxLength(50, ErrorMessage = "Tối đa 50 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập tên tiện ích")]
        public string Title { get; set; }
        public int? Index { get; set; }
        public bool  Hot { get; set; }
        public bool  Basic { get; set; }
        public bool  Premium { get; set; }
        public string  Image { get; set; }

        [DisplayName("Mô tả chi tiết")]
        [MaxLength(350, ErrorMessage = "Tối đa 350 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập mô tả chi tiết")]
        public string  Content { get; set; }

    }
}