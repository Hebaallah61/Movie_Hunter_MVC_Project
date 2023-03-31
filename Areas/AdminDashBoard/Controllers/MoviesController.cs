using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoInterface;

namespace Movie_Hunter_FinalProject.Areas.AdminDashBoard.Controllers
{
    [Area("AdminDashBoard")]
    public class MoviesController : Controller
    {
        // GET: MoviesController
        private IGenericRepo<Movies> repo {get;}
        private ILookValueRepo Vrepo { get; }

        public MoviesController(IGenericRepo<Movies> repo, ILookValueRepo Vrepo)
        {
            this.repo = repo;
            this.Vrepo = Vrepo;
        }
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        // GET: MoviesController/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.GetById(id));
        }

        // GET: MoviesController/Create
        public ActionResult Create()
        {
            ViewBag.Category_Id = new SelectList(Vrepo.GetByName("Category"), "Id", "Value");
            return View();
        }

        // POST: MoviesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movies movie)
        {
            if(ModelState.IsValid)
            if (repo.Create(movie))
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Category_Id = new SelectList(Vrepo.GetByName("Category"), "Id", "Value");
            return View();
        }
        

        // GET: MoviesController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Category_Id = new SelectList(Vrepo.GetByName("Category"), "Id", "Value");
            return View(repo.GetById(id));
        }

        // POST: MoviesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Movies movie)
        {
            if (ModelState.IsValid)
                if (repo.update(id, movie))
                    return RedirectToAction(nameof(Index));
            ViewBag.Category_Id = new SelectList(Vrepo.GetByName("Category"), "Id", "Value");
            return View(movie);
        }

        // GET: MoviesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repo.GetById(id));
        }

        // POST: MoviesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Movies movie )
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
