using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Movie_Hunter_FinalProject.Areas.MovieSeries.Controllers
{
    [Area("MovieSeries")]
    public class MovieShowController : Controller
    {
        // GET: MovieShowController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MovieShowController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
