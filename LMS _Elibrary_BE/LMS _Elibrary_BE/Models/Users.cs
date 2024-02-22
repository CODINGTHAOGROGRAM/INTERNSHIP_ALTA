using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using LMS__Elibrary_BE.Enums;
using System.Text.Json.Serialization;
using LMS__Elibrary_BE.Models.Exams;
using LMS__Elibrary_BE.Models.Notifications;


namespace LMS__Elibrary_BE.Models
{
    public class Users
    {
        [Key]
        [Column("ID")]
        public Guid UserID { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Hãy điền họ !")]
        public string? FirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Hãy điền tên !")]
        public string? LastName { get; set; }

        [Column(TypeName = "varchar(100)")]
        [StringLength(50,ErrorMessage = "Độ dài không hợp lệ.")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Hãy điền email !")]
        [RegularExpression("^[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*$",ErrorMessage = "Email không hợp lệ !")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(15)")]
        [Required(ErrorMessage = "Hãy nhập số điện thoại !")]
        [StringLength(11,ErrorMessage = "Số điện thoại quá không hợp lệ !")]
        [Display(Name = "Số điện thoại")]
        [RegularExpression("^(?:\\+84|0)\\d{9}$", ErrorMessage = "Số điện thoại không hợp lệ !")]
        [MaxLength(11)]
        public string? PhoneNumber { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [StringLength(50,ErrorMessage = "Vượt quá độ dài cho phép!")]
        [Required(ErrorMessage = "Hãy nhập địa chỉ !")]
        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }

        [StringLength(500), AllowNull]
        [Display(Name = "Ảnh đại diện")]
        public string? AvtImage { get; set; }
        public IFormFile? ImageFile { get; set; }

        [Column(TypeName = "varchar(50)"), MaxLength(50), MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
        ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự bao gồm: chữ, số, viết hoa, viết thường và các ký tự đặc biệt như ~ ! / * .")]
        public string Password { get; set; }

        [Display(Name = "Trạng thái hoạt động")]
        public string? Status { get; set; }

        [Required(ErrorMessage = "Hãy chọn giới tính !"),
          Range(1, 2, ErrorMessage = "Giới tính không hợp lệ !")]
        [Display(Name = "Giới tính")]
        public Gender Gender { get; set; }

        //Navigation Link Tables

        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }

        [JsonIgnore]
        public virtual FilePrivate FilePrivate { get; set; }

        [JsonIgnore]
        public virtual ICollection<Subjects> subjects { get; set; }

        [JsonIgnore]
        public virtual ICollection<AnswerExam_ES> answerExam { get; set; }

        [JsonIgnore]
        public virtual ICollection<QvsA> QvsAs { get; set; }

        [JsonIgnore]
        public virtual ICollection<Notification.Notification> Notifications { get; set; }

        [JsonIgnore]
        [InverseProperty("Users")]
        public virtual ICollection<NotificationSetting> notificationSettings { get; set; }

        [JsonIgnore]
        public virtual ICollection<InforSystem> inforSystem { get; set; }

        [JsonIgnore]
        public virtual ICollection<HelpRequests> helpRequests { get; set; }
    }
}
