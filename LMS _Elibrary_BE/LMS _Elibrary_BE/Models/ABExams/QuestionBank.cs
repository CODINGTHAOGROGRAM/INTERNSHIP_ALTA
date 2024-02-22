using LMS__Elibrary_BE.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LMS__Elibrary_BE.Models.Exams
{
    public class QuestionBank
    {
        [Key]
        [Column("ID")]
        public int QuestionBankID { get; set; }

        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Vui lòng nhập câu hỏi")]
        [Column(TypeName = "nvarchar")]
        public string? QuestionContent { get; set; }
       
        [Required]                
        public Level DifficultLevel { get; set; }

        [Required]
        public Format Format { get; set; }
        public DateTime? DateCreate { get; set; } = DateTime.Now;


        // Navigation Links Table
        [ForeignKey("Users")]
        public Guid Creator { get; set; }
        public virtual Users User { get; set; }

        [ForeignKey("Subjects")]
        public string SubjectID { get; set; }
        public virtual Subjects Subject { get; set; }
        
        [JsonIgnore]       
        public virtual ICollection<AnswerExam_MC> AnswerExam_MC { get; set; }
        public virtual AnswerExam_ES AnswerExam_ES { get; set; }
    }
}
