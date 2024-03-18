namespace LMS__Elibrary_BE.ModelsDTO
{
    public class NotificationSettingDTO
    {
        public Guid UserId { get; set; }
        public int FeaturesId { get; set; }
        public bool ReceiveNotification { get; set; }
    }
}
