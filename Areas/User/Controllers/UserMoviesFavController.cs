using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie_Hunter_FinalProject.Areas.Identity.Data;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoInterface;

namespace Movie_Hunter_FinalProject.Areas.User.Controllers
{
    [Area("User")]
    public class UserMoviesFavController : Controller
    {
        public IUserMovieRepo UserMoveRepo { get; }
        private readonly UserManager<SystemUser> _userManager;
        private readonly SignInManager<SystemUser> _signInManager;

    

        public UserMoviesFavController(IUserMovieRepo URepo, UserManager<SystemUser> userManager,
            SignInManager<SystemUser> signInManager)
        {
            UserMoveRepo = URepo;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        // GET: User/UserMoviesFav
        public async Task<IActionResult> Index(string id)
        {
            var movies = UserMoveRepo.GetAll().Where(m => m.AddToFavorite == true && m.user_id == id);
            return View(movies);
        }

        //// GET: User/UserMoviesFav/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.userMovies == null)
        //    {
        //        return NotFound();
        //    }

        //    var userMovies = await _context.userMovies
        //        .FirstOrDefaultAsync(m => m.id == id);
        //    if (userMovies == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(userMovies);
        //}

        //// GET: User/UserMoviesFav/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: User/UserMoviesFav/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("id,Rating,AddToFavorite,Review,Watched,MovieId,user_id")] UserMovies userMovies)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(userMovies);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(userMovies);
        //}

        //// GET: User/UserMoviesFav/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.userMovies == null)
        //    {
        //        return NotFound();
        //    }

        //    var userMovies = await _context.userMovies.FindAsync(id);
        //    if (userMovies == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(userMovies);
        //}

        //// POST: User/UserMoviesFav/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("id,Rating,AddToFavorite,Review,Watched,MovieId,user_id")] UserMovies userMovies)
        //{
        //    if (id != userMovies.id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(userMovies);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserMoviesExists(userMovies.id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(userMovies);
        //}

        //// GET: User/UserMoviesFav/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.userMovies == null)
        //    {
        //        return NotFound();
        //    }

        //    var userMovies = await _context.userMovies
        //        .FirstOrDefaultAsync(m => m.id == id);
        //    if (userMovies == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(userMovies);
        //}

        //// POST: User/UserMoviesFav/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.userMovies == null)
        //    {
        //        return Problem("Entity set 'ApplicationContext.userMovies'  is null.");
        //    }
        //    var userMovies = await _context.userMovies.FindAsync(id);
        //    if (userMovies != null)
        //    {
        //        _context.userMovies.Remove(userMovies);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UserMoviesExists(int id)
        //{
        //  return (_context.userMovies?.Any(e => e.id == id)).GetValueOrDefault();
        //}
    }
}
