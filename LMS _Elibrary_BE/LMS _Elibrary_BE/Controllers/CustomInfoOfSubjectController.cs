using AutoMapper;
using LMS__Elibrary_BE.Services.CustomInfoOfSubjectServices;
using LMS_Library_API.Models.AboutSubject;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomInfoOfSubjectController : Controller
    {
        private readonly ICustomInfoOfSubjectService _customInfoOfSubjectService;
        private readonly IMapper _mapper;
        public CustomInfoOfSubjectController(ICustomInfoOfSubjectService customInfoOfSubjectService, IMapper mapper)
        {
            _customInfoOfSubjectService = customInfoOfSubjectService;
            _mapper = mapper;
        }

        [HttpGet("subjectId")]
        public async Task<IActionResult> GetCustomInfoForSubject(string subjectId) 
        {
            try
            {
                var rs = await _customInfoOfSubjectService.GetCustomInfoForSubject(subjectId);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddCustomSubjec")]
        public async Task<IActionResult> AddCustomInfoForSubject(CustomInfoOfSubject customInfo)
        {
            try
            {
                var rs = await _customInfoOfSubjectService.AddCustomInfoForSubject(customInfo);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomInfoForSubject(string subjectId, CustomInfoOfSubject updatedCustomInfo)
        {
            try
            {
                var result = await _customInfoOfSubjectService.UpdateCustomInfoForSubject(subjectId, updatedCustomInfo);
                return Ok(result);
                    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{subjectId}")]
        public async Task<IActionResult> RemoveCustomInfoForSubject(string subjectId)
        {
            try
            {
                var res = await _customInfoOfSubjectService.RemoveCustomInfoForSubject(subjectId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
