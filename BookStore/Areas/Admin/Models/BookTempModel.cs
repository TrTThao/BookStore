using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Areas.Admin.Models
{
    public class BookTempModel
    {
        public int ID { get; set; }

        [Display(Name ="Tên sách")]
        [Required(ErrorMessage = "Không thể bỏ trống trường này")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Không thể bỏ trống trường này")]
        [Display(Name = "Giá sách")]

        public string Price { get; set; }

        [Required(ErrorMessage = "Không thể bỏ trống trường này")]
        [Display(Name = "Mô tả")]
        public string Decription { get; set; }
        [Required(ErrorMessage = "Không thể bỏ trống trường này")]
        [Display(Name = "Số lượng có")]


        public Nullable<int> NumberOfInventory { get; set; }
        [Display(Name = "Ngày cập nhật")]

        public Nullable<System.DateTime> UpdateDate { get; set; }
        [Display(Name = "Chú thích")]

        public string Note { get; set; }
        [Required(ErrorMessage = "Không thể bỏ trống trường này")]
        [Display(Name = "Ảnh bìa")]

        public string ImagePath { get; set; }

        public Nullable<int> BookTypeID { get; set; }
        public Nullable<int> AuthorID { get; set; }
        public Nullable<int> PublisherID { get; set; }
    }
}