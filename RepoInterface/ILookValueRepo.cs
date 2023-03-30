using Movie_Hunter_FinalProject.Models;

namespace Movie_Hunter_FinalProject.RepoInterface
{
    public interface ILookValueRepo
    {
        public LookUpValues GetById(int id);

        public List<LookUpValues> GetAll();

        public List<LookUpValues> GetByName(string name);


        public bool DeleteById(int id);

        public bool update(int id, LookUpValues entity);

        public bool Create(LookUpValues entity);
    }
}
