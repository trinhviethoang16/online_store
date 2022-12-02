using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjectOnlineStore.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Họ")]
        public string? firstName { get; set; }

        [Display(Name = "Tên")]
        public string? lastName { get; set; }

        [Display(Name = "Tuổi")]
        public int? age { get; set; }

        [Display(Name = "Số điện thoại")]
        public string? phone { get; set; }

        [Display(Name = "Địa chỉ")]
        public string? address { get; set; }
    }
}
