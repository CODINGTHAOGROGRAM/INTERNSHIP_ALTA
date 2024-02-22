using LMS__Elibrary_BE.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS__Elibrary_BE.Models
{
    
    public class FilePrivate
    {
        [Key]
        [Column("ID")]
        public int FilePrivateID { get; set; }

        [Column("Tên file",TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Vui lòng nhập tên file")]
        public string? NameFile { get; set; }

        [Column("Thể loại")]
        [Required(ErrorMessage = "Vui lòng chọn loại file!")]
        public TypeFile Type { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateChanged { get; set; } = DateTime.Now;


        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Người sửa đổi")]
        [Required(ErrorMessage = "Vui lòng điền tên !")]
        public string? Editor { get; set; }

        [Display(Name = "Kích thước")]
        public int Size { get; set; }


        //Navigation Link Tables
        [ForeignKey("Users")]
        public Guid UserID { get; set; }
        public virtual Users User { get; set; }
    }
}
