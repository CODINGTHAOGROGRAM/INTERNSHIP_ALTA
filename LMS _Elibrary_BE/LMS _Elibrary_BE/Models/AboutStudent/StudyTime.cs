using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS_Library_API.Models.AboutStudent
{
    public class StudyTime
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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime studyDate { get; set; } = DateTime.Now;

        [Required]
        public int totalTime { get; set; }


    }
}
