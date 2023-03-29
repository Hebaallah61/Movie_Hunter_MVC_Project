using Microsoft.AspNetCore.Mvc;

namespace Movie_Hunter_FinalProject.Controllers
{
    public class TestCOntrollerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
