using LMS_Library_API.Models.AboutSubject;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Services.DocumentServices
{
    public interface IDocumentService
    {
        Task<List<Document>> GetAllDocument();
        Task<List<Document>> GetDocumentsByLesson(int lessonId);
        Task<string> AddDocument(Document document);
        Task<string> DeleteDocument(int documentId);
        Task<string> UploadDocument(IFormFile file);
        Task<string> CreateDocumentFromLesson(int lessonId);
        Task<FileStreamResult> DownloadDocument(int documentId);
       
     
    }
}
