using LMS__Elibrary_BE.Enums;
using LMS_Library_API.Models.Exams;

namespace LMS__Elibrary_BE.Services.QuestionBankServices
{
    public interface IQuestionBankService
    {
        Task<List<QuestionBanks>> GetAllQuestionBanks();
        Task<QuestionBanks> GetQuestionBankId(int  questionBankId);
        Task<string> AddNew(QuestionBanks questionBank);
        Task<string> UpdateQuestionBank(QuestionBanks questionBank);
        Task<string> DeleteQuestionBank(int questionBankId);
        Task<IEnumerable<QuestionBanks>> GetQuestionBanksByTopic(int topicId);
        Task<IEnumerable<QuestionBanks>> GetQuestionBanksByDifficulty(Level difficultyLevel);
        Task<IEnumerable<QuestionBanks>> SearchQuestionBanks(string searchTerm, string[] searchFields);
        Task<QuestionBanks> GetRandomQuestionBank();
        Task<IEnumerable<QuestionBanks>> PaginationQuestionBanks(int pageNumber, int pageSize);
    }
}
