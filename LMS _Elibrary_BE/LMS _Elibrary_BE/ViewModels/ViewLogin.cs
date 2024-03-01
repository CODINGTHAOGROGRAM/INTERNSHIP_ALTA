using System.ComponentModel.DataAnnotations;

namespace LMS__Elibrary_BE.ViewModels
{
    public class ViewLogin
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "Hãy điền email !")]
        [RegularExpression("^[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*$",
            ErrorMessage = "Email không hợp lệ !")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Hãy nhập mật khẩu !")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
