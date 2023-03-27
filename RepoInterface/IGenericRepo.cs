namespace Movie_Hunter_FinalProject.RepoInterface
{
    public interface IGenericRepo<T>
    {

        public T GetById(int id);

        public List<T> GetAll();

        public T GetByName(string name);
 

        public bool DeleteById(int id);

        public bool update(int id, T entity);

        public bool Creata(T entity);


    }
}
