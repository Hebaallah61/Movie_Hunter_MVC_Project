using Movie_Hunter_FinalProject.Areas.Identity.Data;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoInterface;

namespace Movie_Hunter_FinalProject.RepoClasses
{
    public class ISeriesRepo : IGenericRepo<Series>
    {
        private readonly ApplicationContext _context;
        public ISeriesRepo(ApplicationContext Context)
        {
            _context = Context;
        }
        public bool Create(Series entity)
        {
            try
            {
                _context.series.Add(entity);
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
            var toBeDeleted = _context.series.Find(id);
            if (toBeDeleted != null)
            {
                _context.series.Remove(toBeDeleted);
                _context.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public List<Series> GetAll()
        {
            return _context.series.ToList();
        }

        public Series GetById(int id)
        {
            var result = _context.series.Find(id);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public Series GetByName(string name)
        {
            var result = _context.series.FirstOrDefault(m => m.Name == name);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public bool update(int id, Series entity)
        {
            var UpdatedSeries = _context.series.Find(id);
            if (UpdatedSeries != null)
            {
                UpdatedSeries.Name = entity.Name;
                UpdatedSeries.Thumbnail_Path = entity.Thumbnail_Path;
                UpdatedSeries.Rating = entity.Rating;
                UpdatedSeries.Description = entity.Description;
                UpdatedSeries.Category_Id = entity.Category_Id;
                UpdatedSeries.Trailer_Path = entity.Trailer_Path;
                UpdatedSeries.NumberOfSeasons = entity.NumberOfSeasons;

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
