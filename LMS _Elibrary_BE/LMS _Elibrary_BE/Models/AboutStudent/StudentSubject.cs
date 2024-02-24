using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_Library_API.Models.AboutStudent
{
    public class StudentSubject
    {
        [ForeignKey("Student")]
        public Guid studentId { get; set; }
        public virtual Student Student { get; set; }

        [Column(TypeName = "varchar(20)")]
        [MaxLength(20)]
        [ForeignKey("Subject")]
        public string subjectId { get; set; }
        public virtual Subject Subject { get; set; }

        [Required]
        public bool subjectMark { get; set; }
    }
}
