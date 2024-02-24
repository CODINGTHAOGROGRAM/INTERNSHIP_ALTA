﻿using LMS__Elibrary_BE.Services.RoleServices;
using LMS_Library_API.Models.RoleAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }


        [HttpPost]
        public async Task<IActionResult> AddNewRole(Role role)
        {
            try
            {
                int result = await _roleService.AddNew(role);
                return Ok(result); // Trả về ID của vai trò mới được thêm vào thành công
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }

        [HttpDelete("{roleID}")]
        public async Task<IActionResult> DeleteRole(int roleID)
        {
            try
            {
                await _roleService.DeleteRole(roleID);
                return Ok("Role deleted successfully."); // Trả về thông báo thành công
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var roles = await _roleService.GetAllRole();
                return Ok(roles); // Trả về danh sách vai trò
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }

        [HttpGet("{roleID}")]
        public async Task<IActionResult> GetRoleById(int roleID)
        {
            try
            {
                var role = await _roleService.GetRoleById(roleID);
                return Ok(role); // Trả về vai trò có ID tương ứng
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole(Role role)
        {
            try
            {
                int result = await _roleService.UpdateRole(role);
                return Ok(result); // Trả về số liệu chỉnh sửa thành công
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }
    }
}