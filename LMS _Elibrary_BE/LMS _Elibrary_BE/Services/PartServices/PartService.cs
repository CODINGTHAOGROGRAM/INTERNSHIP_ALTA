using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models.AboutSubject;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.PartServices
{
    
    public class PartService : IPartService
    {
        private readonly DataContext _context;
        public PartService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddPart(Part part)
        {
            try
            {
                _context.Parts.Add(part);
                await _context.SaveChangesAsync();
                return "Lưu thành công";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<string> DeletePart(int partId)
        {
            try
            {
                var existingPart = await _context.Parts.FirstOrDefaultAsync(x => x.Id == partId);
                if(existingPart != null)
                {
                    _context.Remove(existingPart);
                    await _context.SaveChangesAsync();
                    return "Xóa thành công";
                }
                return "Không tìm thấy đối tượng cần xóa";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất" + ex.Message);
            }
        }

        public async Task<List<Part>> GetAllParts()
        {
            try
            {
                return await _context.Parts.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất danh sách" + ex.Message);
            }
        }

        public async Task<Part> GetPartsById(int partId)
        {
            try
            {
                return await _context.Parts.FirstOrDefaultAsync(x => x.Id == partId);
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<List<Part>> GetPartsBySubject(string subjectId)
        {
            try
            {
                return await _context.Parts.Where(x => x.subjectId == subjectId)
                                           .ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<List<Part>> GetPartsByTeacher(Guid teacherId)
        {
            try
            {
                return await _context.Parts.Where(x => x.teacherCreatedId == teacherId)
                                           .ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<string> UpdatePart(int partId, Part updatedPart)
        {
            try
            {
                var existtingPart = await _context.Parts.FirstOrDefaultAsync(x => x.Id == partId);
                if(existtingPart == null)
                {
                    return "Không tìm thấy đối tượng cần xóa";
                }
                existtingPart.name = updatedPart.name;
                existtingPart.dateSubmited = updatedPart.dateSubmited;
                existtingPart.numericalOrder = updatedPart.numericalOrder;
                existtingPart.status = updatedPart.status;
                existtingPart.note = updatedPart.note;
                await _context.SaveChangesAsync();
                return "Thay đổi thành công";

            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thay đổi" + ex.Message);
            }
        }
    }
}
