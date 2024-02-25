using LMS__Elibrary_BE.Enums;
using LMS__Elibrary_BE.Models;
using LMS_Library_API.Models.AboutSubject;
using LMS_Library_API.Models.AboutUser;
using LMS_Library_API.Models.Exams;
using LMS_Library_API.Models.Notification;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace LMS_Library_API.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = new Guid();

        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50, ErrorMessage ="Vượt quá độ dài cho phép")]
        [Required(ErrorMessage ="Hãy nhập tên người dùng")]
        public string FullName { get; set; }

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required(ErrorMessage ="Hãy nhâp email người dùng")]
        [RegularExpression("^[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*$",
            ErrorMessage = "Email không hợp lệ !")]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage ="Hãy nhập ngày sinh người dùng")]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "varchar(20)")]
        [StringLength(20, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required(ErrorMessage ="Hãy nhập số điện thoại người dùng")]
        [RegularExpression("^(?:\\+84|0)\\d{9}$", ErrorMessage = "Số điện thoại không hợp lệ !")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [StringLength(150, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required(ErrorMessage ="Hãy nhập địa chỉ nhà của người dùng")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Hãy lựa chọn giới tính của người dùng")]
        [Range(1,2,ErrorMessage ="Giới tính người dùng không hợp lệ")]
        public Gender Gender { get; set; }

        [AllowNull]
        public string Avartar { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public string Password { get; set; }

        [DefaultValue(false)]
        [Required]
        public bool isLocked { get; set; }

        //navigation property
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        [ForeignKey("Department")]
        [Column(TypeName = "varchar(20)")]
        public string DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [JsonIgnore]
        [InverseProperty("User")]
        public virtual ICollection<ExamRecentViews> ExamRecentViews { get; set; }

        [JsonIgnore]
        [InverseProperty("Teacher")]
        public virtual ICollection<TeacherClass> TeacherClasses { get; set; }

        [JsonIgnore]
        public virtual QnALikes QnALikes { get; set; }

        [JsonIgnore]
        [InverseProperty("Recipient")]
        public virtual ICollection<Notification.Notification> Recipients { get; set; }

        [JsonIgnore]
        [InverseProperty("Sender")]
        public virtual ICollection<Notification.Notification> Senders { get; set; }

        [JsonIgnore]
        [InverseProperty("User")]
        public virtual ICollection<NotificationSetting> NotificationSetting { get; set; }


        [JsonIgnore]
        public virtual SystemInfomation SystemInfomation { get; set; }

        [JsonIgnore]
        public virtual Subject Subject { get; set; }

        [JsonIgnore]
        public virtual ICollection<PrivateFile> PrivateFiles { get; set; }

        [JsonIgnore]
        public virtual ICollection<Help> Helps { get; set; }

        [JsonIgnore]
        [InverseProperty("Censor")]
        public virtual ICollection<Exam> Censor { get; set; }

        [JsonIgnore]
        [InverseProperty("TeacherCreated")]
        public virtual ICollection<Exam> TeacherCreated { get; set; }

        [JsonIgnore]
        public virtual ICollection<QuestionBanks> QuestionBanks { get; set; }


        [JsonIgnore]
        [InverseProperty("Censor")]
        public virtual ICollection<Part> CensorPart { get; set; }

        [JsonIgnore]
        [InverseProperty("TeacherCreated")]
        public virtual ICollection<Part> TeacherCreatedPart { get; set; }

        [JsonIgnore]
        [InverseProperty("Censor")]
        public virtual ICollection<Lesson> CensorLesson { get; set; }

        [JsonIgnore]
        [InverseProperty("TeacherCreated")]
        public virtual ICollection<Lesson> TeacherCreatedLesson { get; set; }

        [JsonIgnore]
        [InverseProperty("Censor")]
        public virtual ICollection<Document> CensorDocument { get; set; }

        [JsonIgnore]
        [InverseProperty("TeacherCreated")]
        public virtual ICollection<Document> TeacherCreateDocument { get; set; }

        [JsonIgnore]
        public virtual ICollection<SubjectNotification> SubjectNotifications { get; set; }

        [JsonIgnore]
        public virtual ICollection<LessonAnswer> LessonAnswers { get; set; }

        [JsonIgnore]
        public virtual ICollection<LessonQuestion> LessonQuestions { get; set; }
    }
}
