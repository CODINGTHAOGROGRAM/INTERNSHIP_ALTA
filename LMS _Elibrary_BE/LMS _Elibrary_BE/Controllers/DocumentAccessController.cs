using AutoMapper;
using LMS__Elibrary_BE.Services.DocumentAccessServices;
using LMS_Library_API.Models.AboutSubject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DocumentAccessController : Controller
    {
        private readonly IDocumentAccessService _documentAccessService;
        private readonly IMapper _mapper;

        public DocumentAccessController(IMapper mapper, IDocumentAccessService documentAccessService)
        {
            _mapper = mapper;
            _documentAccessService = documentAccessService;
        }


        [HttpGet("All")]
        public async Task<IActionResult> GetAllDocumentAccess()
        {
            try
            {
                var rs = await _documentAccessService.GetAllDocumentAccess();
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById/{documentId}")]
        public async Task<IActionResult> GetDocumentAccessById(int documentId)
        {
            try
            {
                var res = await _documentAccessService.GetDocumentAccessById(documentId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("DocumentAccess-For-Class/{documentId}/{classId}")]
        public async Task<IActionResult> GetDocumentAccessForClass(int documentId, string classId)
        {
            try
            {
                var res = await _documentAccessService.GetDocumentAccessForClass(documentId, classId);
                return Ok(res);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpPost("AddDocumentAccess")]
        public async Task<IActionResult> AddDocumentAccessForClass(int documentId, string classId, bool isForAllClasses)
        {
            try
            {
                var res = await _documentAccessService.AddDocumentAccessForClass(documentId, classId, isForAllClasses);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateDocumentAccess")]
        public async Task<IActionResult> UpdateDocumentAccess(DocumentAccess documentAccess)
        {
            try
            {
                var rs = await _documentAccessService.UpdateDocumentAccess(documentAccess);
                return Ok(rs);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("documentId")]
        public async Task<IActionResult> DeleteDocumentAccess(int documentId)
        {
            try
            {
                var rss = await _documentAccessService.DeleteDocumentAccess(documentId);
                return Ok(rss);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpDelete("DocumentAccessForClass/{documentId}/{classId}")]
        public async Task<IActionResult> DeleteDocumentAccessForClass(int documentId, string classId)
        {
            try
            {
                var result = await _documentAccessService.DeleteDocumentAccessForClass(documentId, classId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
