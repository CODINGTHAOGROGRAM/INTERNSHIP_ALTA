using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LMS__Elibrary_BE.ModelsDTO
{
    public class FileDTO
    {
        [Key] public int Id { get; set; }

        [Column(TypeName = "nvarchar(150)")]
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
    }
}
