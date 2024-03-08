using LMS_Library_API.Models.Exams;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS__Elibrary_BE.Models.Exams
{
    public class ExamCreationRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int MC_Count { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int ES_Count { get; set; }

        // Navigation property 
        public ICollection<QuestionBanks> QuestionBanks { get; set; }

    }
}
