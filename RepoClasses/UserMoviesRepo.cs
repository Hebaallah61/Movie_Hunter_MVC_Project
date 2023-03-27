using Microsoft.EntityFrameworkCore;
using Movie_Hunter_FinalProject.Areas.Identity.Data;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoInterface;

namespace Movie_Hunter_FinalProject.RepoClasses
{
    public class UserMoviesRepo : IUserMovieRepo
    {
        private readonly ApplicationContext _context;

        public UserMoviesRepo(ApplicationContext Context)
        {
            _context = Context;
        }
        public bool Create(UserMovies entity)
        {
            try
            {
                _context.userMovies.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch ( Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var result = _context.userMovies.Find(id);
            if(result == null)
            {
                _context.userMovies.Remove(result);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<UserMovies> GetAll()
        {
            return _context.userMovies.Include(u=>u.systemUser).Include(m=>m.movies).ToList();
        }

        public UserMovies GetById(int id)
        {
            var result= _context.userMovies.Include(u => u.systemUser).Include(m => m.movies).FirstOrDefault(u=>u.id==id);
            if(result!=null)
            {
                return result;
            }
            else
            {
                return null; 
            }
        }

        public List<UserMovies> GetByMovieId(int id)
        {
            var result=_context.userMovies.Include(u=>u.systemUser).Include(m=>m.movies).Where(u=>u.MovieId==id).ToList();
            if(result!=null)
            {
                return result;
            }
            else{
                return null;
            }
        }

        public List<UserMovies> GetByUserId(string id)
        {
            var result = _context.userMovies.Include(u => u.systemUser).Include(m => m.movies).Where(u => u.user_id == id).ToList();
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public bool Update(int id, UserMovies entity)
        {
            var result = _context.userMovies.Find(id);
            if(result!=null)
            {
                result.Rating = entity.Rating;
                result.AddToFavorite=entity.AddToFavorite;
                result.Review=entity.Review;
                result.Watched=entity.Watched;
                result.MovieId=entity.MovieId;
                result.user_id=entity.user_id;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
