using LMS__Elibrary_BE.Context;
using LMS__Elibrary_BE.Enums;
using LMS_Library_API.Models.Exams;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.QuestionBankServices
{
    public class QuestionBankService : IQuestionBankService
    {
        private readonly DataContext _context;
        public QuestionBankService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddNew(QuestionBanks questionBank)
        {
            try
            {
               _context.QuestionBanks.Add(questionBank);
                await _context.SaveChangesAsync();
                return ("Thêm câu hỏi thành công");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm" + ex.Message, ex);
            }
        }

        public async Task<string> DeleteQuestionBank(int questionBankId)
        {
            try
            {
                var exist = _context.QuestionBanks.FirstOrDefault(_ => _.Id == questionBankId);
                if (exist == null)
                {
                    return ("Không tìm thấy câu hỏi");
                }
                _context.Remove(exist);
                await _context.SaveChangesAsync();
                return ("Xóa thành công");         
            }
            catch(Exception ex) 
            {
                throw new Exception("Không tìm thấy câu hỏi để xóa" + ex.Message, ex);
            }
        }

        public async Task<List<QuestionBanks>> GetAllQuestionBanks()
        {
            try
            {
                return await _context.QuestionBanks.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Không tìm thấy danh sách" + ex.Message, ex);
            }
        }

        public async Task<QuestionBanks> GetQuestionBankId(int questionBankId)
        {
            try
            {
                return await _context.QuestionBanks.FirstOrDefaultAsync(q => q.Id ==  questionBankId);
            }
             catch(Exception ex)
            {
                throw new Exception("Không tìm thấy mã câu hỏi cần tìm");
            }
        }

        public async Task<IEnumerable<QuestionBanks>> GetQuestionBanksByDifficulty(Level difficultyLevel)
        {
            try
            {
                var levelQuestion = await _context.QuestionBanks.Where(q => q.Level == difficultyLevel).ToListAsync();
                return levelQuestion;
            }
            catch(Exception ex)
            {
                throw new Exception("Không tìm thấy câu hỏi theo level trên" + ex.Message, ex);
            }
        }

        public async Task<IEnumerable<QuestionBanks>> GetQuestionBanksByTopic(int topicId)
        {
            try
            {
                return await _context.QuestionBanks.Where(q => q.SubjectId == Convert.ToString(topicId)).ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách" + ex.Message, ex);
            }
            throw new NotImplementedException();
        }

        public async Task<QuestionBanks> GetRandomQuestionBank()
        {
            try
            {
                var allQuestions = await _context.QuestionBanks.ToListAsync();

                // Kiểm tra xem có câu hỏi nào trong danh sách không
                if (allQuestions.Any())
                {
                    // Chọn một câu hỏi ngẫu nhiên từ danh sách
                    var random = new Random();
                    int randomIndex = random.Next(0, allQuestions.Count);
                    var randomQuestion = allQuestions[randomIndex];

                    return randomQuestion;
                }
                else
                {
                    throw new Exception("Không có câu hỏi nào trong danh sách");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy câu hỏi ngẫu nhiên: " + ex.Message, ex);
            }
        }

        public async Task<IEnumerable<QuestionBanks>> PaginationQuestionBanks(int pageNumber, int pageSize)
        {
            try
            {
                int skipCount = (pageNumber - 1) * pageSize;

                var questionBankPage = await _context.QuestionBanks.Skip(skipCount).Take(pageSize).ToListAsync();
                return questionBankPage;
            }
            catch(Exception ex)
            {
                throw new Exception("Phân trang không thành công" + ex.Message, ex);
            }
        }

        public async Task<IEnumerable<QuestionBanks>> SearchQuestionBanks(string searchTerm, string[] searchFields)
        {
            try
            {
                if(searchFields == null)
                {
                    searchFields = new string[] { nameof(QuestionBanks.Format), nameof(QuestionBanks.Content), nameof(QuestionBanks.Level), nameof(QuestionBanks.SubjectId)};
                }
                var query = _context.QuestionBanks.AsQueryable();
                foreach(var item in searchFields)
                {
                    query = query.Where(p => EF.Property<string>(p, item).Contains(searchTerm));
                }
                
                return await query.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm: " + ex.Message, ex);
            }
            
        }

        public async Task<string> UpdateQuestionBank(QuestionBanks questionBank)
        {
            try
            {
                var existingQuestion =  _context.QuestionBanks.FirstOrDefault(q => q.Id == questionBank.Id);
                if(existingQuestion == null)
                {
                    return ("Không tìm thấy câu hỏi để cập nhật");
                }
                existingQuestion.Format = questionBank.Format;
                existingQuestion.Content = questionBank.Content;
                existingQuestion.Level = questionBank.Level;
                existingQuestion.LastUpdated = questionBank.LastUpdated;

                await _context.SaveChangesAsync();
                return ("Thay đổi thành công");
            }
             catch (Exception ex) 
            {
                throw new Exception("Lỗi khi cập nhật : " + ex.Message, ex);
            }
        }
    }
}
