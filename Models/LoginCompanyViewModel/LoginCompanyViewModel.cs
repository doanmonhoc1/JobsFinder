using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo_1.Models.LoginCompanyViewModel
{
    public class LoginCompanyViewModel
    {
        [Required (ErrorMessage = "Số điện thoại không được để trống!")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại phải có 10 chữ số")]
        public string PhoneNumber { get; set; }

        [Required (ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }
    }
}