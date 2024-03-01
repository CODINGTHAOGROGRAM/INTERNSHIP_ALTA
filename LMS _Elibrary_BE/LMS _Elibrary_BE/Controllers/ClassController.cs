using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    public class ClassController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
