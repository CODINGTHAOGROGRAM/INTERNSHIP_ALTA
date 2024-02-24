using LMS_Library_API.Models.AboutStudent;
using LMS_Library_API.Models.AboutSubject;
using LMS_Library_API.Models.Exams;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LMS_Library_API.Models
{
    public class Subject
    {
        [Column(TypeName ="varchar(20)")]
        [MaxLength(20)]
        [Key] public string Id { get; set; }

        [Column(TypeName=("nvarchar(100)"))]
        [MaxLength(100)]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime SubmissionDate { get; set; } = DateTime.Now;

        [Column(TypeName = ("nvarchar(max)"))]
        [Required]
        public string Description { get; set; }


        //navigation property
        [ForeignKey("Department")]
        [Column(TypeName = "varchar(20)")]
        public string DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [ForeignKey("User")]
        public Guid TeacherId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CustomInfoOfSubject> CustomInfoOfSubjects { get; set; }
        public virtual ICollection<Part> Parts { get; set; }

        [JsonIgnore]
        public virtual ICollection<Exam> Exams { get; set; }

        [JsonIgnore]
        public virtual ICollection<QuestionBanks> QuestionBanks { get; set; }

        [JsonIgnore]
        public virtual ICollection<SubjectNotification> SubjectNotifications { get; set; }

        [JsonIgnore]
        [InverseProperty("Subject")]
        public virtual ICollection<StudentSubject>? StudentSubjects { get; set; }

        [JsonIgnore]
        [InverseProperty("Subject")]
        public virtual ICollection<ClassSubject>? ClassSubjects { get; set; }

        [JsonIgnore]
        [InverseProperty("Subject")]
        public virtual ICollection<StudyTime>? StudyTimes { get; set; }


    }
}
