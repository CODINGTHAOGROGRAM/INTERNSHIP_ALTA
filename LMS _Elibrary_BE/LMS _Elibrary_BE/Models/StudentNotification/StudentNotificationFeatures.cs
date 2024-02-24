
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_Library_API.Models.StudentNotification
{
    public class StudentNotificationFeatures
    {
        [Key] public int Id { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        [Required]
        public string featureType { get; set; }

        //navigation property
        [InverseProperty("StudentNotificationFeatures")]
        public virtual ICollection<StudentNotificationSetting> StudentNotificationSetting { get; set; }
    }
}
