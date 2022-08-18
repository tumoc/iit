using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeamplateHotel.Areas.Administrator.EntityModel
{
    public class EAward 
    {
        public int ID { get; set; }
        public string LanguageID { get; set; }

        [DisplayName("Tên giải thưởng")]
        [MaxLength(100, ErrorMessage = "Tối đa 100 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập tên giải thưởng")]
        public string Title { get; set; }

        [DisplayName("Ảnh đại diện")]
        [MaxLength(350, ErrorMessage = "Tối đa 350 ký tự")]
        [Required(ErrorMessage = "Vui lòng chọn ảnh đại diện")]
        public string Image { get; set; }
        public int? Index { get; set; }

        [DisplayName("Trạng thái hiển thị")]
        public bool Status { get; set; }
    }
}
