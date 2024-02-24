namespace LMS_Library_API.Models.BlobStorage
{
    public class BlobObject
    {
        public Stream Content { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }

    }
}
