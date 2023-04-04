using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Demo_1.Models.RegisterCompanyViewModel
{
    public class RegisterCompanyViewModel
    {

        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Họ và tên không được để trống")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(32, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự và tối đa 32 ký tự")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Xác nhận mật khẩu không được để trống")]
        [Compare("Password", ErrorMessage = "Hai mật khẩu không trùng nhau")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        public string Email { get; set; }

    }
}