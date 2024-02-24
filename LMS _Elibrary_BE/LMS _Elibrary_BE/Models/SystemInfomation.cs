using LMS__Elibrary_BE.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LMS_Library_API.Models
{
    public class SystemInfomation
    {
        [Key] public Guid Id { get; set; } = new Guid();

        [Column(TypeName = "varchar(30)")]
        [StringLength(30, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required(ErrorMessage = "Hãy nhập mã trường")]
        public string SchoolId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required(ErrorMessage = "Hãy nhập tên người dùng")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(50)")]
        [AllowNull]
        [StringLength(50, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required(ErrorMessage = "Hãy nhập địa chỉ website của trường")]
        public string SchoolWebsite { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [StringLength(30, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required(ErrorMessage = "Hãy nhập loại trường")]
        public string SchoolType { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required(ErrorMessage = "Hãy nhập tên hệ thống thư viện của trường")]
        public string LibrarySystemName { get; set; }

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required(ErrorMessage = "Hãy nhập địa chỉ website hệ thống thư viện của trường")]
        public string LMSWebsite { get; set; }

        [Column(TypeName = "varchar(20)")]
        [StringLength(20, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required(ErrorMessage = "Hãy nhập số điện thoại của trường")]
        [RegularExpression("^(?:\\+84|0)\\d{9}$", ErrorMessage = "Số điện thoại không hợp lệ !")]
        public string PhoneNumber { get; set;}

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required(ErrorMessage = "Hãy nhâp email của trường")]
        [RegularExpression("^[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*$",
                    ErrorMessage = "Email không hợp lệ !")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(10, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required(ErrorMessage = "Hãy lựa chọn ngôn ngữ của hệ thống")]
        public Languages Language { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [StringLength(30, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required(ErrorMessage = "Hãy chọn niên khoá")]
        public string AcademicYear { get; set; }

        [AllowNull]
        public string SchoolLogo { get; set; }

        //navigation property
        [ForeignKey("User")]
        public Guid Principals { get; set; }
        public virtual User? User { get; set; }

    }
}
