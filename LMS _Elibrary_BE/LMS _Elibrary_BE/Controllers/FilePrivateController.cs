using AutoMapper;
using LMS__Elibrary_BE.ModelsDTO;
using LMS__Elibrary_BE.Services.FilePrivateServices;
using LMS_Library_API.Models.AboutUser;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilePrivateController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFilePrivateService _filePrivateService;
        public FilePrivateController(IMapper mapper, IFilePrivateService filePrivateService)
        {
            _mapper = mapper;
            _filePrivateService = filePrivateService;
        }

        [HttpPost("AddFile")]
        public async Task<IActionResult> AddNewFile(FileDTO newFile)
        {
            try
            {
                var file = _mapper.Map<PrivateFile>(newFile);
                string result = await _filePrivateService.AddNewFile(file);
                return Ok(result); // Trả về thông báo thành công
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }

        [HttpDelete("DeleteFile/{fileId}")]
        public async Task<IActionResult> DeleteFile(int fileId)
        {
            try
            {
                string result = await _filePrivateService.DeleteFile(fileId);
                return Ok(result); // Trả về thông báo thành công
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFiles()
        {
            try
            {
                var files = await _filePrivateService.GetAllFile();
                return Ok(files); // Trả về danh sách tất cả các tệp tin
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }

        [HttpGet("{fileId}")]
        public async Task<IActionResult> GetFileById(int fileId)
        {
            try
            {
                var file = await _filePrivateService.GetById(fileId);
                return Ok(file); // Trả về tệp tin có ID tương ứng
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }

        [HttpGet("GetFile/{userId}")]
        public async Task<IActionResult> GetFilesByUserId(string userId)
        {
            try
            {
                var files = await _filePrivateService.GetByUserId(userId);
                return Ok(files); // Trả về danh sách tệp tin của người dùng có ID tương ứng
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchByItem(string query)
        {
            try
            {
                var file = await _filePrivateService.SearchbyItem(query);
                if (file != null)
                {
                    return Ok(file); // Trả về tệp tin nếu tìm thấy
                }
                else
                {
                    return NotFound("Không tìm thấy tệp tin phù hợp"); // Trả về mã lỗi 404 nếu không tìm thấy tệp tin
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Lỗi khi tìm kiếm tệp tin: " + ex.Message); // Trả về lỗi 500 nếu có lỗi xảy ra
            }
        }

        [HttpPut("UpdateFile")]
        public async Task<IActionResult> UpdateFile(FileDTO fileObj)
        {
            try
            {
                var file = _mapper.Map<PrivateFile>(fileObj);
                string result = await _filePrivateService.UpdateFile(file);
                return Ok(result); // Trả về thông báo thành công
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }
    }
}
