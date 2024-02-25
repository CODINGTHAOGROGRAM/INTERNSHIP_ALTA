using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS__Elibrary_BE.ViewModels
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "Hãy nhập mật khẩu hiện tại !")]
        [Column(TypeName = "varchar(50)"), MaxLength(50), MinLength(8, ErrorMessage = "Mật khẩu phải dài ít nhất 8 ký tự !")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu hiện tại")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Hãy nhập mật khẩu mới !")]
        [Column(TypeName = "varchar(50)"), MaxLength(50), MinLength(8, ErrorMessage = "Mật khẩu phải dài ít nhất 8 ký tự !")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới")]
        public string NewPassword { get; set; }

        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu không trùng khớp !")]
        [Display(Name = "Xác nhận lại mật khẩu mới")]
        public string ConfirmNewPassword { get; set; }

        //Navigation
        public string? UserID { get; set; } 
    }
}
