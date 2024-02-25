using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using LMS_Library_API.Models.Notification;
using System.Text.Json.Serialization;
using LMS_Library_API.Models;

namespace LMS__Elibrary_BE.Models
{
    public class Role
    {
        [Key] public int Id { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [AllowNull]
        public string Description { get; set; }

        public DateTime DateUpdated { get; set; } = DateTime.Now;

        //navigation property
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }

        
    }
}
