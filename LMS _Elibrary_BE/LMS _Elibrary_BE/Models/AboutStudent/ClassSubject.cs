using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS_Library_API.Models.AboutStudent
{
    public class ClassSubject
    {
        [Column(TypeName = "nvarchar(30)")]
        [MaxLength(30)]
        [ForeignKey("Class")]
        public string classId { get; set; }
        public virtual Class Class { get; set; }

        [Column(TypeName = "varchar(20)")]
        [MaxLength(20)]
        [ForeignKey("Subject")]
        public string subjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
