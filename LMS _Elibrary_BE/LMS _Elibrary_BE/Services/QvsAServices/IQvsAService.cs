using LMS_Library_API.Models.AboutUser;

namespace LMS__Elibrary_BE.Services.QvsAServices
{
    public interface IQvsAService
    {
        Task<QnALikeDTO> GetQnALikesByUserId(Guid userId);
        Task<string> UpdateQnALikes(Guid userId, QnALikeDTO updatedQnALikes);
        Task<List<QnALikeDTO>> GetLikedQuestionsById(Guid userId);
        Task<List<QnALikeDTO>> GetLikedAnswersById(Guid userId);
        Task<string> ClearLikedQuestions(Guid userId);
        Task<string> ClearLikedAnswers(Guid userId);
    }
}
