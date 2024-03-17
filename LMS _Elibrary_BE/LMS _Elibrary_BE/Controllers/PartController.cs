using AutoMapper;
using LMS__Elibrary_BE.ModelsDTO;
using LMS__Elibrary_BE.Services.PartServices;
using LMS_Library_API.Models.AboutSubject;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPartService _partService;
        public PartController(IMapper mapper, IPartService partService)
        {
            _mapper = mapper;
            _partService = partService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllParts()
        {
            try
            {
                var parts = await _partService.GetAllParts();
                return Ok(parts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Part/{partId}")]
        public async Task<IActionResult> GetPartsById(int partId)
        {
            try
            {
                var part = await _partService.GetPartsById(partId);
                return Ok(part);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Part/{subjectId}")]
        public async Task<IActionResult> GetPartsBySubject(string subjectId)
        {
            try
            {
                var parts = await _partService.GetPartsBySubject(subjectId);
                return Ok(parts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Part/{TeacherId}")]
        public async Task<IActionResult> GetPartsByTeacher(Guid teacherId)
        {
            try
            {
                var parts = await _partService.GetPartsByTeacher(teacherId);
                return Ok(parts);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPart(PartDTO part)
        {
            try
            {
                var obj = _mapper.Map<Part>(part);
                var newPart = await _partService.AddPart(obj);
                return Ok(newPart);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Part/{partId}")]
        public async Task<IActionResult> UpdatePart(int partId,PartDTO part)
        {
            try
            {
                var obj = _mapper.Map<Part>(part);
                var update = await _partService.UpdatePart(partId, obj);
                return Ok(update);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Part/{partId}")]
        public async Task<IActionResult> DeletePart(int partId)
        {
            try
            {
                var del = await _partService.DeletePart(partId);
                return Ok(del);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
