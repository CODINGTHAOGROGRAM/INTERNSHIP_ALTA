using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models.AboutUser;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.HelpServices
{
    public class HelpService : IHelpService
    {
        private readonly DataContext _context;
        public HelpService(DataContext context)
        {
            _context = context;
        }

        public async Task<string> AddHelp(Help help)
        {
            try
            {
                _context.Helps.Add(help);
                await _context.SaveChangesAsync();
                return "Thêm thành công";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<string> DeleteHelp(int id)
        {
            try
            {
                var existing = await _context.Helps.FirstOrDefaultAsync(x => x.Id == id);
                if(existing != null)
                {
                    _context.Remove(existing);
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

        public async Task<List<Help>> GetAllHelp()
        {
            try
            {
                return await _context.Helps.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<Help> GetHelpById(int id)
        {
            try
            {
                return await _context.Helps.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }

        public async Task<string> UpdateHelp(int id, Help updatedHelp)
        {
            try
            {
                var ex = await _context.Helps.FirstOrDefaultAsync(x => x.Id == id);
                if(ex != null)
                {
                    ex.Content = updatedHelp.Content;
                    ex.Id = updatedHelp.Id;
                    ex.DateSent = updatedHelp.DateSent;

                    await _context.SaveChangesAsync();
                    return "Thay đổi thành công";
                }
                return "Không tìm thấy đối tượng cần cập nhật";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực hiện" + ex.Message);
            }
        }
    }
}
