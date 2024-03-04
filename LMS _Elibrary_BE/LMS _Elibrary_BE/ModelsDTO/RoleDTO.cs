using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LMS__Elibrary_BE.ModelsDTO
{
    public class RoleDTO
    {
        [Key] public int Id { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [AllowNull]
        public string Description { get; set; }

        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
