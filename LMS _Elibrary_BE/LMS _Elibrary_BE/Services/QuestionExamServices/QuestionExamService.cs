using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models.Exams;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.QuestionExamServices
{
    public class QuestionExamService : IQuestionExamService
    {
        private readonly DataContext _context;
        public QuestionExamService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddQuestionToExam(string examId, int questionId)
        {
            try
            {
                var questionExam = new Question_Exam
                {
                    ExamId = examId,
                    QuestionId = questionId
                };
                _context.Question_Exam.Add(questionExam);
                await _context.SaveChangesAsync();
                return ("Thêm thành công");
            }
            catch (Exception ex)
            {
                throw new Exception("Xảy ra lỗi khi thêm" + ex.Message, ex);
            }
        }

        public async Task<List<Exam>> GetExamsForQuestion(int questionId)
        {
            try
            {
                return await _context.Question_Exam.Where(s => s.QuestionId == questionId)
                                                   .Select(s => s.Exam)
                                                   .ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn danh sách" + ex.Message, ex);
            }
        }
        public async Task<List<Question_Exam>> GetQuestionsForExam(string examId)
        {
            try
            {
                return await _context.Question_Exam.Where(s => s.ExamId == examId).ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn danh sách" + ex.Message,ex);
            }
        }

        public async Task<string> RemoveQuestionFromExam(string examId, int questionId)
        {
            try
            {
                var questionExam = await _context.Question_Exam.FirstOrDefaultAsync(qe => qe.ExamId == examId && qe.QuestionId == questionId);

                if (questionExam != null)
                {
                    _context.Question_Exam.Remove(questionExam);
                    await _context.SaveChangesAsync();
                    return ("Xóa thành công");
                }
                return ("Không tìm thấy câu hỏi");
            }
            catch (Exception ex)
            {
                throw new Exception("Xuất hiện lỗi khi xóa" + ex.Message, ex);
            }
        }
    }
}
