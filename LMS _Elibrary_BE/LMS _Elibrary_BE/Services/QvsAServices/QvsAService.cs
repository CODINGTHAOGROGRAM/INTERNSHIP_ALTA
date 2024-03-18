using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models.AboutUser;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.QvsAServices
{
    public class QvsAService : IQvsAService
    {
        private readonly DataContext _context;

        public async Task<string> ClearLikedAnswers(Guid userId)
        {
            var likes = await _context.QnALikes.FirstOrDefaultAsync(q => q.UserId == userId);
            if (likes != null)
            {
                likes.AnswersLikedID = null;
                _context.QnALikes.Update(likes);
                await _context.SaveChangesAsync();
                return "Lượt thích câu hỏi được xóa.";
            }
            return "Không tìm thấy đối tượng cần xóa.";
        }

        public async Task<string> ClearLikedQuestions(Guid userId)
        {
            try
            {
                var likes = await _context.QnALikes.FirstOrDefaultAsync(q => q.UserId == userId);
                if (likes != null)
                {
                    likes.QuestionsLikedID = null;
                    _context.QnALikes.Update(likes);
                    await _context.SaveChangesAsync();
                    return "Lượt thích câu hỏi đã được xóa.";
                }
                return "Không tìm thấy đối tượng cần xóa.";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<List<QnALikeDTO>> GetLikedAnswersById(Guid userId)
        {
            try
            {
                return await _context.QnALikes.Where(x => x.UserId == userId && !string.IsNullOrEmpty(x.AnswersLikedID))
                                              .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<List<QnALikeDTO>> GetLikedQuestionsById(Guid userId)
        {
            try
            {
                return await _context.QnALikes.Where(x => x.UserId == userId && !string.IsNullOrEmpty(x.QuestionsLikedID))
                                              .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<QnALikeDTO> GetQnALikesByUserId(Guid userId)
        {
            try
            {
                return await _context.QnALikes.FirstOrDefaultAsync(x => x.UserId == userId);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<string> UpdateQnALikes(Guid userId, QnALikeDTO updatedQnALikes)
        {
            try
            {
                var existingLikes = await _context.QnALikes.FirstOrDefaultAsync(q => q.UserId == userId);
                if (existingLikes != null)
                {
                    existingLikes.QuestionsLikedID = updatedQnALikes.QuestionsLikedID;
                    existingLikes.AnswersLikedID = updatedQnALikes.AnswersLikedID;
                    _context.QnALikes.Update(existingLikes);
                    await _context.SaveChangesAsync();
                    return "Thay đổi thành công";
                }
                return "Không tìm thấy đối tượng cần thay đổi.";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }
    }
}
