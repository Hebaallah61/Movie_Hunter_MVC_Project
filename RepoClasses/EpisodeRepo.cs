using Microsoft.EntityFrameworkCore;
using Movie_Hunter_FinalProject.Areas.Identity.Data;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoInterface;

namespace Movie_Hunter_FinalProject.RepoClasses
{
    public class EpisodeRepo : IGenericRepo<Episodes>
    {
        private readonly ApplicationContext _context;

        public EpisodeRepo(ApplicationContext Context)
        {
            _context = Context;
        }
        public bool Create(Episodes entity)
        {
            try
            {
                _context.episodes.Add(entity);
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
            var toBeDeleted = _context.episodes.Find(id);
            if (toBeDeleted != null)
            {
                _context.episodes.Remove(toBeDeleted);
                _context.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public List<Episodes> GetAll()
        {
            return _context.episodes.Include(c=>c.series).ToList();
        }

        public Episodes GetById(int id)
        {
            var result = _context.episodes.Include(e=>e.series).FirstOrDefault(e=>e.Id==id);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public Episodes GetByName(string name)
        {
            var result = _context.episodes.Include(e => e.series).FirstOrDefault(e => e.Title == name);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public bool update(int id, Episodes entity)
        {
            var updatedEpisode = _context.episodes.Include(_e => _e.series).FirstOrDefault(e => e.Id == id);
            if (updatedEpisode != null)
            {
                updatedEpisode.Episode_Path = entity.Episode_Path;
                updatedEpisode.duration = entity.duration;
                updatedEpisode.Title = entity.Title;
                updatedEpisode.season= entity.season;
                updatedEpisode.series_id= entity.series_id;

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
