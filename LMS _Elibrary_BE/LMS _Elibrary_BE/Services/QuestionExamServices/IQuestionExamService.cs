using LMS__Elibrary_BE.Models.Exams;
using LMS_Library_API.Models.Exams;

namespace LMS__Elibrary_BE.Services.QuestionExamServices
{
    public interface IQuestionExamService
    {
        Task<List<Question_Exam>> GetQuestionsForExam(string examId);
        Task<List<Exam>> GetExamsForQuestion(int questionId);
        Task<string> AddQuestionToExam(string examId, int questionId);
        Task<string> RemoveQuestionFromExam(string examId, int questionId);
        Task<List<QB_Answer_MC>> GetMCAnswersForQuestion(int questionId);
        Task<List<QB_Answer_Essay>> GetEssayAnswersForQuestion(int questionId);
        Task<string> UpdateAnswerContent(int questionId,  string newAnswerContent);
        Task<string> CreateNewExamFromQuestionBank(ExamCreationRequest examModel);
    }
}
