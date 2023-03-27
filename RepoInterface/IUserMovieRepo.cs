using Movie_Hunter_FinalProject.Models;

namespace Movie_Hunter_FinalProject.RepoInterface
{
    public interface IUserMovieRepo
    {


        public List<UserMovies> GetAll();

        public UserMovies GetById(int id);

        public List<UserMovies> GetByUserId(string id);

        public List<UserMovies> GetByMovieId(int id);


        public bool Update(int id,UserMovies entity);

        public bool Delete (int id);

        public bool Create(UserMovies entity);
    }
}
