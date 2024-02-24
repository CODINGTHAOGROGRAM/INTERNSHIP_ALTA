using System.ComponentModel.DataAnnotations;

namespace LMS__Elibrary_BE.Enums
{
    public enum Status
    {
        [Display(Name = "Chưa gửi phê duyệt")]
        Unsubmitted = 0,
        [Display(Name = "Đang chờ phê duyệt")]
        PendingApproval = 1,
        [Display(Name = "Đã phê duyệt")]
        Approved = 2,
        [Display(Name = "Đã từ chối duyệt")]
        RefuseApproval = 3,
        [Display(Name = "Đã huỷ phê duyệt")]
        CancelApproval = 4
    }
}
