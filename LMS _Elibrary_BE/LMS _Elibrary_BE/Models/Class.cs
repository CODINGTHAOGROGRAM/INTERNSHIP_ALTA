using LMS_Library_API.Models.AboutStudent;
using LMS_Library_API.Models.AboutSubject;
using LMS_Library_API.Models.AboutUser;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_Library_API.Models
{
    public class Class
    {
        [Key]
        [Column(TypeName = "nvarchar(30)")]
        [MaxLength(30)]
        public string Id { get; set; }


        [Column(TypeName ="nvarchar(50)")]
        [MaxLength(30)]
        [Required]
        public string name { get; set; }

        [Required]
        public int totalStudent { get; set; }

        //navigation property
        [InverseProperty("Class")]
        public virtual ICollection<NotificationClassStudent> NotificationClassStudents { get; set; }


        public virtual ICollection<Student> Students { get; set; }


        [InverseProperty("Class")]
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }

        [InverseProperty("Class")]
        public virtual ICollection<TeacherClass> TeacherClasses { get; set; }

        [InverseProperty("Class")]
        public virtual ICollection<LessonAccess> LessonAccess { get; set; }

        [InverseProperty("Class")]
        public virtual ICollection<DocumentAccess> DocumentAccess { get; set; }
    }
}
