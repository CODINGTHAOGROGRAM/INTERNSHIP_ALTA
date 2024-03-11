using LMS_Library_API.Models.AboutSubject;

namespace LMS__Elibrary_BE.Services.DocumentAccessServices
{
    public interface IDocumentAccessService
    {
        Task<List<DocumentAccess>> GetAllDocumentAccess();
        Task<DocumentAccess> GetDocumentAccessById( int documentId );
        Task<string> DeleteDocumentAccess( int documentId );
        Task<string> UpdateDocumentAccess(DocumentAccess documentAccess);
        Task<DocumentAccess> GetDocumentAccessForClass(int documentId, string classId);
        Task<string> AddDocumentAccessForClass(int documentId, string classId, bool isForAllClasses);
        Task<string> DeleteDocumentAccessForClass(int documentId, string classId);

    }
}
