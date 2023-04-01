using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoInterface;
using System.Net;

namespace Movie_Hunter_FinalProject.Areas.AdminDashBoard.Controllers
{
    [Area("AdminDashBoard")]
    [Authorize(Roles = "Admin")]
    public class LookUpTablesController : Controller
    {
        private IGenericRepo<LookUpTable> repo { get; }
       // private ILookValueRepo Vrepo { get; }

        public LookUpTablesController(IGenericRepo<LookUpTable> repo/*, ILookValueRepo Vrepo*/)
        {
            this.repo = repo;
            //this.Vrepo = Vrepo;
        }
        // GET: LookUpTablesController
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        // GET: LookUpTablesController/Details/5
        public ActionResult Details(int id)
        {
           
            return View(repo.GetById(id));
        }

        // GET: LookUpTablesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LookUpTablesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LookUpTable table)
        {
            if (ModelState.IsValid)
            {
                if (repo.Create(table))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
                    return View();
        }

        // GET: LookUpTablesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.GetById(id));
        }

        // POST: LookUpTablesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LookUpTable table)
        {
          if(ModelState.IsValid)
                if (repo.update(id, table))
                {
                    return RedirectToAction(nameof(Index));
                }
                return View();
            
        }

        // GET: LookUpTablesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repo.GetById(id));
        }

        // POST: LookUpTablesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LookUpTable table)
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
