using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS__Elibrary_BE.Models
{
    public class SubjectTopics
    {
        [Key]
        [Column("ID")]
        public Guid? SubjectTopicID { get; set; }
        public string? TopicName { get; set; }
        public string? Description { get; set; }
    }
}
