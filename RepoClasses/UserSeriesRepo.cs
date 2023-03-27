using Microsoft.EntityFrameworkCore;
using Movie_Hunter_FinalProject.Areas.Identity.Data;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoInterface;

namespace Movie_Hunter_FinalProject.RepoClasses
{
    public class UserSeriesRepo:IUserSeriesRepo
    {
        private readonly ApplicationContext _context;

        public UserSeriesRepo(ApplicationContext Context)
        {
            _context = Context;
        }
        public bool Create(UserSeries entity)
        {
            try
            {
                _context.userSeries.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var result = _context.userSeries.Find(id);
            if (result != null)
            {
                _context.userSeries.Remove(result);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<UserSeries> GetAll()
        {
            return _context.userSeries.Include(u => u.systemUser).Include(m => m.series).ToList();
        }

        public UserSeries GetById(int id)
        {
            var result = _context.userSeries.Include(u => u.systemUser).Include(m => m.series).FirstOrDefault(u => u.id == id);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public List<UserSeries> GetBySeriesId(int id)
        {
            var result = _context.userSeries.Include(u => u.systemUser).Include(m => m.series).Where(u => u.SeriesId == id).ToList();
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public List<UserSeries> GetByUserId(string id)
        {
            var result = _context.userSeries.Include(u => u.systemUser).Include(m => m.series).Where(u => u.user_id == id).ToList();
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public bool Update(int id, UserSeries entity)
        {
            var result = _context.userSeries.Find(id);
            if (result != null)
            {
                result.Rating = entity.Rating;
                result.AddToFavorite = entity.AddToFavorite;
                result.Review = entity.Review;
                result.Watched = entity.Watched;
                result.SeriesId = entity.SeriesId;
                result.user_id = entity.user_id;
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
