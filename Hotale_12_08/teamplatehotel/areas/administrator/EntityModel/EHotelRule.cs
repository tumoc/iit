using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectLibrary.Database;

namespace TeamplateHotel.Areas.Administrator.EntityModel
{
    public class EHotelRule
    {
        public int ID { get; set; }

        public string languageID { get; set; }

        [DisplayName("Tên nội quy")]
        [MaxLength(250, ErrorMessage = "Tối đa 250 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập nội quy")]
        public string Rule { get; set; }

        public int? Index { get; set; }

        [DisplayName("Trạng thái hiển thị")]
        public bool Status { get; set; }

    }
}