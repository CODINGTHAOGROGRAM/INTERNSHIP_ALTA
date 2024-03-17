using System.ComponentModel.DataAnnotations;

namespace LMS__Elibrary_BE.ModelsDTO
{
    public class NotificationClassStudentDTO
    {
        public int? SubjectNotificationId { get; set; }

        [Required]
        [MaxLength(30)]
        public string classId { get; set; }

        public Guid? studentId { get; set; }

        [Required]
        public bool isForAllStudent { get; set; }
    }
}
