using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS__Elibrary_BE.Models.Exams
{
    public class AnswerExam_ES
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [MaxLength(255)]
        [Required(ErrorMessage = "Vui lòng nhập câu trả lời" )]
        public string Answer { get; set; }

        [Required(ErrorMessage = "Giới hạn từ cho phép")]
        public int LimitWord { get; set; }
        //Navigation Links Table

        [ForeignKey("QuestionBank")]
        public int QuestionBankId { get; set; }
        public virtual QuestionBank QuestionBanks { get; set; }


    }
}
