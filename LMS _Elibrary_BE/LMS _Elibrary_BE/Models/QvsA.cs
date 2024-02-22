using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS__Elibrary_BE.Models
{
    public class QvsA
    {
        [Key]
        [Column("ID")]
        public Guid QvsAID { get; set; }

        [Display(Name = "Tiêu đề")]
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Vui lòng nhập tiêu đề câu hỏi !")]
        [StringLength(100,ErrorMessage = "Vượt quá độ dài quy định !")]
        public string Tittle {  get; set; }

        [Display(Name = "Nội dung")]
        [Column(TypeName = "nvarchar(200)")]
        [Required(ErrorMessage = "Vui lòng nhập nội dung !")]
        public string Content { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateCreate { get; set; }

        public int Like { get; set; }
        public int Share { get; set; }

        //Navigation Link Tables
        [ForeignKey("Users")]
        public Guid UserID { get; set; }
        public virtual Users Users { get; set; }

        [ForeignKey("Video")]
        public int VideoId { get; set; }    
        public virtual Video Video { get; set; }
    }
}
