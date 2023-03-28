using Microsoft.AspNetCore.Mvc;

namespace Movie_Hunter_FinalProject.Controllers
{
    public class MahaController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
