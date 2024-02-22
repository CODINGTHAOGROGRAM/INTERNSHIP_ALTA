using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS__Elibrary_BE.Models.Exams
{
    public class AnswerExam_MC
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar(255)")]
        [Required(ErrorMessage = "Vui lòng nhập câu trả lời")]

        public string Answer { get; set; }

        [Required]
        public bool CorrectAW { get; set; }

        //Navigation Links Table

        [ForeignKey("QuestionBank")]
        public int QuestionBankId { get; set; }
        public virtual QuestionBank QuestionBanks { get; set; }

    }
}
