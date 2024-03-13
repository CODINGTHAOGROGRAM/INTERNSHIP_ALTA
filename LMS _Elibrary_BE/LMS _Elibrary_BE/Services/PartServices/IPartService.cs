using LMS_Library_API.Models.AboutSubject;

namespace LMS__Elibrary_BE.Services.PartServices
{
    public interface IPartService
    {
        Task<List<Part>> GetPartsBySubject(string subjectId);
        Task<string> AddPart(Part part);
        Task<string> UpdatePart(int partId, Part updatedPart);
        Task<string> DeletePart(int partId);



    }
}
