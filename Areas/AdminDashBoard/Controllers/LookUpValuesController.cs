using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoClasses;
using Movie_Hunter_FinalProject.RepoInterface;

namespace Movie_Hunter_FinalProject.Areas.AdminDashBoard.Controllers
{
    [Area("AdminDashBoard")]
    [Authorize(Roles = "Admin")]
    public class LookUpValuesController : Controller
    {
        private ILookValueRepo repo { get; }
        private IGenericRepo<LookUpTable> Trepo { get; }

        public LookUpValuesController(ILookValueRepo repo, IGenericRepo<LookUpTable> Trepo)
        {
            this.repo = repo;
            this.Trepo = Trepo;
        }
        // GET: LookUpValuesController
        public ActionResult Index()
        {
            return View(repo.GetAll()); 
        }

        // GET: LookUpValuesController/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.GetById(id));
        }

        // GET: LookUpValuesController/Create
        public ActionResult Create()
        {
            ViewBag.lookupId = new SelectList(Trepo.GetAll(), "Id", "LookUpName");
            return View();
        }

        // POST: LookUpValuesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LookUpValues val)
        {
            if (ModelState.IsValid)
            {
                if (repo.Create(val))
                    return RedirectToAction(nameof(Index));
            }
               
           
            ViewBag.lookupId = new SelectList(Trepo.GetAll(), "Id", "LookUpName");

            return View();
        }

        // GET: LookUpValuesController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.lookupId = new SelectList(Trepo.GetAll(), "Id", "LookUpName");
            return View(repo.GetById(id));
        }

        // POST: LookUpValuesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LookUpValues val)
        {
            
                if (repo.update(id, val))
                {
                    return RedirectToAction(nameof(Index));
                }
            ViewBag.lookupId = new SelectList(Trepo.GetAll(), "Id", "LookUpName");
            return View();
            
        }

        // GET: LookUpValuesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repo.GetById(id));
        }

        // POST: LookUpValuesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LookUpValues val)
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
