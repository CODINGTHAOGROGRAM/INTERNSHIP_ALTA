using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LMS__Elibrary_BE.Models.Notification
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName= "nvarchar(255)")]
        [MaxLength(255)]
        public string Content { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime DateStart { get; set; }
        [Display(Name = "Trại thái")]
        [DefaultValue(false)]
        public bool Status { get; set; }

        //Navigation Links Table
        [ForeignKey("Users")]
        public Guid UserID { get; set; }
        public virtual Users User { get; set; } 
    }
}
