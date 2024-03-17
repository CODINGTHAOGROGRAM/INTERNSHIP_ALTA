using LMS__Elibrary_BE.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LMS__Elibrary_BE.ModelsDTO
{
    public class PartDTO
    {
        [Key] public int Id { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public string name { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dateSubmited { get; set; } = DateTime.Now;

        public bool isHidden { get; set; } = false;

        [Required]
        public int numericalOrder { get; set; }

        [Required]
        public Status status { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [AllowNull]
        public string? note { get; set; }
    }
}
