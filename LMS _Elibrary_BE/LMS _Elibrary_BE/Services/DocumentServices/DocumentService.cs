using AutoMapper;
using LMS__Elibrary_BE.Context;
using LMS_Library_API.Models.AboutSubject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

namespace LMS__Elibrary_BE.Services.DocumentServices
{
    
    public class DocumentService : IDocumentService
    {
        private readonly DataContext _context;
        public DocumentService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddDocument(Document document)
        {
            try
            {
                _context.Documents.Add(document);
                await _context.SaveChangesAsync();
                return ("Lưu thành công");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm" + ex.Message, ex);
            }
        }

        public async Task<string> CreateDocumentFromLesson(int lessonId)
        {
            try
            {
                var exitsLesson = await _context.Documents.FirstOrDefaultAsync(x => x.lessonId == lessonId);
                if (exitsLesson == null)
                {
                    throw new Exception("Không tìm thấy bài học cần tạo tài liệu");
                }
                var document = new Document
                {
                    Name = exitsLesson.Name, 
                    Type = false, 
                    FilePath = "", 
                    submissionDate = DateTime.Now, 
                    teacherCreatedId = exitsLesson.teacherCreatedId, 
                    lessonId = lessonId 
                };
                _context.Documents.Add(document);
                await _context.SaveChangesAsync();

                return "Tạo tài liệu từ bài học thành công.";
            }
            catch(Exception ex)
            {
                return "Lỗi khi tạo tài liệu từ bài học: " + ex.Message;
            }
           
        }

        public async Task<string> DeleteDocument(int documentId)
        {
            try
            {
                var res = await _context.Documents.FirstOrDefaultAsync(x => x.Id == documentId);
                if (res != null)
                {
                    _context.Documents.Remove(res);
                    await _context.SaveChangesAsync();
                }
                return ("Xóa đối tượng thành công");
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi xóa đối tượng" + ex.Message, ex);
            }
        }

        public async Task<FileStreamResult> DownloadDocument(int documentId)
        {
            try
            {
                var document = await _context.Documents.FindAsync(documentId);

                if (document == null)
                {
                    throw new FileNotFoundException("Document not found.");
                }

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), document.FilePath);
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                return new FileStreamResult(fileStream, "application/octet-stream")
                {
                    FileDownloadName = document.Name
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xử lý");
            }
           
        }

       

        public async Task<List<Document>> GetAllDocument()
        {
            try
            {
                return await _context.Documents.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất danh sách");
            }
        }

        public async Task<List<Document>> GetDocumentsByLesson(int lessonId)
        {
            try
            {
                return await _context.Documents.Where(x => x.lessonId == lessonId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn danh sách" + ex.Message, ex);
            }
        }

        public async Task<string> UploadDocument(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return "File is empty or does not exist.";
                }

                var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return filePath;
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi xử lý");
            }
            
        }

       
    }
}
