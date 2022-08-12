using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeamplateHotel.Areas.Administrator.EntityModel
{
    public class EUsefullink 
    {
        public int ID { get; set; }

        [DisplayName("Tên")]
        [Required(ErrorMessage = "Vui lòng nhập Tên")]
        [MaxLength(100, ErrorMessage = "Tối đa 100 ký tự")]
        public string Name { get; set; }
        public string Alias { get; set; }

        [DisplayName("Link")]
        [MaxLength(500, ErrorMessage = "Tối đa 500 ký tự")]
        public string Link { get; set; }

        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        public string Description { get; set; }

        [DisplayName("Trạng thái hiển thị")]
        public bool Status { get; set; }
        public int Index { get; set; }
        public string LanguageID { get; set; }
    }
}
