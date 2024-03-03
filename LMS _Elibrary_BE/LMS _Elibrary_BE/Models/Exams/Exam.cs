using LMS__Elibrary_BE.Enums;
using LMS_Library_API.Models.AboutUser;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LMS_Library_API.Models.Exams
{
    public class Exam
    {
        [Column(TypeName = "varchar(30)")]
        [Key] public string Id { get; set; }

       
        [Required]
        public TypeFile FileType { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100, ErrorMessage = "Vượt quá độ dài cho phép")]
        [Required]
        public string FileName { get; set; }
       
        [Required]
        public Format Format { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Column(TypeName = "varchar")]
        [Required]
        public string FilePath {get; set; }

        [Required]
        public Status Status { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [MaxLength(255)]
        [AllowNull]  
        public string Note { get; set; }


        //navigation property
        [ForeignKey("Censor")]
        [AllowNull]
        public Guid CensorId { get; set; }
        public virtual User Censor { get; set; }


        [ForeignKey("TeacherCreated")]
        [Required]
        public Guid TeacherCreatedId { get; set; }
        public virtual User TeacherCreated { get; set; }

        [ForeignKey("Subject")]
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        [JsonIgnore]
        [InverseProperty("Exam")]
        public virtual ICollection<Question_Exam> Question_Exam { get; set; }

        [JsonIgnore]
        [InverseProperty("Exam")]
        public virtual ICollection<ExamRecentViews> ExamRecentViews { get; set; }

    }
}
