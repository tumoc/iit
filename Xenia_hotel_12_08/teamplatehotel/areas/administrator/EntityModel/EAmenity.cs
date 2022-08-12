using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectLibrary.Database;

namespace TeamplateHotel.Areas.Administrator.EntityModel
{
    public class EAmenity
    {
        public int ID { get; set; }

        public string LanguageID { get; set; }

        [DisplayName("Tên tiện ích")]
        [MaxLength(100, ErrorMessage = "Tối đa 100 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập tên tiện ích")]
        public string Title { get; set; } 
        
        [DisplayName("Mô tả tiện ích")]
        [Required(ErrorMessage = "Vui lòng nhập tên tiện ích")]
        public string Description { get; set; }

        [DisplayName("Ảnh đại diện")]
        [MaxLength(200, ErrorMessage = "Tối đa 200 ký tự")]
        [Required(ErrorMessage = "Vui lòng chọn ảnh đại diện")]
        public string Image { get; set; }
        public int? Index { get; set; }

        [DisplayName("Trạng thái hiển thị")]
        public bool Status { get; set; }

        [DisplayName("Hiện thị ở trang chủ")]
        public bool Home { get; set; }

    }
}