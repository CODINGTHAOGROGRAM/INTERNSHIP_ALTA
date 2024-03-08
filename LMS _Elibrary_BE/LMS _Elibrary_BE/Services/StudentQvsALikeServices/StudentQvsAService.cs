using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models;
using LMS_Library_API.Models.AboutStudent;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.StudentQvsALikeServices
{
    public class StudentQvsAService : IStudentQvsAService
    {
        private readonly DataContext _context;
        public StudentQvsAService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentQvsAService>> GetAnswersLikedByStudent(Guid studentId)
        {
            try
            {
                var answerIDs = await _context.StudentQnALikes.Where(s => s.studentId == studentId)
                                              .Select(s => s.AnswersLikedID)
                                              .ToListAsync();
                
                return (IEnumerable<StudentQvsAService>)await _context.StudentQnALikes.Select(x => answerIDs.Contains(x.AnswersLikedID)).ToListAsync();
              
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất" +ex.Message, ex);
            }
        }

        public async Task<IEnumerable<StudentQvsAService>> GetQuestionsLikedByStudent(Guid studentId)
        {
            try
            {
                var questionIDs = await _context.StudentQnALikes.Where(s => s.studentId == studentId)
                                              .Select(s => s.QuestionsLikedID)
                                              .ToListAsync();

                return (IEnumerable<StudentQvsAService>)await _context.StudentQnALikes.Select(x => questionIDs.Contains(x.QuestionsLikedID)).ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất" + ex.Message, ex);
            }
        }

        public async Task<IEnumerable<Student>> GetStudentsWhoLikedAnswer(string answerId)
        {
            try
            {
                return await _context.StudentQnALikes.Where(a => a.AnswersLikedID.Contains(answerId))
                    .Select(a => a.Student)
                    .ToListAsync();

            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn danh sách câu trả lời" + ex.Message, ex);
            }
        }

        public async Task<IEnumerable<Student>> GetStudentsWhoLikedQuestion(string questionId)
        {
            try
            {
                return await _context.StudentQnALikes.Where(a => a.QuestionsLikedID.Contains(questionId))
                    .Select(a => a.Student)
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn danh sách câu hỏi" +ex.Message, ex);
            }
        }

        public async Task ToggleAnswerLike(Guid studentId, string answerId)
        {
            try
            {
                var like = await _context.StudentQnALikes.FirstOrDefaultAsync(q => q.studentId == studentId);

                if (like == null)
                {
                    like = new StudentQnALikes
                    {
                        studentId = studentId,
                        AnswersLikedID = answerId,
                        QuestionsLikedID = null // Đảm bảo không có sự thay đổi trong QuestionsLikedID
                    };
                    _context.StudentQnALikes.Add(like);
                }
                else
                {
                    if (like.AnswersLikedID != null && like.AnswersLikedID.Contains(answerId))
                    {
                        like.AnswersLikedID = like.AnswersLikedID.Replace(answerId, "").Replace(",,", ",");
                    }
                    else
                    {
                        like.AnswersLikedID += "," + answerId;
                    }
                    _context.StudentQnALikes.Update(like);
                }

                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất" + ex.Message, ex);
            }
        }

        public async Task ToggleQuestionLike(Guid studentId, string questionId)
        {
            try
            {
                var like = await _context.StudentQnALikes.FirstOrDefaultAsync(q => q.studentId == studentId);

                if (like == null)
                {
                    like = new StudentQnALikes
                    {
                        studentId = studentId,
                        QuestionsLikedID = questionId,
                        AnswersLikedID = null // Đảm bảo không có sự thay đổi trong AnswersLikedID
                    };
                    _context.StudentQnALikes.Add(like);
                }
                else
                {
                    if (like.QuestionsLikedID != null && like.QuestionsLikedID.Contains(questionId))
                    {
                        like.QuestionsLikedID = like.QuestionsLikedID.Replace(questionId, "").Replace(",,", ",");
                    }
                    else
                    {
                        like.QuestionsLikedID += "," + questionId;
                    }
                    _context.StudentQnALikes.Update(like);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất" + ex.Message, ex);
            }
        }
    }
}
