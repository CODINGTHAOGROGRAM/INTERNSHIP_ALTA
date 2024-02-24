using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LMS_Library_API.Models.AboutSubject
{
    public class LessonQuestion
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="nvarchar(255)")]
        [MaxLength(255)]
        [Required]
        public string content { get; set; }

        [Required]
        public int likesCounter { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime createdAt { get; set; } = DateTime.Now;

        [Required]
        public bool isTeacher { get; set; }

        //navigation property

        [ForeignKey("Lesson")]
        public int lessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        [ForeignKey("User")]
        [AllowNull]
        public Guid teacherId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Student")]
        [AllowNull]
        public Guid studentId { get; set; }
        public virtual Student Student { get; set; }

        public virtual ICollection<LessonAnswer> LessonAnswers { get; set; }


    }
}
