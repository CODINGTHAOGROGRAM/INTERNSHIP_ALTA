using LMS__Elibrary_BE.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS__Elibrary_BE.Models.Exams
{
    
    public class ListExam
    {
        [Key]
        [Column("ID")]
        public int ListExamID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(100, ErrorMessage = "Vượt quá độ dài cho phép")]
        public string ExamName { get; set; }
       
        [Required]       
        public Format Format { get; set; }
        
        [Required]
        [Display(Name = "Thời gian")]
        public int TimeLimit { get; set; }

        [Column(TypeName = "varchar")]
        [Required]
        public string FilePath { get; set; }

        [Required]
        public bool Status { get; set; }
        public DateTime? DateCreate { get; set; } = DateTime.Now;

        //Navigation Links Table
        
        [ForeignKey("Users")]
        public Guid Creator { get; set; }
        public virtual Users User { get; set; }
        
        
        [ForeignKey("Subject")]
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string SubjectId { get; set; }
        public virtual Subjects Subject { get; set; }

        [InverseProperty("ListExam")]
        public virtual ICollection<ListExam> ListEx { get; set; }

        

    }
}
