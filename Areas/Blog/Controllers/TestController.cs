using Microsoft.AspNetCore.Mvc;

namespace Movie_Hunter_FinalProject.Areas.Blog.Controllers
{
    [Area("Blog")]
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
