using AutoMapper;
using LMS__Elibrary_BE.Services.DocumentServices;
using LMS_Library_API.Models.AboutSubject;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class DocumentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDocumentService _documentService;
        
        public DocumentController(IDocumentService documentService, IMapper mapper)
        {
            _documentService = documentService;
            _mapper = mapper;
        }

        [HttpGet("Documents")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listDocument = await _documentService.GetAllDocument();
                return Ok(listDocument);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{lessonId}")]
        public async Task<IActionResult> GetDocumentsByLesson(int lessonId)
        {
            try
            {
                var documents = await _documentService.GetDocumentsByLesson(lessonId);
                return Ok(documents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddDocument")]
        public async Task<IActionResult> AddNewDocument(Document document)
        {
            try
            {
                var rs = await _documentService.AddDocument(document);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddDocumentByLesson/{lessonId}")]
        public async Task<IActionResult> CreateDocumentFromLesson(int lessonId)
        {
            try
            {
                var newDocument = await _documentService.CreateDocumentFromLesson(lessonId);
                return Ok(newDocument);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("upload")]
        public async Task<IActionResult> UploadDocument([FromForm] IFormFile file)
        {
            try
            {
                var filePath = await _documentService.UploadDocument(file);
                return Ok(filePath);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("download/{documentId}")]
        public async Task<IActionResult> DownloadDocument(int documentId)
        {
            try
            {
                var fileStreamResult = await _documentService.DownloadDocument(documentId);
                return fileStreamResult;
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("Delete/{documentId}")]
        public async Task<IActionResult> DeleteDocument(int documentId)
        {
            try
            {
                var rs = await _documentService.DeleteDocument(documentId);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
