using AutoMapper;
using LMS__Elibrary_BE.ModelsDTO;
using LMS__Elibrary_BE.Services.HelpServices;
using LMS_Library_API.Models.AboutUser;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IHelpService _helpService;
        public HelpController(IMapper mapper, IHelpService helpService)
        {
            _mapper = mapper;
            _helpService = helpService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHelp()
        {
            try
            {
                var result = await _helpService.GetAllHelp();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{helpId}")]
        public async Task<IActionResult> GetHelpById(int id)
        {
            try
            {
                var result = await _helpService.GetHelpById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddHelp(HelpDTO help)
        {
            try
            {
                var newHelp = _mapper.Map<Help>(help);
                var result = await _helpService.AddHelp(newHelp);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHelp(int Id, HelpDTO help)
        {
            try
            {
                var newHelp = _mapper.Map<Help>(help);
                var result = await _helpService.UpdateHelp(Id,newHelp);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{helpId}")]
        public async Task<IActionResult> DeleteHelp(int Id)
        {
            try
            {
                var result = await _helpService.DeleteHelp(Id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
