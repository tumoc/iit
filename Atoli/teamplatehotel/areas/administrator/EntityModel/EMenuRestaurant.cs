using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeamplateHotel.Areas.Administrator.EntityModel
{
    public class EMenuRestaurant 
    {
        public int ID { get; set; }

        [DisplayName("Chuyên mục ")]
        [Required(ErrorMessage = "Vui lòng chọn chuyên mục")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn chuyên mục")]
        public int MenuID { get; set; }

        [DisplayName("Tên gọi")]
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [MaxLength(100, ErrorMessage = "Tối đa 100 ký tự")]
        public string Title { get; set; }


        [DisplayName("Ảnh đại diện")]
        [MaxLength(300, ErrorMessage = "Tối đa 300 ký tự")]
        public string Image { get; set; }

        [DisplayName("Mô tả chi tiết")]
        [Required(ErrorMessage = "Vui lòng nhập mô tả chi tiết")]
        public string Content { get; set; }

        public int? Index { get; set; }

        [DisplayName("Trạng thái hiển thị")]
        public bool Status { get; set; }

        [DisplayName("Giá ")]
        [Required(ErrorMessage = "Vui lòng nhập giá ")]
        [Range(1, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0.")]
        public decimal Price { get; set; }
    }
}
