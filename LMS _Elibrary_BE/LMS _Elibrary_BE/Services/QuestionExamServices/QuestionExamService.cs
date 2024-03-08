using LMS_Library_API.Models.Exams;

namespace LMS__Elibrary_BE.Services.QuestionExamServices
{
    public class QuestionExamService : IQuestionExamService
    {
        public Task<string> AddQuestionToExam(string examId, int questionId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Exam>> GetExamsForQuestion(int questionId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Question_Exam>> GetQuestionsForExam(string examId)
        {
            throw new NotImplementedException();
        }

        public Task<string> RemoveQuestionFromExam(string examId, int questionId)
        {
            throw new NotImplementedException();
        }
    }
}
