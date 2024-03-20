using AutoMapper;
using LMS__Elibrary_BE.Helpers;
using LMS__Elibrary_BE.ModelsDTO;
using LMS__Elibrary_BE.Services.UserServices;
using LMS_Library_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUpLoadFileHelper _upLoadFileHelper;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IUpLoadFileHelper upLoadFileHelper, IMapper mapper)
        {
            _userService = userService;
            _upLoadFileHelper = upLoadFileHelper;
            _mapper = mapper;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddNewUser([FromBody] UserDTO newUser)
        {
            try
            {
                var user = _mapper.Map<User>(newUser);
                var result = await _userService.AddNew(user);
                return Ok(result); // Trả về HTTP status code 200 OK và thông điệp thành công
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về HTTP status code 500 và thông điệp lỗi
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users); // Trả về danh sách
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }

        [HttpGet("{userID}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            try
            {
                var users = await _userService.GetById(userId);
                return Ok(users); // Trả về đối tượng có id tương ứng
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO UpdateUser)
        {
            try
            {
                var user = _mapper.Map<User>(UpdateUser);
                var usr = await _userService.Update(user);
                return Ok(usr); // Trả về đối tượng cần update
            }
            catch (Exception ex) 
            {
                return StatusCode(500,ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }

        [HttpDelete("Delete/{userId}")]
        public async Task<IActionResult> DeleteUser([FromBody] string userId)
        {
            try
            {
                await _userService.DeleteById(userId);
                return Ok("Xóa thành công"); // Trả về thông báo thành công
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Trả về lỗi 500 và thông báo lỗi
            }
        }
    }
}
