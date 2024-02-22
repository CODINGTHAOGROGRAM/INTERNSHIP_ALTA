using System.ComponentModel.DataAnnotations;

namespace LMS__Elibrary_BE.Enums
{
    public enum Level
    {
        [Display(Name = "Dễ")]
        Normal = 1,
        [Display(Name = "Trung bình")]
        Medium = 2,
        [Display(Name = "Khó")]
        Hard = 3
    }
}
