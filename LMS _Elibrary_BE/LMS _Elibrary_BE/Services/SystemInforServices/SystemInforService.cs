using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace LMS__Elibrary_BE.Services.SystemInforServices
{
    public class SystemInforService : ISystemInforService
    {
        private readonly DataContext _context;
        public SystemInforService(DataContext context)
        {
            _context = context;
        }

        public async Task<string> AddGetInfor(SystemInfomation newSystem)
        {
            try
            {
                _context.SystemInfomation.Add(newSystem);
                await _context.SaveChangesAsync();
                return "Thêm thành công";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thêm" + ex.Message);
            }
        }

        public async Task<SystemInfomation> GetInforSystem(Guid id)
        {
            try
            {
                return await _context.SystemInfomation.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch(SystemException ex)
            {
                throw new Exception("Lỗi khi thực hiện" +ex.Message);
            }
        }

        public async Task<string> RemoveGetInfor(Guid id)
        {
            try
            {
                var existtingSystem = await _context.SystemInfomation.FirstOrDefaultAsync(x => x.Id == id);
                if (existtingSystem != null)
                {
                    _context.Remove(existtingSystem);
                    await _context.SaveChangesAsync();
                    return "Xóa thành công";
                }
                return "Không tìm thấy đối tượng cần xóa";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<string> UpdateInfor(SystemInfomation systemObj)
        {
            try
            {
                var ex = await _context.SystemInfomation.FindAsync(systemObj.Id);
                if(ex == null)
                {
                    return "Không tìm thấy đối tượng";
                }

                ex.SchoolId = systemObj.SchoolId;
                ex.Name = systemObj.Name;
                ex.SchoolWebsite = systemObj.SchoolWebsite;
                ex.SchoolType = systemObj.SchoolType;
                ex.LibrarySystemName = systemObj.LibrarySystemName;
                ex.LMSWebsite = systemObj.LMSWebsite;
                ex.PhoneNumber = systemObj.PhoneNumber;
                ex.Email = systemObj.Email;
                ex.Language = systemObj.Language;
                ex.AcademicYear = systemObj.AcademicYear;
                ex.Principals = systemObj.Principals;

                await _context.SaveChangesAsync();
                return "Thay đổi thành công";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }
    }
}
