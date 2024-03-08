using AutoMapper;
using LMS__Elibrary_BE.Context;
using LMS__Elibrary_BE.Enums;
using LMS_Library_API.Models.Exams;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.ExamServices
{
    public class ExamService : IExamService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ExamService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<string> AddNewExam(Exam exam)
        {
            try
            {
                _context.Exams.Add(exam);
                await _context.SaveChangesAsync();
                return "Thêm bài thi thành công";
            }
            catch (Exception ex) 
            {
                throw new Exception("Lỗi khi thêm" + ex.Message, ex);
            }
            
        }

        public async Task<string> DeleteExam(string Id)
        {
            try
            {
                var existingExam = _context.Exams.FirstOrDefault(e => e.Id == Id);
                if (existingExam == null)
                {
                    return "Đề thi không tồn tại";
                }
                _context.Remove(existingExam);
                await _context.SaveChangesAsync();
                return "Xóa đề thi thành công";
            }
            catch (Exception ex) 
            {
                throw new Exception("Lỗi khi xóa" + ex.Message, ex);
            } 
        }

        public async Task<List<Exam>> GetAllExam()
        {
            try
            {
                return await _context.Exams.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Không tìm thấy danh sách" + ex.Message, ex);
            }
        }

        public async Task<Exam> GetExamById(string Id)
        {
            try
            {
                return await _context.Exams.FirstOrDefaultAsync(e => e.Id == Id);
            }
            catch(Exception ex) 
            {
                throw new Exception("Không tìm thấy đối tượng theo Id cần tìm" + ex.Message, ex);
            }
        }

        public async Task<Exam> GetExamByUserId(string CreatorId)
        {
            try
            {
                var exam = await _context.Exams.FirstOrDefaultAsync(e => e.TeacherCreatedId == Guid.Parse(CreatorId));
                if (exam == null)
                {
                    throw new Exception("Không tìm thấy đề thi nào được tạo từ giảng viên này");
                }

                return exam;
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm"+ ex.Message, ex);
            }
            
        }

        public async Task<IEnumerable<Exam>> SearchExam(string searchTerm, string[] searchFields)
        {
            try
            {
                if(searchFields == null)
                {
                    searchFields = new[] { nameof(Exam.Id), nameof(Exam.Format) , nameof(Exam.Duration) , nameof(Exam.TeacherCreatedId) };
                }
                var query = _context.Exams.AsQueryable();
                foreach(var item in searchFields)
                {
                    query = query.Where(e => EF.Property<string>(e, item).Contains(searchTerm)) ;
                }
                var exams = await query.ToListAsync();
                return exams;
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm: " + ex.Message);
            }
           
        }

        public async Task<string> UpdateExam(Exam exam)
        {
            try
            {
                var existingExam = _context.Exams.FirstOrDefault(e => e.Id == exam.Id);
                if(existingExam == null)
                {
                    return ("Không tìm thấy đề thi cần thay đổi");
                }
                existingExam.Format = exam.Format;
                existingExam.FileName = exam.FileName;
                existingExam.FilePath = exam.FilePath;
                existingExam.Duration = exam.Duration;
                existingExam.DateCreated = exam.DateCreated;
                existingExam.Note = exam.Note;

                await _context.SaveChangesAsync();
                return ("Thay đổi thành công");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật : " + ex.Message,ex);
            }
        }
    }
}
