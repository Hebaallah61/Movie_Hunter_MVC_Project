using Microsoft.EntityFrameworkCore;
using Movie_Hunter_FinalProject.Areas.Identity.Data;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoInterface;

namespace Movie_Hunter_FinalProject.RepoClasses
{
    public class UserEpisodeRepo:IUserEpisodeRepo
    {
        private readonly ApplicationContext _context;

        public UserEpisodeRepo(ApplicationContext Context)
        {
            _context = Context;
        }
        public bool Create(UserEpisodes entity)
        {
            try
            {
                _context.userEpisodes.Add(entity);
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
            var result = _context.userEpisodes.Find(id);
            if (result != null)
            {
                _context.userEpisodes.Remove(result);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<UserEpisodes> GetAll()
        {
            return _context.userEpisodes.Include(u => u.systemUser).Include(m => m.episodes).ToList();
        }

        public UserEpisodes GetById(int id)
        {
            var result = _context.userEpisodes.Include(u => u.systemUser).Include(m => m.episodes).FirstOrDefault(u => u.id == id);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public List<UserEpisodes> GetByEpisodeId(int id)
        {
            var result = _context.userEpisodes.Include(u => u.systemUser).Include(m => m.episodes).Where(u => u.EpisodeId == id).ToList();
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public List<UserEpisodes> GetByUserId(string id)
        {
            var result = _context.userEpisodes.Include(u => u.systemUser).Include(m => m.episodes).Where(u => u.user_id == id).ToList();
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public bool Update(int id, UserEpisodes entity)
        {
            var result = _context.userEpisodes.Find(id);
            if (result != null)
            {
                result.Rating = entity.Rating;
                result.AddToFavorite = entity.AddToFavorite;
                result.Review = entity.Review;
                result.Watched = entity.Watched;
                result.EpisodeId = entity.EpisodeId;
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
