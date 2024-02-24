using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LMS_Library_API.Models.AboutUser
{
    public class QnALikes
    {
        [Key]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [Column(TypeName ="varchar(max)")]
        [AllowNull]
        public string QuestionsLikedID { get; set; }

        [Column(TypeName = "varchar(max)")]
        [AllowNull]
        public string AnswersLikedID { get; set; }

        //navigation property
        [JsonIgnore]
        public virtual User? User { get; set; }
    }

}
