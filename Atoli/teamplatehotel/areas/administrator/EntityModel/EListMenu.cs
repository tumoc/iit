using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeamplateHotel.Areas.Administrator.EntityModel
{
    public class EListMenu 
    {
        public int ID { get; set; }
        public string LanguageID { get; set; }

        [DisplayName("Tên menu")]
        [MaxLength(100, ErrorMessage = "Tối đa 100 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập tên menu")]
        public string Title { get; set; }

        [DisplayName("Thời gian phục vụ")]
        [MaxLength(100, ErrorMessage = "Tối đa 100 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập thời gian phục vụ")]
        public string Time { get; set; }
        public int? Index { get; set; }

    }
}
