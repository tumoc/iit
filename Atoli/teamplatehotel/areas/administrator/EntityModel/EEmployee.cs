using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectLibrary.Database;

namespace TeamplateHotel.Areas.Administrator.EntityModel
{
    public class EEmployee
    {
        public int ID { get; set; }

        public string LanguageID { get; set; }

        [DisplayName("Tên nhân viên")]
        [MaxLength(100, ErrorMessage = "Tối đa 100 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập tên nhân viên")]
        public string Name { get; set; }

        [DisplayName("Chức vụ")]
        [MaxLength(50, ErrorMessage = "Tối đa 50 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập chức vụ")]
        public string Position { get; set; }

        [DisplayName("Ảnh đại diện")]
        [MaxLength(300, ErrorMessage = "Tối đa 300 ký tự")]
        [Required(ErrorMessage = "Vui lòng chọn ảnh đại diện")]
        public string Image { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string instagram { get; set; }
        public string printerest { get; set; }
        public int? Index { get; set; }

    }
}
