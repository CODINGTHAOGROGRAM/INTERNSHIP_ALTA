using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS__Elibrary_BE.Models
{
    public class Subjects
    {
        [Key]
        [Column("ID")]
        public Guid? SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public DateTime ApprovalDate { get; set; } = DateTime.Now;
        public bool? Status { get; set; }
        public string? Description {  get; set; }
       
    }
}
