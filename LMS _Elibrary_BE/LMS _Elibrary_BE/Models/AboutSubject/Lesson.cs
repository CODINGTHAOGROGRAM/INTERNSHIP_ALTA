using LMS__Elibrary_BE.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LMS_Library_API.Models.AboutSubject
{
    public class Lesson
    {
        [Key] public int Id { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public string title { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dateSubmited { get; set; } = DateTime.Now;

        public bool isHidden { get; set; } = false;

        [Required]        
        public int numericalOrder { get; set; }

        [Required]
        public Status status { get; set; }

        [Column(TypeName ="nvarchar(255)")]
        [AllowNull]
        public string note { get; set; }

        //navigation property

        [ForeignKey("Part")]
        public int partId { get; set; }
        public virtual Part Part { get; set; }

        [ForeignKey("Censor")]
        [AllowNull]
        public Guid censorId { get; set; }
        public virtual User Censor { get; set; }


        [ForeignKey("TeacherCreated")]
        [Required]
        public Guid teacherCreatedId { get; set; }
        public virtual User TeacherCreated { get; set; }

        public virtual ICollection<LessonQuestion> LessonQuestions { get; set; }

        public virtual ICollection<Document> Documents { get; set; }

        [JsonIgnore]
        [InverseProperty("Lesson")]
        public virtual ICollection<LessonAccess> LessonAccess { get; set; }
    }
}
