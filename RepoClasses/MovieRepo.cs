using Microsoft.EntityFrameworkCore;
using Movie_Hunter_FinalProject.Areas.Identity.Data;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoInterface;

namespace Movie_Hunter_FinalProject.RepoClasses
{
    public class MovieRepo : IGenericRepo<Movies>
    {
        private readonly ApplicationContext _context;

        public MovieRepo(ApplicationContext Context)
        {
            _context = Context;
        }

        public bool Create(Movies entity)
        {
            try
            {
                _context.movies.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
           
        }

        public bool DeleteById(int id)
        {
            var toBeDeleted = _context.movies.Find(id);
            if (toBeDeleted != null)
            {
                _context.movies.Remove(toBeDeleted);
                _context.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public List<Movies> GetAll()
        {
            return _context.movies.Include(m=>m.lookUpValues).ToList();
        }

        public Movies GetById(int id)
        {
            var result = _context.movies.Include(m => m.lookUpValues).FirstOrDefault(m=>m.id==id);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public Movies GetByName(string name)
        {
            var result = _context.movies.FirstOrDefault(m=>m.Name==name);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public bool update(int id, Movies entity)
        {
            var UpdatedMovie = _context.movies.Find(id);
            if(UpdatedMovie!=null)
            {
                UpdatedMovie.Name = entity.Name;
                UpdatedMovie.Thumbnail_Path = entity.Thumbnail_Path;
                UpdatedMovie.Rating = entity.Rating;
                UpdatedMovie.Description = entity.Description;
                UpdatedMovie.Category_Id = entity.Category_Id;
                UpdatedMovie.Trailer_Path = entity.Trailer_Path;
                UpdatedMovie.Duration = entity.Duration;
                UpdatedMovie.Movie_Path = entity.Movie_Path;

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
