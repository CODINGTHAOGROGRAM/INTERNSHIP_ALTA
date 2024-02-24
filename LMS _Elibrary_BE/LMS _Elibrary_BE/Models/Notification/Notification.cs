using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_Library_API.Models.Notification
{
    public class Notification
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


        //navigation property
        [ForeignKey("Recipients")]
        public Guid RecipientId { get; set; }
        public virtual User? Recipient { get; set; }

        [ForeignKey("Sender")]
        public Guid SenderId { get; set; }
        public virtual User? Sender { get; set; }

    }
}
