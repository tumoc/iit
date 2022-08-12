using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectLibrary.Database;

namespace TeamplateHotel.Areas.Administrator.EntityModel
{
    public class EWine
    {
        public int ID { get; set; }

        public string LanguageID { get; set; }

        [DisplayName("Tên Rượu")]
        [MaxLength(100, ErrorMessage = "Tối đa 100 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập tên rượu")]
        public string Title { get; set; }

        [DisplayName("Ảnh đại diện")]
        [MaxLength(200, ErrorMessage = "Tối đa 200 ký tự")]
        [Required(ErrorMessage = "Vui lòng chọn ảnh đại diện")]
        public string Image { get; set; }

        [DisplayName("Giá Rượu")]
        [Required(ErrorMessage = "Vui lòng nhập giá Rượu")]
        [Range(1, double.MaxValue, ErrorMessage = "Giá phòng phải lớn hơn 0.")]
        public decimal Price { get; set; }
        public int? Index { get; set; }

        [DisplayName("Mô tả nguồn gốc")]
        [Required(ErrorMessage = "Vui lòng nhập mô tả nguồn gốc")]
        public string Fromto { get; set; }


        [DisplayName("Trạng thái hiển thị")]
        public bool Status { get; set; }
    }
}