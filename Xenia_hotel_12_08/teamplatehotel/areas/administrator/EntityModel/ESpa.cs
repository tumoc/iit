using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectLibrary.Database;

namespace TeamplateHotel.Areas.Administrator.EntityModel
{
    public class ESpa
    {
        public int ID { get; set; }

        public string LanguageID { get; set; }

        [DisplayName("Tên Spa")]
        [MaxLength(250, ErrorMessage = "Tối đa 250 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập tên phòng")]
        public string Title { get; set; }

        [DisplayName("Alias")]
        [MaxLength(250, ErrorMessage = "Tối đa 250 ký tự")]
        public string Alias { get; set; }

        [DisplayName("Ảnh đại diện")]
        [MaxLength(300, ErrorMessage = "Tối đa 300 ký tự")]
        [Required(ErrorMessage = "Vui lòng chọn ảnh đại diện")]
        public string Image { get; set; }

        [DisplayName("Giá Spa")]
        [Required(ErrorMessage = "Vui lòng nhập giá Spa")]
        [Range(1, double.MaxValue, ErrorMessage = "Giá Spa phải lớn hơn 0.")]
        public decimal Price { get; set; }

        public int? Index { get; set; }

        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        public string Description { get; set; }

        [DisplayName("Mô tả chi tiết")]
        [Required(ErrorMessage = "Vui lòng nhập mô tả chi tiết")]
        public string Content { get; set; }

        [DisplayName("Tiêu đề trang")]
        [MaxLength(250, ErrorMessage = "Tối đa 250 ký tự")]
        public string MetaTitle { get; set; }

        [DisplayName("Trạng thái hiển thị")]
        public bool Status { get; set; }

        [DisplayName("Hiện thị ở trang chủ")]
        public bool Home { get; set; }
        public List<EGalleryITem> EGalleryITems { get; set; }
    }
}