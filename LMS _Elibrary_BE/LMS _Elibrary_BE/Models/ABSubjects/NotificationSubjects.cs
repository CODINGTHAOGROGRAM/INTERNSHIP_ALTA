using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace LMS__Elibrary_BE.Models
{
    public class NotificationSubjects
    {
        [Key]
        [Column("ID")]
        public int NotiSubID { get; set; }
        public string Tittle { get; set; }
        public string Content { get; set; }
        public DateTime DateStart { get; set; }
        public bool Status { get; set; }
        

    }
}
