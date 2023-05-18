using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Bạn không được bỏ trống trường này")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bạn không được bỏ trống trường này")]

        public string Username { get; set; }
        [Required(ErrorMessage = "Bạn không được bỏ trống trường này")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Bạn không được bỏ trống trường này")]

        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Bạn không được bỏ trống trường này")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Bạn không được bỏ trống trường này")]

        public string Phone { get; set; }
        [Required(ErrorMessage = "Bạn không được bỏ trống trường này")]

        public Nullable<bool> Sex { get; set; }
    }
}