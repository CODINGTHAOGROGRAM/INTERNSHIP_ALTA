using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS_Library_API.Models.AboutUser
{
    public class TeacherClass
    {

        [ForeignKey("Teacher")]
        public Guid teacherId { get; set; }
        public virtual User Teacher { get; set; }


        [Column(TypeName = "nvarchar(30)")]
        [MaxLength(30)]
        [ForeignKey("Class")]
        public string classId { get; set; }
        public virtual Class Class { get; set; }

        
    }
}
