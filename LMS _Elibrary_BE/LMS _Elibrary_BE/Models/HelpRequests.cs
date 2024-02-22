using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS__Elibrary_BE.Models
{
    public class HelpRequests
    {
        [Key]
        [Column("ID")]
        public int HelpID { get; set; }

        [Display(Name = "Nội dung")]
        [MaxLength(250,ErrorMessage = "Nội dung quá dài")]
        [Required(ErrorMessage = " Vui lòng nhập câu hỏi !")]
        public string QuestionContent { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Ngày gửi")]
        public DateTime DateStart { get; set; }


        //Navigation Link Tables
        [ForeignKey("Users")]
        public Guid UserID { get; set; }
        public virtual Users User { get; set; }


    }
}
