using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie_Hunter_FinalProject.Areas.Identity.Data;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoInterface;

namespace Movie_Hunter_FinalProject.Areas.AdminDashBoard.Controllers
{
    [Area("AdminDashBoard")]
    //[Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly UserManager<SystemUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IGenericRepo<Movies> _movieManager;
        private readonly IGenericRepo<Series> _seriesManager;
        private readonly IGenericRepo<Episodes> _episodesManager;
        public HomeController(UserManager<SystemUser> _userManager,
            RoleManager<IdentityRole> _roleManager, IGenericRepo<Movies> _movieManager,
            IGenericRepo<Series> _seriesManager, IGenericRepo<Episodes> _episodesManager)
        {                     
            this._userManager = _userManager;
            this._roleManager = _roleManager;
            this._movieManager = _movieManager;
            this._seriesManager = _seriesManager;
            this._episodesManager = _episodesManager;
        }   
        public IActionResult Index()
        {

            ViewBag.Users= _userManager.Users.Count();
            ViewBag.Roles= _roleManager.Roles.Count();
            ViewBag.Movies = _movieManager.GetAll().Count();
            ViewBag.Series= _seriesManager.GetAll().Count();
            ViewBag.Episodes= _episodesManager.GetAll().Count();

            return View();
        }
    }
}
