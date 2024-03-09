using AutoMapper;
using LMS__Elibrary_BE.Services.DepartmentServices;
using LMS_Library_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper mapper;
        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            this.mapper = mapper;
        }

        [HttpGet("Get-All-Department")]
        public async Task<IActionResult> GetAllDepartment()
        {
            try
            {
                var departments = await _departmentService.GetAllDepartments();
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-Department/{departmentId}")]
        public async Task<IActionResult> GetDepartmentById(string departmentId)
        {
            try
            {
                var department = await _departmentService.GetDepartmentById(departmentId);
                return Ok(department);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-User-By-Department/{departmentId}")]
        public async Task<IActionResult> GetUsersByDepartmentId(string departmentId)
        {
            try
            {
                var users = await _departmentService.GetUsersByDepartmentId(departmentId);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Search-Department")]
        public async Task<IActionResult> SearchDepartmentsByName(string name)
        {
            try
            {
                var result = await _departmentService.SearchDepartmentsByName(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Create-Department")]
        public async Task<IActionResult> CreateDepartment(Department newDepartment)
        {
            try
            {
                var department = await _departmentService.CreateDepartment(newDepartment);
                return Ok(department);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update-Department/{departmentId}")]
        public async Task<IActionResult> UpdateDepartment(string departmentId, [FromBody] Department updatedDepartment)
        {
            try
            {
                var update =  await _departmentService.UpdateDepartment(departmentId, updatedDepartment);
                return Ok(update);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment(string departmentId)
        {
            try
            {
                var result = await _departmentService.DeleteDepartment(departmentId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
