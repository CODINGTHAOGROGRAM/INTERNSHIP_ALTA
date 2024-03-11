using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models.AboutStudent;
using LMS_Library_API.Models.AboutSubject;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.StudyHistoryServices
{
    public class StudyHistoryService : IStudyHistoryService
    {
        private readonly DataContext _context;
        public StudyHistoryService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddStudyHistory(Guid studentId, int documentId, int watchMinutes)
        {
            try
            {
                var studyHistory = new StudyHistory
                {
                    studentId = studentId,
                    documentId = documentId,
                    watchMinutes = watchMinutes           
                };

                _context.StudyHistories.Add(studyHistory);
                await _context.SaveChangesAsync();
                return "Thêm thành công";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thêm" +ex.Message,ex);
            }
        }

        public async Task<string> DeleteAllStudyHistoryForStudent(Guid studentId)
        {
            try
            {
                var rs = await _context.StudyHistories.FirstOrDefaultAsync(x => x.studentId == studentId);
                if (rs == null)
                {
                    throw new Exception("Không tìm thấy lịch sử hoạt động của sinh viên trên");

                }
                _context.Remove(rs);
                await _context.SaveChangesAsync();
                return ("Xóa thành công");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa" +ex.Message, ex);
            }
        }

        public async Task<List<Document>> GetDocumentsWatchedByStudent(Guid studentId)
        {
            try
            {
                return await _context.StudyHistories
                       .Where(sh => sh.studentId == studentId)
                       .Select(sh => sh.Document)
                       .Distinct()
                       .ToListAsync();
            }
            catch(Exception ex)
            {
                return new List<Document>();
            }
            throw new NotImplementedException();
        }

        public async Task<List<StudyHistory>> GetStudyHistoryForStudent(Guid studentId)
        {
            try
            {
                return await _context.StudyHistories
                           .Include(sh => sh.Document)
                           .Where(sh => sh.studentId == studentId)
                           .ToListAsync();
            }
            catch(Exception ex)
            {
                return new List<StudyHistory>();
            }
        }

        public async Task<string> UpdateStudyHistory(StudyHistory studyHistory)
        {
            try
            {
                if(studyHistory == null || studyHistory.studentId == Guid.Empty)
                {
                    throw new ArgumentException("Đối tượng StudyHistory được cung cấp không hợp lệ");
                }
                var existingEntry = await _context.StudyHistories.FirstOrDefaultAsync(ex => ex.studentId == studyHistory.studentId && ex.documentId == studyHistory.documentId);
                if (existingEntry == null)
                {
                    throw new Exception("Không tìm thấy mục Lịch sử Nghiên cứu với ID được cung cấp");
                }
                existingEntry.watchMinutes = studyHistory.watchMinutes;
                await _context.SaveChangesAsync();
                return ("Chỉnh sửa thành công");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi chỉnh sửa");
            }
        }
    }
}
