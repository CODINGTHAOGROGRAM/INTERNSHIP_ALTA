using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models.AboutStudent;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.ClassSubjectServices
{
    public class ClassSubjectService : IClassSubjectService
    {
        private readonly DataContext _context;
        public ClassSubjectService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> CreateClassSubject(ClassSubject classSubject)
        {
            try
            {

                _context.ClassSubjects.Add(classSubject);
                await _context.SaveChangesAsync();
                return ("Thêm thành công");
            }
            catch(Exception ex) 
            {
                throw new Exception("Lỗi khi thêm" +ex.Message, ex);
            }
        }

        public async Task<string> DeleteClassSubject(string classId, string subjectId)
        {
            try
            {
                var classSubjectToDelete = _context.ClassSubjects.FirstOrDefault(s => s.classId == classId && s.subjectId == subjectId);
                if (classSubjectToDelete == null)
                {
                    return ("Lớp không tìm thấy");
                }

                _context.ClassSubjects.Remove(classSubjectToDelete);
                await _context.SaveChangesAsync();

                return ("Xóa thành công");
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }
        }

        public async Task<List<ClassSubject>> GetAllClassSubjects()
        {
            try
            {
                return await _context.ClassSubjects
                    .Include(s => s.Class)
                    .Include(s => s.Subject)
                    .ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi tìm danh sách" + ex.Message, ex);
            }
        }

        public async Task<ClassSubject> GetClassSubjectById(string classId, string subjectId)
        {
            try
            {
                return await _context.ClassSubjects
                    .Include(s => s.Subject)
                    .Include(S => S.classId)
                    .FirstOrDefaultAsync(s => s.classId == classId && s.subjectId == subjectId);

            }  
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm theo Id" + ex.Message, ex);
            }
        }

        public async Task<string> UpdateClassSubject(string classId, string subjectId, ClassSubject updatedClassSubject)
        {
            if(classId != updatedClassSubject.classId && subjectId != updatedClassSubject.subjectId)
            {
                return ("ID lớp và chủ đề trong nội dung yêu cầu phải khớp với ID được cung cấp");
            }
            try
            {
                var existingClassSubject = _context.ClassSubjects.Find(classId, subjectId);

                if (existingClassSubject == null)
                {
                    return ("Không tìm thấy lớp học");
                }
                existingClassSubject.subjectId = updatedClassSubject.subjectId;
                existingClassSubject.classId = updatedClassSubject.classId;
                await _context.SaveChangesAsync();
                return ("Thay đổi thành công");
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thay đổi" + ex.Message, ex);
            }
        }

        //public async Task<IEnumerable<ClassSubject>> GetClassSubjectsByStudentId(string studentId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
