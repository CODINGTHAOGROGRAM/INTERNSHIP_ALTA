using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_Library_API.Models.AboutSubject
{
    public class SubjectNotification
    {
        [Key] public int Id { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        [MaxLength(100)]
        [Required]
        public int title { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [MaxLength(100)]
        [Required]
        public int content { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        //navigation property
        [ForeignKey("Subject")]
        public string subjectId { get; set; }
        public virtual Subject Subject { get; set; }

        [ForeignKey("User")]
        public Guid teacherId { get; set; }
        public virtual User User { get; set; }

        [InverseProperty("SubjectNotification")]
        public virtual ICollection<NotificationClassStudent> NotificationClassStudents { get; set; }

    }
}
