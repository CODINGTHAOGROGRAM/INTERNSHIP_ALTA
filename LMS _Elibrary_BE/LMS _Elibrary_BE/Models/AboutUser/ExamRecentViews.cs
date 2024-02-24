using LMS_Library_API.Models.Exams;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LMS_Library_API.Models.AboutUser
{
    public class ExamRecentViews
    {

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }

        [ForeignKey("Exam")]
        [Column(TypeName = "varchar(30)")]
        public string ExamId { get; set; }
        public virtual Exam Exam { get; set; }
    }
}
