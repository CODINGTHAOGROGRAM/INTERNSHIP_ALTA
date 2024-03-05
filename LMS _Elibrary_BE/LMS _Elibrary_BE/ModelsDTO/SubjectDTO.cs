using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS__Elibrary_BE.ModelsDTO
{
    public class SubjectDTO
    {
        [Column(TypeName = "varchar(20)")]
        [MaxLength(20)]
        [Key] public string Id { get; set; }

        [Column(TypeName = ("nvarchar(100)"))]
        [MaxLength(100)]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime SubmissionDate { get; set; } = DateTime.Now;

        [Column(TypeName = ("nvarchar(max)"))]
        [Required]
        public string Description { get; set; }

    }
}
