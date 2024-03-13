using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models.AboutSubject;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.LessonAnswerServices
{
    public class LessonAnswerService : ILessonAnswerService
    {
        private readonly DataContext _context;
        public LessonAnswerService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddAnswerToLessonQuestion(LessonAnswer answer)
        {
            try
            {
                _context.LessonAnswers.Add(answer);
                await _context.SaveChangesAsync();
                return "Thêm thành công";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm câu hỏi vào bào học" +ex.Message);
            }
        }

        public async Task<string> DeleteAnswerToLessonQuestion(int answerId)
        {
            try
            {
                var exitsAnswer = await _context.LessonAnswers.FirstOrDefaultAsync(x => x.Id == answerId);
                if (exitsAnswer != null)
                {
                    _context.Remove(exitsAnswer);
                    await _context.SaveChangesAsync();
                    return "Xóa thành công";
                }
                return "Không tìm thấy câu hỏi cần xóa";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi tìm câu hỏi cần xóa"+ ex.Message);
            }
        }

        public async Task<List<LessonAnswer>> GetAllAnswers()
        {
            try
            {
                return await _context.LessonAnswers.ToListAsync();
            }
            catch { return new List<LessonAnswer>(); }
        }

        public async Task<LessonAnswer> GetAnswerById(int answerId)
        {
            try
            {
                return await _context.LessonAnswers.FirstOrDefaultAsync(x => x.Id == answerId);

            }
            catch { return new LessonAnswer(); }
        }

        public async Task<List<LessonAnswer>> GetAnswersForLessonQuestion(int lessonQuestionId)
        {
            try
            {
                return await _context.LessonAnswers.Where(x => x.lessonQuestionId == lessonQuestionId).ToListAsync();
            }
            catch(Exception ex)
            {
                return new List<LessonAnswer>();
            }
        }

        public async Task<string> UpdateAnswerToLessonQuestion(int answerId, LessonAnswer updatedAnswer)
        {
            try
            {
                var answer = await _context.LessonAnswers.FindAsync(answerId);
                if (answer != null)
                {
                    answer.content = updatedAnswer.content;
                    answer.likesCounter = updatedAnswer.likesCounter;
                    // Cập nhật thời gian chỉ khi cần thiết
                    if (updatedAnswer.createdAt != default(DateTime))
                    {
                        answer.createdAt = updatedAnswer.createdAt;
                    }
                    // Cập nhật người dùng chỉ khi cần thiết
                    if (updatedAnswer.teacherId != default(Guid))
                    {
                        answer.teacherId = updatedAnswer.teacherId;
                    }
                    if (updatedAnswer.studentId != default(Guid))
                    {
                        answer.studentId = updatedAnswer.studentId;
                    }
                    _context.Entry(answer).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return "Câu hỏi được cập nhật thành công.";
                }
                else
                {
                    return "Câu hỏi không tìm thấy để cập nhật.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật: {ex.Message}", ex);
            }
        }
    }
}
