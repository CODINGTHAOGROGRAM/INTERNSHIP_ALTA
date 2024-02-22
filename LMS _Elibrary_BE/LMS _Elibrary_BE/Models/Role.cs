using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS__Elibrary_BE.Models
{
    public class Role
    {
        [Key]
        [Column("Id")]
        public int RoleID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Vai trò")]
        [Required(ErrorMessage = "Hãy điền tên vai trò !")]
        public string RoleName { get; set; }

        //Navigation Link Tables
        public virtual ICollection<Users> User { get; set; }

    }
}
