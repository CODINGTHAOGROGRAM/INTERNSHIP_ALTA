using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_Library_API.Models.AboutUser
{
    public class Help
    {
        [Key] public int Id { get; set; }

        [Column(TypeName ="nvarchar(255)")]
        [Required]
        public string Content { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy - hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DateSent { get; set; } = DateTime.Now;

        //navigation property
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
