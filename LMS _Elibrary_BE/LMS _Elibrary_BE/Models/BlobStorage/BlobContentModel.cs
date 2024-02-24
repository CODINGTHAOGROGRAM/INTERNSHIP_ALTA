using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LMS_Library_API.Models.BlobStorage
{
    public class BlobContentModel
    {
        public string? FilePath { get; set; }
        public string? FileName { get; set; }
        [DefaultValue(true)]
        public bool isImage { get; set; }
    }
}
