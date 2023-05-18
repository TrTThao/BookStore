using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class ChangePasswordModel
    {
        public string Username { get; set; }
        [Required(ErrorMessage ="Không thể bỏ trống trường này")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Không thể bỏ trống trường này")]


        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Không thể bỏ trống trường này")]

        public string ConfirmPassword { get; set; }
    }
}