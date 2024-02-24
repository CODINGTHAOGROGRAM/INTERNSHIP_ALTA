using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_Library_API.Models.Exams
{
    public class QB_Answer_MC
    {
        [Key] public int Id { get; set; }

        [Column(TypeName ="nvarchar(255)")]
        [MaxLength(255)]
        [Required]
        public string AnswerContent { get; set; }

        [Required]
        public bool IsCorrect { get; set; }

        //navigation property
        [ForeignKey("QuestionBanks")]
        public int QuestionId { get; set; }
        public virtual QuestionBanks QuestionBanks { get; set; }
    }
}
