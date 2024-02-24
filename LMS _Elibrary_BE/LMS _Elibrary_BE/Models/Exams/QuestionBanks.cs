using LMS__Elibrary_BE.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_Library_API.Models.Exams
{
    public class QuestionBanks
    {
        [Key] public int Id { get; set; }

        [Required]
        public bool Format { get; set; }

        [Column(TypeName ="nvarchar")]
        [Required]
        public string Content { get; set; }

        [Required]
        public Level Level { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.Now;

        //navigation property

        [ForeignKey("User")]
        public Guid TeacherCreatedId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Subject")]
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public virtual ICollection<QB_Answer_MC> QB_Answers_MC { get; set; }

        public virtual QB_Answer_Essay QB_Answer_Essay { get; set; }

        [InverseProperty("QuestionBanks")]
        public virtual ICollection<Question_Exam> Question_Exam { get; set; }
    }
}
