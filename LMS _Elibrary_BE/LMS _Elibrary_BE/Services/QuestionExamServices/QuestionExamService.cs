using LMS__Elibrary_BE.Context;
using LMS__Elibrary_BE.Models.Exams;
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

        public async Task<string> CreateNewExamFromQuestionBank(ExamCreationRequest examModel)
        {
            try
            {
                // Lấy ngẫu nhiên số lượng câu hỏi trắc nghiệm từ QuestionBank
                var mcQuestions = await _context.QuestionBanks
                    .Where(q => q.Format == Enums.Format.Mc)
                    .OrderBy(q => Guid.NewGuid())
                    .Take(examModel.MC_Count)
                    .ToListAsync();

                // Lấy ngẫu nhiên số lượng câu hỏi tự luận từ QuestionBank
                var essayQuestions = await _context.QuestionBanks
                    .Where(q => q.Format == Enums.Format.Es)
                    .OrderBy(q => Guid.NewGuid())
                    .Take(examModel.ES_Count)
                    .ToListAsync();

                // Tạo đối tượng Exam mới và thêm các câu hỏi vào đó
                var newExam = new Exam();
                foreach (var question in mcQuestions)
                {
                    newExam.Question_Exam.Add(new Question_Exam { Exam = newExam, QuestionBanks = question });
                }

                foreach (var question in essayQuestions)
                {
                    newExam.Question_Exam.Add(new Question_Exam { Exam = newExam, QuestionBanks = question });
                }

                _context.Exams.Add(newExam);
                await _context.SaveChangesAsync();

                return "Tạo bài kiểm tra mới thành công.";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tạo bài kiểm tra mới từ QuestionBank: " + ex.Message, ex);
            }
          
        }

        public async Task<List<QB_Answer_Essay>> GetEssayAnswersForQuestion(int questionId)
        {
            try
            {
                return await _context.QB_Answers_Essay.Where(a => a.QuestionId == questionId)
                                                      .ToListAsync();
            }
            catch (Exception ex) 
            {
                throw new Exception("Lỗi khi cố tình truy xuât" + ex.Message, ex);
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

        public async Task<List<QB_Answer_MC>> GetMCAnswersForQuestion(int questionId)
        {
            try
            {
                return await _context.QB_Answers_MC.Where(a => a.QuestionId == questionId)
                                                      .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cố tình truy xuât" + ex.Message, ex);
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

        public async Task<string> UpdateAnswerContent(int questionId, string newAnswerContent)
        {
            try
            {
                var question = await _context.QuestionBanks.FirstOrDefaultAsync(q => q.Id == questionId);
                if(question != null)
                {
                    if (question.Format == Enums.Format.Mc)
                    {
                        var mcAnswer = await _context.QB_Answers_MC.FirstOrDefaultAsync(mc => mc.QuestionId == questionId);
                        if (mcAnswer != null)
                        {
                            mcAnswer.AnswerContent = newAnswerContent;
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            return ("Không tìm thấy câu trả lời cho câu hỏi có Id");
                        }
                    }
                    else if (question.Format == Enums.Format.Es)
                    {
                        var esAnswer = await _context.QB_Answers_Essay.FirstOrDefaultAsync(mc => mc.QuestionId == questionId);
                        if (esAnswer != null)
                        {
                            esAnswer.AnswerContent = newAnswerContent;
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                           return ("Không tìm thấy câu trả lời cho câu hỏi");
                        }
                    }
                    else
                    {
                        return ("Định dạng câu hỏi không được hỗ trợ");
                    }
                }
                return ("Không tìm thấy câu hỏi trong QuestionBank ");

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất" + ex.Message, ex);
            }
        }
    }
}
