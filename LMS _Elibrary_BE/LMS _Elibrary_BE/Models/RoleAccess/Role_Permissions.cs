using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LMS_Library_API.Models.RoleAccess
{
    public class Role_Permissions
    {
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        [ForeignKey("Permissions")]
        public int PermissionsId { get; set; }

        [Required]
        public bool CanAccess { get; set; } = false;

        //navigation property
        [JsonIgnore]
        public virtual Role? Role { get; set; }
        public virtual Permissions? Permissions { get; set; }
    }
}
