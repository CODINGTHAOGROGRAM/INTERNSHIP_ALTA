using LMS__Elibrary_BE.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LMS__Elibrary_BE.Models
{
   
    public class InforSystem
    {
        [Key]
        [Column("ID")]
        public int InforSystemID { get; set; }


        [StringLength(100,ErrorMessage = "Vui lòng nhập lại tên trường !")]
        [Display(Name = "Tên trường")]
        public string NameSchool { get; set; }

        [StringLength(150,ErrorMessage = "Đường dẫn quá dài so với quy định !")]
        [Display(Name = "Link Website")]
        public string PathWebsite { get; set; }

        [Column(TypeName = "varchar(100)")]
        [StringLength(50, ErrorMessage = "Độ dài không hợp lệ.")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Hãy điền email !")]
        [RegularExpression("^[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*$", ErrorMessage = "Email không hợp lệ !")]
        public string Email {  get; set; }

        [Display(Name = "Loại trường")]
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Vui lòng chọn loại trường")]
        public TypeSchool TypeSchool { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required(ErrorMessage = "Hãy nhập tên hệ thống thư viện của trường")]
        public string NameSystem { get; set; }

        [Column(TypeName = "varchar(15)")]
        [Required(ErrorMessage = "Hãy nhập số điện thoại !")]
        [StringLength(11, ErrorMessage = "Số điện thoại quá không hợp lệ !")]
        [Display(Name = "Số điện thoại")]
        [RegularExpression("^(?:\\+84|0)\\d{9}$", ErrorMessage = "Số điện thoại không hợp lệ !")]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "varchar(30)")]
        [StringLength(10, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required(ErrorMessage = "Hãy lựa chọn ngôn ngữ của hệ thống")]
        public Languages languages { get; set; }

        [AllowNull]
        public string AvtSystem { get; set; }

        //Navigation Link Tables
        [ForeignKey("Users")]
        public Guid Principal { get; set; }
        public virtual Users? Users { get; set; }
    }
}
