using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
