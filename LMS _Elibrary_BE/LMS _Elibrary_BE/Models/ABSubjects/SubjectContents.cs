using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS__Elibrary_BE.Models
{
    public class SubjectContents
    {
        [Key]
        [Column("ID")]
        public Guid? SubjectContentID { get; set; }
        public string? SubjectTittle {  get; set; }
        public string? ContentName { get; set; }

    }
}
