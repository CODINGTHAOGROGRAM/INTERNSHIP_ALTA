using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace LMS_Library_API.Models
{
    public class Department
    {
        [Key]
        [Column(TypeName ="varchar(20)")]
        [Required]
        public string Id { get; set; }

        [Column(TypeName ="nvarchar(150)")]
        public string Name { get; set; }


        //navigation property
        [JsonIgnore]
        public virtual ICollection<User>? Users { get; set; }
        [JsonIgnore]    
        public virtual ICollection<Subject>? Subjects { get; set; }
    }
}
