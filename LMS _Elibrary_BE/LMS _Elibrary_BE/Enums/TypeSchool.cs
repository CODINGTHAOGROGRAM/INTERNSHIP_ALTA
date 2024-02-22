using System.ComponentModel.DataAnnotations;

namespace LMS__Elibrary_BE.Enums
{
    public enum TypeSchool
    {
        [Display(Name = "Tiểu học")]
        PrimaryShool = 1,
        [Display(Name = "Đại học")]
        University = 2
    }
}
