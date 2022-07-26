namespace SG.Repo
{
    public interface IRepository<T>
    {
        T Add(T model);
        T GetById(Guid id);
        T Get(T model);
        IEnumerable<T> GetAll();
        T Update(T model);


        void Delete(Guid id);
        void SaveChanges();
    }
}
