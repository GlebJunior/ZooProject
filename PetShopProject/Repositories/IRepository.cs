namespace PetShopProject.Repositories
{
    public interface IRepository<T>
    {
        public IQueryable<T> GetAll();
        public T? Get(int id);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(int id);
    }
}
