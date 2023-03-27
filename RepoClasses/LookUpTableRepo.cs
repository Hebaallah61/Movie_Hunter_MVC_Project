using Microsoft.CodeAnalysis.Operations;
using Movie_Hunter_FinalProject.Areas.Identity.Data;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoInterface;

namespace Movie_Hunter_FinalProject.RepoClasses
{
    public class LookUpTableRepo : IGenericRepo<LookUpTable>
    {
        private readonly ApplicationContext _context;

        public LookUpTableRepo(ApplicationContext Context)
        {
            _context = Context;
        }
        public bool Create(LookUpTable entity)
        {
            try
            {
                _context.lookUpTables.Add(entity);
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
            var toBeDeleted = _context.lookUpTables.Find(id);
            if (toBeDeleted != null)
            {
                _context.lookUpTables.Remove(toBeDeleted);
                _context.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public List<LookUpTable> GetAll()
        {
            return _context.lookUpTables.ToList();
        }

        public LookUpTable GetById(int id)
        {
            var result = _context.lookUpTables.Find(id);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public LookUpTable GetByName(string name)
        {
            var result = _context.lookUpTables.FirstOrDefault(m => m.LookUpName == name);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public bool update(int id, LookUpTable entity)
        {

            var UpdatedLookupTable = _context.lookUpTables.Find(id);
            if (UpdatedLookupTable != null)
            {
                UpdatedLookupTable.LookUpName = entity.LookUpName;

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
