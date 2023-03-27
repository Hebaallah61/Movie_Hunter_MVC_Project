using Movie_Hunter_FinalProject.Models;

namespace Movie_Hunter_FinalProject.RepoInterface
{
    public interface IUserSeriesRepo
    {
        public List<UserSeries> GetAll();

        public UserSeries GetById(int id);

        public List<UserSeries> GetByUserId(string id);

        public List<UserSeries> GetBySeriesId(int id);


        public bool Update(int id, UserSeries entity);

        public bool Delete(int id);

        public bool Create(UserSeries entity);
    }
}
