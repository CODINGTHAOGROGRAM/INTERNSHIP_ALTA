using LMS__Elibrary_BE.Context;
using LMS__Elibrary_BE.Controllers;
using LMS_Library_API.Models.AboutSubject;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.DocumentAccessServices
{
    public class DocumentAccessService : IDocumentAccessService
    {
        private readonly DataContext _context;
        public DocumentAccessService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddDocumentAccessForClass(int documentId, string classId, bool isForAllClasses)
        {
            try
            {
                var documentAccess = new DocumentAccess
                {
                    documentId = documentId,
                    classId = classId,
                    isForAllClasses = isForAllClasses
                };

                _context.DocumentAccess.Add(documentAccess);
                await _context.SaveChangesAsync();

                return "Thêm quyền truy cập tài liệu cho lớp thành công.";
            }
            catch (Exception ex)
            {
                return "Lỗi khi thêm quyền truy cập tài liệu cho lớp: " + ex.Message;
            }
        }

        public async Task<string> DeleteDocumentAccess(int documentId)
        {
            try
            {
                var exitsDocument = await _context.DocumentAccess.FirstOrDefaultAsync(x => x.documentId == documentId);
                if (exitsDocument != null)
                {
                    _context.Remove(exitsDocument);
                    await _context.SaveChangesAsync();
                    return "Xóa đối tượng thành công";
                }
                return "Không tìm thấy đối tượng cần xóa";
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn dữ liệu" + ex.Message);
            }
        }

        public async Task<List<DocumentAccess>> GetAllDocumentAccess()
        {
            try
            {
                return await _context.DocumentAccess.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn danh sách" + ex.Message);
            }
        }

        public async Task<DocumentAccess> GetDocumentAccessById(int documentId)
        {
            try
            {
                return await _context.DocumentAccess.FirstOrDefaultAsync(x => x.documentId == documentId);

            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn đối tượng" + ex.Message);
            }
        }

        public async Task<DocumentAccess> GetDocumentAccessForClass(int documentId, string classId)
        {
            try
            {
                return await _context.DocumentAccess
                                     .FirstOrDefaultAsync(x => x.classId == classId && x.documentId == documentId);
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy cập đối tượng" + ex.Message);
            }
        }

        public async Task<string> DeleteDocumentAccessForClass(int documentId, string classId)
        {

            try
            {
                var documentAccess = await _context.DocumentAccess.FirstOrDefaultAsync(da => da.documentId == documentId && da.classId == classId);
                if (documentAccess != null)
                {
                    _context.DocumentAccess.Remove(documentAccess);
                    await _context.SaveChangesAsync();
                    return "Xóa quyền truy cập tài liệu cho lớp thành công.";
                }
                else
                {
                    return "Không tìm thấy quyền truy cập tài liệu cho lớp cần xóa.";
                }
            }
            catch (Exception ex)
            {
                return "Lỗi khi xóa quyền truy cập tài liệu cho lớp: " + ex.Message;
            }
        }

        public async Task<string> UpdateDocumentAccess(DocumentAccess documentAccess)
        {
            try
            {
                _context.DocumentAccess.Update(documentAccess);
                await _context.SaveChangesAsync();
                return "Cập nhật quyền truy cập tài liệu thành công.";
            }
            catch (Exception ex)
            {
                return "Lỗi khi cập nhật quyền truy cập tài liệu: " + ex.Message;
            }
        }
    }
}
