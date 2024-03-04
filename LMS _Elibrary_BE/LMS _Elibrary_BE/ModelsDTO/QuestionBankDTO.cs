using LMS__Elibrary_BE.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS__Elibrary_BE.ModelsDTO
{
    public class QuestionBankDTO
    {
        [Key] public int Id { get; set; }
        [Required]
        public Format Format { get; set; }

        [Column(TypeName = "nvarchar")]
        [Required]
        public string Content { get; set; }

        [Required]
        public Level Level { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.Now;

    }
}
