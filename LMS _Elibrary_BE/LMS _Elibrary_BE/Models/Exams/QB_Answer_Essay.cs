using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LMS_Library_API.Models.Exams
{
    public class QB_Answer_Essay
    {
        [Key] public int  Id { get; set; }

        [Column(TypeName ="bit")]
        [Required]
        public bool SubmitType { get; set; }

        [AllowNull]
        public int LimitWord { get; set; }

        //navigation property
        [ForeignKey("QuestionBanks")]
        public int QuestionId { get; set; }
        public virtual QuestionBanks QuestionBanks { get; set; }
    }
}
