using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LMS_Library_API.Models.AboutStudent
{
    public class StudentQnALikes
    {
        [Key]
        [ForeignKey("Student")]
        public Guid studentId { get; set; }

        [Column(TypeName ="varchar")]
        [AllowNull]
        public string QuestionsLikedID { get; set; }

        [Column(TypeName ="varchar")]
        [AllowNull]
        public string AnswersLikedID { get; set; }

        //navigation property
        public virtual Student Student { get; set; }
    }
}
