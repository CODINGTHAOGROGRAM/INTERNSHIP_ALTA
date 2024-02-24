using LMS__Elibrary_BE.Enums;
using LMS_Library_API.Models.AboutStudent;
using LMS_Library_API.Models.AboutSubject;
using LMS_Library_API.Models.StudentNotification;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LMS_Library_API.Models
{
    public class Student
    {

        [Key]
        public Guid Id { get; set; } = new Guid();

        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required(ErrorMessage = "Hãy nhập tên người dùng")]
        public string FullName { get; set; }

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required(ErrorMessage = "Hãy nhâp email người dùng")]
        [RegularExpression("^[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*$",
            ErrorMessage = "Email không hợp lệ !")]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Hãy nhập ngày sinh người dùng")]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "varchar(20)")]
        [StringLength(20, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required(ErrorMessage = "Hãy nhập số điện thoại người dùng")]
        [RegularExpression("^(?:\\+84|0)\\d{9}$", ErrorMessage = "Số điện thoại không hợp lệ !")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [StringLength(150, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required(ErrorMessage = "Hãy nhập địa chỉ nhà của người dùng")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Hãy lựa chọn giới tính của người dùng")]
        [Range(1, 2, ErrorMessage = "Giới tính người dùng không hợp lệ")]
        public Gender Gender { get; set; }

        [AllowNull]
        public string Avartar { get; set; }
        public string Password { get; set; }

        //navigation property
        [ForeignKey("Class")]
        public string  classId { get; set; }
        public virtual Class Class { get; set; }

        [InverseProperty("Student")]
        public virtual ICollection<NotificationClassStudent> NotificationClassStudents { get; set; }

        public virtual ICollection<LessonAnswer> LessonAnswers { get; set; }

        public virtual ICollection<LessonQuestion> LessonQuestion { get; set; }

        public virtual StudentQnALikes StudentQnALikes { get; set; }

        [InverseProperty("Student")]
        public virtual ICollection<StudentNotificationSetting> StudentNotificationSetting { get; set; }

        public virtual ICollection<StudentNotification.StudentNotification> StudentNotifications { get; set; }

        [InverseProperty("Student")]
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }

        [InverseProperty("Student")]
        public virtual ICollection<StudyTime> StudyTimes { get; set; }

        [InverseProperty("Student")]
        public virtual ICollection<StudyHistory> StudyHistories { get; set; }


    }
}
