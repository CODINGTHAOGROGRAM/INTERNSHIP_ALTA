using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LMS_Library_API.Models.AboutSubject
{
    public class NotificationClassStudent
    {
        [ForeignKey("SubjectNotification")]
        public int subjectNotificationId { get; set; }
        public virtual SubjectNotification SubjectNotification { get; set; }

        [ForeignKey("Class")]
        [Column(TypeName = "nvarchar(30)")]
        [MaxLength(30)]
        public string classId { get; set; }
        public virtual Class Class { get; set; }

        [ForeignKey("Student")]
        [AllowNull]
        public Guid studentId { get; set; }
        public virtual Student Student { get; set; }

        [Required]
        public bool isForAllStudent { get; set; }
    }
}
