using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models.AboutUser;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.FilePrivateServices
{
    public class FilePrivateService : IFilePrivateService
    {
        private readonly DataContext _context;
        public FilePrivateService(DataContext context)
        {
            _context = context;
        }

        public async Task<string> AddNewFile(PrivateFile file)
        {
            try
            {
                _context.PrivateFiles.Add(file);
                await _context.SaveChangesAsync();
                return "Thêm File thành công";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm" +ex.Message, ex);
            }
        }

        public async Task<string> DeleteFile(int fileId)
        {
            try
            {
                var exitFile = _context.PrivateFiles.FirstOrDefault(f => f.Id == fileId);
                if (exitFile == null)
                {
                    return "Không tìm thấy File cần xóa";
                }
                _context.Remove(exitFile);
                await _context.SaveChangesAsync();
                return "Xóa file thành công";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa" + ex.Message, ex);
            }
            
        }

        public async Task<List<PrivateFile>> GetAllFile()
        {
            try
            {
                return await _context.PrivateFiles.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Không tìm thấy danh sách" + ex.Message, ex);
            }
            throw new NotImplementedException();
        }

        public async Task<PrivateFile> GetById(int fileId)
        {
            try
            {
                return await _context.PrivateFiles.FirstOrDefaultAsync(f => f.Id == fileId);
            }
            catch(Exception ex)
            {
                throw new Exception("Không tìm thấy đối tượng theo Id cần tìm" + ex.Message, ex);
            }
        }

        public Task<PrivateFile> GetByUserId(string userId)
        {
            try
            {
                return _context.PrivateFiles.FirstOrDefaultAsync(f => f.UserId == Guid.Parse(userId));
            }
            catch (Exception ex)
            {
                throw new Exception("Không tìm thấy đối tượng theo Id cần tìm" + ex.Message, ex);
            }
        }

        public async Task<PrivateFile> SearchbyItem(string query)
        {
            try
            {
                var file = await _context.PrivateFiles.FirstOrDefaultAsync(f => f.Name.Contains(query) || f.Modifier.Contains(query));
                return file;
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm tệp tin: " + ex.Message);
            }
        }

        public async Task<string> UpdateFile(PrivateFile file)
        {
            try
            {
                var existingFile = await _context.PrivateFiles.FirstOrDefaultAsync(f => f.Id == file.Id);
                if (existingFile == null)
                {
                    return "Không tìm thấy File cần thay đổi";
                }

                existingFile.Name = file.Name;
                existingFile.Modifier = file.Modifier;
                existingFile.DateChanged = file.DateChanged;
                existingFile.FilePath = file.FilePath;
                existingFile.IsImage = file.IsImage;
                
                await _context.SaveChangesAsync();
                return "Thay đổi thành công";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật tệp tin: " + ex.Message);
            }
        }
    }
}
