using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models;
using LMS_Library_API.Models.AboutStudent;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.StudyTimeServices
{
    public class StudyTimeService : IStudyTimeService
    {
        private readonly DataContext _context;
        public StudyTimeService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddStudyTime(Guid studentId, string subjectId, int totalTime)
        {
            try
            {
                var studyTime = new StudyTime
                {
                    studentId = studentId,
                    subjectId = subjectId,
                    totalTime = totalTime,
                    studyDate = DateTime.Now
                };
                _context.StudyTimes.Add(studyTime);
                await _context.SaveChangesAsync();
                return "Thêm thành công";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thêm" +ex.Message, ex);
            }
        }

        public async Task<List<StudyTime>> GetStudyTimeForStudent(Guid studentId)
        {
            try
            {
                return await _context.StudyTimes.Include(st => st.Subject)
                                                .Where(st => st.studentId == studentId)
                                                .ToListAsync();
            }
            catch(Exception ex)
            {
                return new List<StudyTime>();
            }

        }

        public async Task<List<Subject>> GetSubjectsStudiedByStudent(Guid studentId)
        {
            try
            {
                // Lấy danh sách các môn học mà sinh viên đã học, dựa trên ID của sinh viên.
                return await _context.StudyTimes.Where(st => st.studentId == studentId)
                                                .Select(st => st.Subject)
                                                .Distinct() // Loại bỏ môn bị trùng lặp
                                                .ToListAsync();

            }
            catch(Exception ex)
            {
                return new List<Subject>();
            }
        }
    }
}
