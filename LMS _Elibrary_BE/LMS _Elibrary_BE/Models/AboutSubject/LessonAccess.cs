using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS_Library_API.Models.AboutSubject
{
    public class LessonAccess
    {
        [Key]
        [ForeignKey("Lesson")]
        public int lessonId { get; set; }
        public virtual Lesson Lesson { get; set; }


        [Column(TypeName = "nvarchar(30)")]
        [MaxLength(30)]
        [ForeignKey("Class")]
        public string classId { get; set; }
        public virtual Class Class { get; set; }

        [Required]
        public bool isForAllClasses { get; set; }
    }
}
