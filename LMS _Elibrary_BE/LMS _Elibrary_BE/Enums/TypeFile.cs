using System.ComponentModel.DataAnnotations;

namespace LMS__Elibrary_BE.Enums
{
    public enum TypeFile
    {
        [Display(Name = "Video")]
        Vid = 1,
        [Display(Name = "Word")]
        doc = 2,
        [Display(Name = "PowerPont")]
        ppt = 3,
        [Display(Name = "Excel")]
        xls = 4,
        [Display(Name = "PDF")]
        pdf = 5
    }
}
