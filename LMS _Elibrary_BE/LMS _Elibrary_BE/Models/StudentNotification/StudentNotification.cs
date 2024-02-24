using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_Library_API.Models.StudentNotification
{
    public class StudentNotification
    {
        [Key] public int Id { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [MaxLength(255)]
        [Required]
        public string Content { get; set; }

        [Required]
        public bool IsRead { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime TimeCounter { get; set; }


        //navigation property
        [ForeignKey("Student")]
        public Guid studentId { get; set; }
        public virtual Student Student { get; set; }

    }
}
