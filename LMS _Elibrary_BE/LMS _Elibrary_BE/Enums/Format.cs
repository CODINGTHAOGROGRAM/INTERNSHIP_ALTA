using System.ComponentModel.DataAnnotations;

namespace LMS__Elibrary_BE.Enums
{
    public enum Format
    {
        [Display(Name = "Trắc nghiệm")]
        Mc = 1,
        [Display(Name = "Tự luận")]
        Es = 2
    }
}
