using LMS__Elibrary_BE.Enums;
using LMS_Library_API.Models.AboutStudent;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace LMS_Library_API.Models.AboutSubject
{
    public class Document
    {
        [Key] public int Id { get; set; }

        [Column(TypeName ="nvarchar(255)")]
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        //0: tai lieu, 1: bai giang
        [Required]
        public bool Type { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime submissionDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime updatedDate { get; set; } = DateTime.Now;

        [Column(TypeName = "nvarchar(255)")]
        [MaxLength(255)] 
        [Required]
        public string FilePath { get; set; }

        [Required]
        [DefaultValue(Status.PendingApproval)]
        public Status status { get; set; }

        [Column(TypeName ="nvarchar(255)")]
        [AllowNull]
        public string note { get; set; }

        //navigation property
        [JsonIgnore]
        [ForeignKey("Lesson")]
        public int lessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        [ForeignKey("Censor")]
        [AllowNull]
        public Guid? censorId { get; set; }
        public virtual User Censor { get; set; }

        [ForeignKey("TeacherCreated")]
        [Required]
        public Guid teacherCreatedId { get; set; }
        public virtual User TeacherCreated { get; set; }

        [JsonIgnore]
        [InverseProperty("Document")]
        public virtual ICollection<StudyHistory> StudyHistories { get; set; }
        [JsonIgnore]

        [InverseProperty("Document")]
        public virtual ICollection<DocumentAccess> DocumentAccess { get; set; }


    }
}
