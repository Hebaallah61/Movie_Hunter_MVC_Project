using Microsoft.EntityFrameworkCore;
using Movie_Hunter_FinalProject.Areas.Identity.Data;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoInterface;

namespace Movie_Hunter_FinalProject.RepoClasses
{
    public class LookUpValuesRepo : ILookValueRepo/* IGenericRepo<LookUpValues>*/
    {
        private readonly ApplicationContext _context;

        public LookUpValuesRepo(ApplicationContext Context)
        {
            _context = Context;
        }
        public bool Create(LookUpValues entity)
        {
            try
            {
                _context.lookUpValues.Add(entity);
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
            var toBeDeleted = _context.lookUpValues.Find(id);
            if (toBeDeleted != null)
            {
                _context.lookUpValues.Remove(toBeDeleted);
                _context.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public List<LookUpValues> GetAll()
        {
            return _context.lookUpValues.Include(l => l.lookUpTable).ToList();
        }

        public LookUpValues GetById(int id)
        {
            var result = _context.lookUpValues.Include(l=>l.lookUpTable).FirstOrDefault(l=>l.Id==id);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public List<LookUpValues> GetByName(string name)
        {
            var result = _context.lookUpValues.Include(l => l.lookUpTable).Where(l=>l.lookUpTable.LookUpName==name).ToList();
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public bool update(int id, LookUpValues entity)
        {

            var UpdatedLookupValue = _context.lookUpValues.Find(id);
            if (UpdatedLookupValue != null)
            {
                UpdatedLookupValue.Value = entity.Value;
                UpdatedLookupValue.lookupId = entity.lookupId;

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
