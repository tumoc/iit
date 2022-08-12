using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectLibrary.Database;

namespace TeamplateHotel.Areas.Administrator.EntityModel
{
    public class EFeedBack
    {
        public int ID { get; set; }

        public string languageID { get; set; }

        [DisplayName("Nội dung đánh giá")]
        [MaxLength(300, ErrorMessage = "Tối đa 300 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập nội dung đánh giá")]
        public string Content { get; set; }  
        
        [DisplayName("Tên khách hàng")]
        [MaxLength(50, ErrorMessage = "Tối đa 50 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập tên khách hàng")]
        public string Name { get; set; }
        public int? Index { get; set; }
        public int Star { get; set; }
        public int RoomID { get; set; }
        public DateTime CreateDate { get; set; }
        
        [DisplayName("Ảnh đại diện")]
        [MaxLength(300, ErrorMessage = "Tối đa 300 ký tự")]
        [Required(ErrorMessage = "Vui lòng chọn ảnh đại diện")]
        public string Avatar { get; set; }
    }
}
