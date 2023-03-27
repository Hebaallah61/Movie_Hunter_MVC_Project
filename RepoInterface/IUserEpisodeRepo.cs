using Movie_Hunter_FinalProject.Models;

namespace Movie_Hunter_FinalProject.RepoInterface
{
    public interface IUserEpisodeRepo
    {
        public List<UserEpisodes> GetAll();

        public UserEpisodes GetById(int id);

        public List<UserEpisodes> GetByUserId(string id);

        public List<UserEpisodes> GetByEpisodeId(int id);


        public bool Update(int id, UserEpisodes entity);

        public bool Delete(int id);

        public bool Create(UserEpisodes entity);
    }
}
