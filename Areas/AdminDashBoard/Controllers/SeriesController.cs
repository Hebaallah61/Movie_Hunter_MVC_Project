using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoInterface;

namespace Movie_Hunter_FinalProject.Areas.AdminDashBoard.Controllers
{
    [Area("AdminDashBoard")]
    public class SeriesController : Controller
    {
        private IGenericRepo<Series> repo { get; }
        private ILookValueRepo Vrepo { get; }

        public SeriesController(IGenericRepo<Series> repo, ILookValueRepo Vrepo)
        {
            this.repo = repo;
            this.Vrepo = Vrepo;
        }
        // GET: SeriesController
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        // GET: SeriesController/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.GetById(id));
        }

        // GET: SeriesController/Create
        public ActionResult Create()
        {
            ViewBag.Category_Id = new SelectList(Vrepo.GetByName("Categories"), "Id", "Value");
            return View();
        }

        // POST: SeriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Series series)
        {
            if (ModelState.IsValid)
                if (repo.Create(series))
                {
                    return RedirectToAction(nameof(Index));
                }
            return View();
        }

        // GET: SeriesController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Category_Id = new SelectList(Vrepo.GetByName("Categories"), "Id", "Value");
            return View(repo.GetById(id));
        }

        // POST: SeriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Series series)
        {
            if (ModelState.IsValid)
                if (repo.update(id, series))
                    return RedirectToAction(nameof(Index));
            ViewBag.Category_Id = new SelectList(Vrepo.GetByName("Categories"), "Id", "Value");
            return View(series);
        }

        // GET: SeriesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repo.GetById(id));

        }

        // POST: SeriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Series series)
        {
            try
            {
                if (repo.DeleteById(id))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
