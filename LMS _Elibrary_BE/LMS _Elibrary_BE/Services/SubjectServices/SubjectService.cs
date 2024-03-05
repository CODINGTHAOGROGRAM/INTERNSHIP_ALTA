using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models;
using LMS_Library_API.Models.AboutStudent;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.SubjectServices
{
    public class SubjectService : ISubjectService
    {
        private readonly DataContext _context;
        public SubjectService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddNewSubject(Subject subject)
        {
            try
            {
                _context.Subjects.Add(subject);
                await _context.SaveChangesAsync();
                return ("Thêm thành công");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm môn học" + ex.Message, ex);
            }
        }

        public async Task<string> AddStudentToSubject(string subjectId, string studentId)
        {
            try
            {
                // Kiểm tra xem môn học và sinh viên tồn tại không
                var subject = await _context.Subjects.FindAsync(subjectId);
                var student = await _context.Students.FindAsync(studentId);

                if (subject == null)
                {
                    return "Không tìm thấy môn học.";
                }

                if (student == null)
                {
                    return "Không tìm thấy sinh viên.";
                }

                // Kiểm tra xem sinh viên đã đăng ký môn học này chưa
                var existingEnrollment = await _context.StudentSubjects
                    .FirstOrDefaultAsync(ss => ss.subjectId == subjectId && ss.studentId == Guid.Parse(studentId));

                if (existingEnrollment != null)
                {
                    return "Sinh viên đã được đăng ký vào môn học này trước đó.";
                }

                // Thêm một bản ghi mới vào bảng StudentSubjects
                _context.StudentSubjects.Add(new StudentSubject { subjectId = subjectId, studentId = Guid.Parse(studentId) });
                await _context.SaveChangesAsync();

                return "Thêm sinh viên vào môn học thành công.";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm sinh viên vào môn học: " + ex.Message);
            }
        }

        public async Task<string> DeleteSubject(string subjectId)
        {
            try
            {
                var subject = _context.Subjects.FirstOrDefault(s => s.Id == subjectId);
                if(subject == null)
                {
                    return ("Môn học không tìm thấy");
                }
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
                return ("Xóa thành công môn học");
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi xóa môn học");
            }
        }

        public async Task<Subject> GetSubjectById(string subjectId)
        {
            try
            {
                return await _context.Subjects.FirstOrDefaultAsync(s => s.Id == subjectId) ;

            }catch(Exception ex)
            {
                throw new Exception("Không tìm thấy mã môn học cần tìm" + ex.Message, ex);
            }
            throw new NotImplementedException();
        }

        public async Task<List<Subject>> GetSubjectByUserId(string userId)
        {
            try
            {
                // Lấy danh sách môn học dựa trên mã người dùng
                var subjects = await _context.Subjects
                    .Where(s => s.StudentSubjects.Any(ss => ss.studentId == Guid.Parse(userId))).ToListAsync();
                return subjects;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách môn học theo mã người dùng: " + ex.Message);
            }
        }

        public async Task<List<Subject>> GetSubjects()
        {
            try
            {
                return await _context.Subjects.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm danh sách" + ex.Message,ex);
            }
        }

        public async Task<bool> MarkSubjectAsRead(string subjectId, string studentId)
        {
            try
            {
                // Tìm kiếm môn học dựa trên subjectId và studentId
                var subject = await _context.Subjects.FindAsync(subjectId);
                if (subject == null)
                {
                    return false; // Trả về false nếu không tìm thấy môn học
                }

                // Kiểm tra xem môn học đã được đánh dấu là đã đọc chưa
                var enrollment = await _context.StudentSubjects
                    .FirstOrDefaultAsync(ss => ss.subjectId == subjectId && ss.studentId == Guid.Parse(studentId));

                if (enrollment == null)
                {
                    return false; // Trả về false nếu sinh viên chưa được đăng ký môn học
                }

                // Đánh dấu môn học là đã đọc
                enrollment.subjectMark = true;

                await _context.SaveChangesAsync();

                return true; 
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đánh dấu môn học là đã đọc: " + ex.Message);
            }
        }

        public async Task<string> RemoveStudentFromSubject(string subjectId, string studentId)
        {
            try
            {
                // Tìm kiếm bản ghi StudentSubject tương ứng
                var studentSubject = await _context.StudentSubjects
                    .FirstOrDefaultAsync(ss => ss.subjectId == subjectId && ss.studentId ==Guid.Parse(studentId));

                if (studentSubject != null)
                {
                    // Xóa bản ghi StudentSubject nếu tồn tại
                    _context.StudentSubjects.Remove(studentSubject);
                    await _context.SaveChangesAsync();
                    return "Xóa sinh viên khỏi môn học thành công.";
                }
                else
                {
                    return "Không tìm thấy sinh viên trong môn học.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa sinh viên khỏi môn học: " + ex.Message);
            }
        }

        public async Task<IEnumerable<Subject>> SearchSubjects(string searchTerm, string[] searchFields)
        {
            try
            {
                if(searchFields == null)
                {
                    searchFields = new string[] { nameof(Subject.Name), nameof(Subject.Department),nameof(Subject.Description), nameof(Subject.SubmissionDate)};
                }
                var query = _context.Subjects.AsQueryable();
                foreach (var item in searchFields)
                {
                    query = query.Where(p => EF.Property<string>(p, item).Contains(searchTerm));
                }
                return await query.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm: " + ex.Message, ex);
            }
        }

        public async Task<bool> ToggleFavoriteSubject(string subjectId, string studentId)
        {

            try
            {
                // Tìm kiếm bản ghi StudentSubject tương ứng
                var studentSubject = await _context.StudentSubjects
                    .FirstOrDefaultAsync(ss => ss.subjectId == subjectId && ss.studentId ==Guid.Parse(studentId));

                if (studentSubject != null)
                {
                    // Chuyển đổi trạng thái yêu thích của môn học
                    studentSubject.IsFavorite = !studentSubject.IsFavorite;
                    await _context.SaveChangesAsync();
                    return studentSubject.IsFavorite; // Trả về trạng thái yêu thích mới của môn học
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi chuyển đổi trạng thái môn học yêu thích: " + ex.Message);
            }
        }

        public async Task<string> UpdateSubject(Subject subject)
        {
            try
            {
                var existingSubject = _context.Subjects.FirstOrDefault(s => s.Id == subject.Id);
                if (existingSubject == null)
                {
                    return ("Không tìm thấy môn học cần sửa chữa");
                }
                existingSubject.Name = subject.Name;
                existingSubject.Description = subject.Description;
                existingSubject.SubmissionDate = subject.SubmissionDate;
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
