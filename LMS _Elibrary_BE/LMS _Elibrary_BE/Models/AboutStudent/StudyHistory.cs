using LMS_Library_API.Models.AboutSubject;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_Library_API.Models.AboutStudent
{
    public class StudyHistory
    {
        [ForeignKey("Student")]
        public Guid studentId { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("Document")]
        public int documentId { get; set; }
        public virtual Document Document { get; set; }

        [Required]
        public int watchMinutes { get; set; }
    }
}
