using AutoMapper;
using LMS__Elibrary_BE.Services.ExamRecentViewsServices;
using Microsoft.AspNetCore.Mvc;

namespace LMS__Elibrary_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamRecentViewsServiceController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IExamRecentViewsService _service;
        public ExamRecentViewsServiceController(IMapper mapper, IExamRecentViewsService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
