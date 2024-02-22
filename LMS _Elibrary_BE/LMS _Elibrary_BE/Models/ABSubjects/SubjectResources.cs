using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS__Elibrary_BE.Models
{
    public class SubjectResources
    {
        [Key]
        [Column("ID")]
        public Guid? SubjectResourceID { get; set; }
        public string? ResourceTittle { get; set; }
        public string? ResourceType { get; set; }
        public string? Creator { get; set; }
        public string? ResourceContent { get; set; }
        public DateTime? DateCreate { get; set; }
        public bool Status { get; set; }
        public int Size { get; set; }

    }
}
