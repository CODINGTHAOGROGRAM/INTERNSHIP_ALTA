using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LMS__Elibrary_BE.ModelsDTO
{
    public class NotificationDTO
    {
        [Key] public int Id { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [MaxLength(255)]
        [Required]
        public string Content { get; set; }

        [DefaultValue(false)]
        [Required]
        public bool IsRead { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime TimeCounter { get; set; }

    }
}
