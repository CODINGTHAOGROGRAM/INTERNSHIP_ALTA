using LMS__Elibrary_BE.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS__Elibrary_BE.Models.Exams
{
    public class ExamBank
    {
        [Key]
        [Column("ID")]
        public int ExamBankID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Display(Name = "Tên bài kiểm")]
        public string ExamName { get; set; }

        [Required]
        public Format Format { get; set; }
        [Required]
        [Display(Name = "Thời gian làm bài")]
        public int Time { get; set; }

        public bool Status { get; set; }
        //Navigation Links Table

        [ForeignKey("Users")]
        public Guid Creator { get; set; }
        public virtual Users User { get; set; } 
        


    }
}
