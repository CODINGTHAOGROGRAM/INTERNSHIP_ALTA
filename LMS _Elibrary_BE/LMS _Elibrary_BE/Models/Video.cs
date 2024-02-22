using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LMS__Elibrary_BE.Models
{
    public class Video
    {
        [Key]
        [Column("ID")]
        public int VideoID { get; set; }
        
        [StringLength(100,ErrorMessage = "Vượt quá độ dài quy định")]
        [Required(ErrorMessage = "Vui lòng nhập tên video")]
        [Display(Name = "Tên video")]
        [Column(TypeName = "nvarchar(150)")]
        public string VideoName { get; set; }

       
        [Required(ErrorMessage = "Vui lòng mô tả video")]
        [Display(Name = "Mô tả")]
        [Column(TypeName = "nvarchar(250)")]
        public string VideoDescription { get; set; }
        
        [StringLength(50,ErrorMessage = "Vượt quá độ dài quy định")]
        [Required(ErrorMessage = "Trường đường dẫn video")]
        [Column(TypeName = "varchar(50)")]
        public string Path { get; set; }

        [Display(Name = "Thời lượng video")]
        public int Duration { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateUpdate { get; set; }

        //Navigation Link Tables
        [JsonIgnore]
        public virtual ICollection<QvsA> QvsAs { get; set; }


    }
}
