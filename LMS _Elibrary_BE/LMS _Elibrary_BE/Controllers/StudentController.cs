using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
