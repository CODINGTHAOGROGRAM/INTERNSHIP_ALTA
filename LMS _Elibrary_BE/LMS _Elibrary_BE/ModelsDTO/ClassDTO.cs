using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS__Elibrary_BE.ModelsDTO
{
    public class ClassDTO
    {
        [Key]
        [Column(TypeName = "nvarchar(30)")]
        [MaxLength(30)]
        public string Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(30)]
        [Required]
        public string name { get; set; }

        [Required]
        public int totalStudent { get; set; }

    }
}
