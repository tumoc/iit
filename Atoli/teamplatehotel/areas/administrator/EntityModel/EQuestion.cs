using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeamplateHotel.Areas.Administrator.EntityModel
{
    public class EQuestion 
    {
        public int ID { get; set; }
        
        [DisplayName("Câu hỏi")]
        [Required(ErrorMessage = "Vui lòng nhập câu hỏi")]
        [MaxLength(250, ErrorMessage = "Tối đa 250 ký tự")]
        public string Title { get; set; }
        
        [DisplayName("Câu trả lời")]
        [Required(ErrorMessage = "Vui lòng nhập câu trả lời")]
        public string Content { get; set; }

        [DisplayName("Trạng thái hiển thị")]
        public bool Status { get; set; }

        [DisplayName("Hiển thị trang chủ")]
        public bool Home { get; set; }

        [DisplayName("Bài viết hot")]

        public int Index { get; set; }
        
        public string LanguageID { get; set; }
    }
}
