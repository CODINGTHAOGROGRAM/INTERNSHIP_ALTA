using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LMS_Library_API.Models.AboutSubject
{
    public class DocumentAccess
    {
        [Key]
        [ForeignKey("Document")]
        public int documentId { get; set; }
        public virtual Document Document { get; set; }


        [Column(TypeName = "nvarchar(30)")]
        [MaxLength(30)]
        [ForeignKey("Class")]
        [AllowNull]
        public string classId { get; set; }
        public virtual Class Class { get; set; }

        [Required]
        public bool isForAllClasses { get; set; }

    }
}
