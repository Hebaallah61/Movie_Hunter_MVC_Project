using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie_Hunter_FinalProject.Areas.Identity.Data;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoClasses;
using Movie_Hunter_FinalProject.RepoInterface;
using System.Diagnostics;

namespace Movie_Hunter_FinalProject.Areas.MovieSeries.Controllers
{
    [Area("MovieSeries")]
    public class MovieShowController : Controller
    {
        IGenericRepo<Movies> MovieRepo { get; }
        IUserMovieRepo userMoviesRepo { get; }
        IGenericRepo<Series> seriesRepo { get; }
        ILookValueRepo lookValueRepo { get; }


        private readonly UserManager<SystemUser> _userManager;

        public MovieShowController(IGenericRepo<Series> SeriesRepo,IGenericRepo<Movies> MR, IUserMovieRepo UMR, ILookValueRepo LVR, UserManager<SystemUser> userManager)
        {
            MovieRepo = MR;
            userMoviesRepo = UMR;
            lookValueRepo = LVR;
            _userManager = userManager;
            seriesRepo = SeriesRepo;
        }
        // GET: MovieShowController
        public ActionResult Index()
        {
            ViewBag.Series = seriesRepo.GetAll();
            var movies = MovieRepo.GetAll(); 
            return View(movies);
        }

        // GET: MovieShowController/Details/5
        //[Route("MovieSeries/MovieShow/{id}")]
        [Authorize(Roles ="Normaluser")]
        public ActionResult Details(int id)
        {

            var movie = MovieRepo.GetById(id);
            var CatID = MovieRepo.GetById(id).Category_Id;
            var Cat = lookValueRepo.GetById(CatID).Value;

            var allMoviesInCat = MovieRepo.GetAll().Where(m => m.Category_Id == CatID && m.id != id).ToList();
            var userId = _userManager.GetUserId(User);
            var UserMovie = (UserMovies)userMoviesRepo.GetByMovieId(id).Where(x => x.user_id == userId).FirstOrDefault();
            if (UserMovie == null)
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
            ViewBag.allMoviesCat = allMoviesInCat; 
            return View(movie);
        }

        // GET: MovieShowController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult GetRating(int Rating, int movieID)
        {
            var userId = _userManager.GetUserId(User);
            var id = userMoviesRepo.GetByMovieId(movieID).Where(usrID => usrID.user_id == userId).FirstOrDefault().id;
            var UpdatingUser = (UserMovies)userMoviesRepo.GetByMovieId(movieID).Where(usrID => usrID.user_id == userId).FirstOrDefault();
            UpdatingUser.Rating = Rating;
            userMoviesRepo.Update(id, UpdatingUser);
            return RedirectToAction("Details", new {id=movieID});
        }
        [TypeFilter(typeof(FaveMaxException))]
        public ActionResult GetFavourite(bool Fav, int movieID)
        {
            var userId = _userManager.GetUserId(User);
            var id = userMoviesRepo.GetByMovieId(movieID).Where(usrID => usrID.user_id == userId).FirstOrDefault().id;
            var UpdatingUser = (UserMovies)userMoviesRepo.GetByMovieId(movieID).Where(usrID => usrID.user_id == userId).FirstOrDefault();
                    
            int count = userMoviesRepo.GetAll().Where(usrID => usrID.user_id == userId).Where(fav=>fav.AddToFavorite == true).Count();
            int plan_id = UpdatingUser?.systemUser.Plan_Id ?? 0;
            var plan = lookValueRepo.GetById(plan_id);
            if(plan.Value != "Basic" && plan.Value != "Premium" && plan.Value != "Pro") { throw new Exception(); }
            if (count >= 2 && Fav == true && plan.Value == "Basic") { throw new Exception(); }
            if (count >= 6 && Fav == true && plan.Value == "Premium") { throw new Exception(); }
            else
            {
                UpdatingUser.AddToFavorite = Fav;
                userMoviesRepo.Update(id, UpdatingUser);
            }
            return RedirectToAction("Details", new { id = movieID });

        }
     
   
        //---------------------------------------------------Heba
        public ActionResult GetWatched(bool Wat, int movieID)
        {
            var userId = _userManager.GetUserId(User);
            var id = userMoviesRepo.GetByMovieId(movieID).Where(usrID => usrID.user_id == userId).FirstOrDefault().id;
            var UpdatingUser = (UserMovies)userMoviesRepo.GetByMovieId(movieID).Where(usrID => usrID.user_id == userId).FirstOrDefault();
            UpdatingUser.Watched = Wat;
            userMoviesRepo.Update(id, UpdatingUser);
            return RedirectToAction("Details", new { id = movieID });

        }
        //---------------------------------


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
