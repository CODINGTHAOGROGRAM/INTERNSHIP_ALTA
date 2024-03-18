using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS__Elibrary_BE.ModelsDTO
{
    public class HelpDTO
    {
        [Key] public int Id { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public string Content { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy - hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DateSent { get; set; } = DateTime.Now;
    }
}
