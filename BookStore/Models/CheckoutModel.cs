using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class CheckoutModel
    {
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Bạn cần nhập địa chỉ nhận hàng")]
        public string Address { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Bạn cần nhập số điện thoại")]
        public string Phone { get; set; }

        [Display(Name = "Chú thích")]
        public string Note { get; set; }

    }
}