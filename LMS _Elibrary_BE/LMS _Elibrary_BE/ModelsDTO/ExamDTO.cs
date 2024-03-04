using LMS__Elibrary_BE.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LMS__Elibrary_BE.ModelsDTO
{
    public class ExamDTO
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
        public string FilePath { get; set; }

        [Required]
        public Status Status { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [MaxLength(255)]
        [AllowNull]
        public string Note { get; set; }

    }
}
