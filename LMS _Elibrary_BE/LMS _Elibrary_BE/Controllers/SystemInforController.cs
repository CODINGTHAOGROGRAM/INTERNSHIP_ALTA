using AutoMapper;
using LMS__Elibrary_BE.ModelsDTO;
using LMS__Elibrary_BE.Services.SystemInforServices;
using LMS_Library_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemInforController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISystemInforService _systemInforService;
        public SystemInforController(IMapper mapper, ISystemInforService systemInforService)
        {
            _mapper = mapper;
            _systemInforService = systemInforService;
        }

        [HttpGet("Infor/{systemId}")]
        public async Task<IActionResult> GetInforSystem(Guid systemId)
        {
            try
            {
                var infor = await _systemInforService.GetInforSystem(systemId);
                return Ok(infor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddGetInfor(SystemDTO newSystem)
        {
            try
            {
                var system = _mapper.Map<SystemInfomation>(newSystem);
                var inf = await _systemInforService.AddGetInfor(system);
                return Ok(inf);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateSystem(SystemDTO systemObj)
        {
            try
            {
                var obj = _mapper.Map<SystemInfomation>(systemObj);
                var sys = await _systemInforService.UpdateInfor(obj);
                return Ok(sys);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("System/systemId")]
        public async Task<IActionResult> RemoveSystem(Guid SystemId)
        {
            try
            {
                var system = await _systemInforService.RemoveGetInfor(SystemId);
                return Ok(system);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
