using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models.AboutSubject;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.LessonQuestionServices
{
    public class LessonQuestionService : ILessonQuestionService
    {
        private readonly DataContext _context;
        public LessonQuestionService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddQuestionToLesson(LessonQuestion question)
        {
            try
            {
                _context.LessonQuestions.Add(question);
                await _context.SaveChangesAsync();
                return "Thêm câu hỏi thành công";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm câu hỏi" + ex.Message);
            }
        }

        public async Task<string> DeleteQuestionFromLesson(int questionId)
        {
            try
            {
                var existingQuestion = await _context.LessonQuestions.FirstOrDefaultAsync(q => q.Id == questionId);
                if (existingQuestion != null)
                {
                    _context.LessonQuestions.Remove(existingQuestion);
                    await _context.SaveChangesAsync();
                    return "Xóa câu hỏi thành công";
                }
                return "Câu hỏi không tìm thấy để xóa";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện xóa" + ex.Message);
            }
        }

        public async Task<LessonQuestion> GetQuestionById(int questionId)
        {
            try
            {
                return await _context.LessonQuestions.FirstOrDefaultAsync(q => q.Id == questionId);
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện " + ex.Message);
            }
        }

        public async Task<List<LessonQuestion>> GetQuestions()
        {
            try
            {
                return await _context.LessonQuestions.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện truy vẫn" +ex.Message);
            }
        }

        public async Task<List<LessonQuestion>> GetQuestionsForLesson(int lessonId)
        {
            try
            {
                return await _context.LessonQuestions.Where(x => x.lessonId == lessonId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện chương trình" + ex.Message);
            }
        }

        public async Task<string> UpdateQuestionForLesson(int questionId, LessonQuestion updatedQuestion)
        {
            try
            {
                var question = await _context.LessonQuestions.FindAsync(questionId);
                if (question != null)
                {
                    question.content = updatedQuestion.content;
                    question.likesCounter = updatedQuestion.likesCounter;
                    // Cập nhật thời gian chỉ khi cần thiết
                    if (updatedQuestion.createdAt != default(DateTime))
                    {
                        question.createdAt = updatedQuestion.createdAt;
                    }
                    // Cập nhật người dùng chỉ khi cần thiết
                    if (updatedQuestion.teacherId != default(Guid))
                    {
                        question.teacherId = updatedQuestion.teacherId;
                    }
                    if (updatedQuestion.studentId != default(Guid))
                    {
                        question.studentId = updatedQuestion.studentId;
                    }
                    _context.Entry(question).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return "Câu hỏi được thêm thành công";
                }
                else
                {
                    return "Câu hỏi không tìm thấy";
                }
            }
            catch (Exception ex)
            {
               
                throw new Exception($"Lỗi khi thực hiện chức năng: {ex.Message}", ex);
            }
        }
    }
}
