using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoInterface;

namespace Movie_Hunter_FinalProject.Areas.AdminDashBoard.Controllers
{
    [Area("AdminDashBoard")]
    public class EpisodesController : Controller
    {
        public IGenericRepo<Episodes> Repo { get; }
        private IGenericRepo<Series> Srepo { get; }

        // GET: EpisodesController
        public EpisodesController(IGenericRepo<Episodes> repo, IGenericRepo<Series> srepo)
        {
            Repo = repo;
            Srepo = srepo;
        }
        public ActionResult Index()
        {
            ViewBag.Series = Srepo.GetAll();
            return View(Repo.GetAll());
        }
        [HttpPost]
        public ActionResult Index(int S)
        {
            List<Episodes> ep = Repo.GetAll().Where(e=>e.series_id== S).ToList();
            ViewBag.Series = Srepo.GetAll();
            return View(ep);
        }
        // GET: EpisodesController/Details/5
        public ActionResult Details(int id)
        {
            return View(Repo.GetById(id));
        }

        // GET: EpisodesController/Create
        public ActionResult Create()
        {
            ViewBag.series_id = new SelectList(Srepo.GetAll(), "id", "Name");
            return View();
        }

        // POST: EpisodesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Episodes E)
        {
            if (ModelState.IsValid)
                if (Repo.Create(E))
                {
                    return RedirectToAction(nameof(Index));
                }
            return View();
        }

        // GET: EpisodesController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.series_id = new SelectList(Srepo.GetAll(), "id", "Name");
            return View(Repo.GetById(id));
        }

        // POST: EpisodesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Episodes E )
        {
            if (ModelState.IsValid)
                if (Repo.update(id, E))
                    return RedirectToAction(nameof(Index));
            ViewBag.series_id = new SelectList(Srepo.GetAll(), "id", "Name");
            return View(E);
        }

        // GET: EpisodesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Repo.GetById(id));
        }

        // POST: EpisodesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Episodes E )
        {
            try
            {
                if (Repo.DeleteById(id))
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
