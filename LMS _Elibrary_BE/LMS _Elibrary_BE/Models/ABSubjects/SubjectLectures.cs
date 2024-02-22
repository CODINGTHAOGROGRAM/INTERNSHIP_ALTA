using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS__Elibrary_BE.Models
{
    public class SubjectLectures
    {
        [Key]
        [Column("ID")]
        public Guid? SubjectLectureID { get; set; }
        public string? Tittle { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int Size { get; set; }
        public bool Status { get; set; }

    }
}
