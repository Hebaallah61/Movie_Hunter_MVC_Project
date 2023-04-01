using Microsoft.AspNetCore.Mvc;


namespace Movie_Hunter_FinalProject.Controllers
{
	public class ErrorController : Controller
	{

		
		public IActionResult NotFound()
		{
			return View();
		}
	}
}
