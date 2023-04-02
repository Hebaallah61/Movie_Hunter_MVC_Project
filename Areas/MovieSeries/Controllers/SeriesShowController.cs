using Microsoft.AspNetCore.Authorization;
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
    public class SeriesShowController : Controller
    {
        IGenericRepo<Series> SeriesRepo { get; }
        IGenericRepo<Episodes> EpisodeRepo { get; }

        IUserSeriesRepo userSeriesRepo { get; }
        IUserEpisodeRepo userEpisodeRepo { get; }
        ILookValueRepo lookValueRepo { get; }
        private readonly UserManager<SystemUser> _userManager;

        public SeriesShowController(IGenericRepo<Series> SR, IGenericRepo<Episodes> ER,IUserSeriesRepo USR, IUserEpisodeRepo UER, ILookValueRepo LVR, UserManager<SystemUser> userManager)
        {
            SeriesRepo = SR;
            EpisodeRepo = ER;
            userSeriesRepo = USR;
            userEpisodeRepo = UER;
            lookValueRepo = LVR;
            _userManager = userManager;
        }
        // GET: SeriesShow
        //[Route("MovieSeries/SeriesShow")]
        public ActionResult Index()
        {
            var series = SeriesRepo.GetAll();
            return View(series);
           
        }

        // GET: SeriesShow/Details/5
        //[Route("MovieSeries/SeriesShow/{id}")]
        [Authorize(Roles ="Normaluser")]
        public ActionResult Details(int id)
        {
            var series = SeriesRepo.GetById(id);
            var CatID = SeriesRepo.GetById(id).Category_Id;
            var Cat = lookValueRepo.GetById(CatID).Value;
            var episodes = EpisodeRepo.GetAll().Where(e => e.series_id == id).ToList();

            var allSeriesInCat = SeriesRepo.GetAll().Where(s => s.Category_Id == CatID && s.id != id).ToList();
            var userId = _userManager.GetUserId(User);
            var UserSeries = (UserSeries)userSeriesRepo.GetBySeriesId(id).Where(x => x.user_id == userId).FirstOrDefault();
            if (UserSeries == null)
            {
                UserSeries NewUser = new();
                NewUser.user_id = userId;
                NewUser.SeriesId = id;
                userSeriesRepo.Create(NewUser);
                var NewUserSeries = (UserSeries)userSeriesRepo.GetBySeriesId(id).Where(x => x.user_id == userId).FirstOrDefault();
                ViewBag.User = NewUserSeries;
            }
            else
            {
                ViewBag.User = UserSeries;
            }
            ViewBag.CatName = Cat;
            ViewBag.allMoviesCat = allSeriesInCat;
            ViewBag.Episodes = episodes;
            return View(series);

        }
        public ActionResult EpisodeDetails(int id)
        {
            var episode = EpisodeRepo.GetById(id);
            var mySeries = SeriesRepo.GetById(episode.series_id);
            var episodes = EpisodeRepo.GetAll().Where(e => e.series_id == episode.series_id&&e.Id!=id).ToList();
            var userId = _userManager.GetUserId(User);
            var UserEpisode = (UserEpisodes)userEpisodeRepo.GetByEpisodeId(id).Where(x => x.user_id == userId).FirstOrDefault();
          

            if (UserEpisode == null)
            {
                UserEpisodes NewUser = new();
                NewUser.user_id = userId;
                NewUser.EpisodeId = id;
                userEpisodeRepo.Create(NewUser);
                var NewUserEpisode = (UserEpisodes)userEpisodeRepo.GetByEpisodeId(id).Where(x => x.user_id == userId).FirstOrDefault();
                ViewBag.User = NewUserEpisode;
            }
            else
            {
                ViewBag.User = UserEpisode;
            }
            ViewBag.Episodes = episodes;
            ViewBag.mySeries = mySeries;

            //RedirectToAction(episode); 
            return View(episode);
        }
        // GET: SeriesShow/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult GetRating(int Rating, int seriesID)
        {
            var userId = _userManager.GetUserId(User);
            var id = userSeriesRepo.GetBySeriesId(seriesID).Where(usrID => usrID.user_id == userId).FirstOrDefault().id;
            var UpdatingUser = (UserSeries)userSeriesRepo.GetBySeriesId(seriesID).Where(usrID => usrID.user_id == userId).FirstOrDefault();
            UpdatingUser.Rating = Rating;
            userSeriesRepo.Update(id, UpdatingUser);
            return RedirectToAction("Details", new { id = seriesID });
        }

        public ActionResult GetFavourite(bool Fav, int seriesID)
        {
            var userId = _userManager.GetUserId(User);
            var id = userSeriesRepo.GetBySeriesId(seriesID).Where(usrID => usrID.user_id == userId).FirstOrDefault().id;
            var UpdatingUser = (UserSeries)userSeriesRepo.GetBySeriesId(seriesID).Where(usrID => usrID.user_id == userId).FirstOrDefault();
            UpdatingUser.AddToFavorite = Fav;
            userSeriesRepo.Update(id, UpdatingUser);
            return RedirectToAction("Details", new { id = seriesID });

        }

        //---------------------------------------------------Heba
        public ActionResult GetWatched(bool Wat, int seriesID)
        {
            var userId = _userManager.GetUserId(User);
            var id = userSeriesRepo.GetBySeriesId(seriesID).Where(usrID => usrID.user_id == userId).FirstOrDefault().id;
            var UpdatingUser = (UserSeries)userSeriesRepo.GetBySeriesId(seriesID).Where(usrID => usrID.user_id == userId).FirstOrDefault();
            UpdatingUser.Watched = Wat;
            userSeriesRepo.Update(id, UpdatingUser);
            return RedirectToAction("Details", new { id = seriesID });

        }
        //---------------------------------

        // POST: SeriesShow/Create
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

        // GET: SeriesShow/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SeriesShow/Edit/5
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

        // GET: SeriesShow/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SeriesShow/Delete/5
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









    
   
  