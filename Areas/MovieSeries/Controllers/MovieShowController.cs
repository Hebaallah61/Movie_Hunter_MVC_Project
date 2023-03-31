using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie_Hunter_FinalProject.Areas.Identity.Data;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoClasses;
using Movie_Hunter_FinalProject.RepoInterface;

namespace Movie_Hunter_FinalProject.Areas.MovieSeries.Controllers
{
    [Area("MovieSeries")]
    public class MovieShowController : Controller
    {
        IGenericRepo<Movies> MovieRepo { get; }
        IUserMovieRepo userMoviesRepo { get; }
        ILookValueRepo lookValueRepo { get; }

        private readonly UserManager<SystemUser> _userManager;

        public MovieShowController(IGenericRepo<Movies> MR, IUserMovieRepo UMR, ILookValueRepo LVR, UserManager<SystemUser> userManager)
        {
            MovieRepo = MR;
            userMoviesRepo = UMR;
            lookValueRepo = LVR;
            _userManager = userManager;
        }
        // GET: MovieShowController
        [Route("MovieSeries/Index")]
        public ActionResult Index()
        {
            var movies = MovieRepo.GetAll(); 
            return View(movies);
        }

        // GET: MovieShowController/Details/5
        //[Route("MovieSeries/MovieShow/{id}")]
        public ActionResult Details(int id)
        {
            var movie = MovieRepo.GetById(id);
            var CatID = MovieRepo.GetById(id).Category_Id;
            var Cat = lookValueRepo.GetById(CatID).Value;
            var userId = _userManager.GetUserId(User);
            var UserMovie = (UserMovies)userMoviesRepo.GetByMovieId(id).Where(x => x.user_id==userId).FirstOrDefault();
            if(UserMovie==null)
            {
                UserMovies NewUser = new();
                NewUser.user_id = userId;
                NewUser.MovieId = id;
                userMoviesRepo.Create(NewUser);
                var NewUserMovie = (UserMovies)userMoviesRepo.GetByMovieId(id).Where(x => x.user_id == userId).FirstOrDefault();
                ViewBag.User = NewUserMovie;
            }
            else
            {
                ViewBag.User = UserMovie;
            }
            ViewBag.CatName = Cat;
            return View(movie);
        }

        // GET: MovieShowController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieShowController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieShowController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieShowController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieShowController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieShowController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
