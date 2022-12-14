using System;
using System.ComponentModel;

namespace TeamplateHotel.Areas.Administrator.ModelShow
{
    public class ShowArticle
    {
        public int ID { get; set; }

        [DisplayName("Mức độ đánh giá")]
        public int Star { get; set; }

        [DisplayName("Tiêu đề")]
        public string Title { get; set; } 

        [DisplayName("Nội quy")]     
        public string Name { get; set; } 

        [DisplayName("Tên")]
        public string Rule { get; set; }

        [DisplayName("Chuyên mục")]
        public string TitleMenu { get; set; }

        [DisplayName("Tác giả")]
        public string Authur { get; set; }

        [DisplayName("Bình luận")]
        public string Comment { get; set; }

        [DisplayName("Thứ tự hiển thị")]
        public int? Index { get; set; }

        [DisplayName("Trạng thái hiển thị")]
        public bool Status { get; set; }

        [DisplayName("Bài viết giới thiệu")]
        public bool Home { get; set; }

        [DisplayName("Bài viết hot")]
        public bool Hot { get; set; }

        [DisplayName("Ý kiến khách hàng")]
        public bool Customer { get; set; }

        [DisplayName("Bài viết nổi bật")]
        public bool New { get; set; }
        
        [DisplayName("Ngày đăng")]
        public DateTime DateTime { get; set; }
        

    }
}