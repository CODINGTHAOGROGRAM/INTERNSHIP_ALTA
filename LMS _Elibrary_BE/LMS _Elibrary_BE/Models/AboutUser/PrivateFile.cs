using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_Library_API.Models.AboutUser
{
    public class PrivateFile
    {
        [Key] public int Id { get; set; }

        [Column(TypeName ="nvarchar(150)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Modifier { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateChanged { get; set; } = DateTime.Now;

        [Column(TypeName = "nvarchar(max)")]
        [Required]
        public string FilePath { get; set; }

        [DefaultValue(false)]
        public bool IsImage { get; set; }

        //navigation property
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
