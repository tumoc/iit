using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectLibrary.Database;

namespace TeamplateHotel.Areas.Administrator.EntityModel
{
    public class ERoom
    {
        public int ID { get; set; }

        public string LanguageID { get; set; }

        [DisplayName("Tên phòng")]
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
        

        [DisplayName("Số người tối đa")]
        [Required(ErrorMessage = "Vui lòng nhập số người tối đa")]
        [Range(1, int.MaxValue, ErrorMessage = "Số người tối đa phải lớn hơn 0.")]
        public int MaxPeople { get; set; }

        [DisplayName("Giá phòng loại cơ bản")]
        [Required(ErrorMessage = "Vui lòng nhập giá phòng")]
        [Range(1, double.MaxValue, ErrorMessage = "Giá phòng phải lớn hơn 0.")]
        public decimal Price { get; set; }
        
        [DisplayName("Giá phòng loại cao cấp")]
        [Required(ErrorMessage = "Vui lòng nhập giá phòng")]
        [Range(1, double.MaxValue, ErrorMessage = "Giá phòng phải lớn hơn 0.")]
        public decimal PricePremium { get; set; }

        [DisplayName("Giá khuyến mại")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá khuyến mại phải lớn hơn 0.")]
        public decimal? PriceNet { get; set; }

        public int? Index { get; set; }

        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        public string Description { get; set; }

        [DisplayName("Mô tả chi tiết")]
        [Required(ErrorMessage = "Vui lòng nhập mô tả chi tiết")]
        public string Content { get; set; }

        [DisplayName("Hướng phòng")]
        [MaxLength(150, ErrorMessage = "Tối đa 150 ký tự")]
        public string Roomview { get; set; }

        [DisplayName("Số giường")]
        [Required(ErrorMessage = "Vui lòng nhập số giường")]
        [Range(1, int.MaxValue, ErrorMessage = "Số người phải lớn hơn 0.")]
        public int Numofbed { get; set; }

        [DisplayName("Loại giường")]
        [MaxLength(50, ErrorMessage = "Tối đa 50 ký tự")]
        public string Typebed { get; set; }


        [DisplayName("Diện tích phòng")]
        [Required(ErrorMessage = "Vui lòng nhập diện tích phòng")]
        [Range(1, double.MaxValue, ErrorMessage = "Diện tích phòng phải lớn hơn 0.")]
        public decimal Roomspace { get; set; }

        [DisplayName("Tiêu đề trang")]
        [MaxLength(250, ErrorMessage = "Tối đa 250 ký tự")]

        public string MetaTitle { get; set; }

        [DisplayName("Thẻ mô tả")]
        [MaxLength(250, ErrorMessage = "Tối đa 250 ký tự")]
        public string MetaDescription { get; set; }

        [DisplayName("Trạng thái hiển thị")]
        public bool Status { get; set; }

        [DisplayName("Hiện thị ở trang chủ")]
        public bool Home { get; set; }

        public List<EGalleryITem> EGalleryITems { get; set; }
        public List<EBasicItem> EBasicItems { get; set; }
        public List<EPremiumItem> EPremiumItems { get; set; }
        //public List<EAmenityItem> EAmenityItems { get; set; }
    }
    //public class EAmenityItem
    //{
    //    public int Id { get; set; }
    //}
    public class EBasicItem
    {
        public int Id { get; set; }
    }
    public class EPremiumItem
    {
        public int Id { get; set; }
    }
}