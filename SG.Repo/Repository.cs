using Microsoft.EntityFrameworkCore;
using SG.Data.Entities;

namespace SG.Repo
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ApplicationContext _applicationContext;
        private DbSet<T> entities;

        public Repository(ApplicationContext context)
        {
            this._applicationContext = context;
            entities = context.Set<T>();
        }

        public T Add(T model)
        {
            entities.Add(model);
            return model;
        }

        public void Delete(Guid id)
        {
            var model = GetById(id);
            if (model != null)
            {
                entities.Remove(model);
            }
            SaveChanges();

        }

        public T Get(T model)
        {
            //if (model != null)
            //{
            return entities.FirstOrDefault<T>((x) => x.Id == model.Id)!;
            //}
        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public T GetById(Guid id)
        {
            return entities.Find(id)!;
        }

        public void SaveChanges()
        {
            _applicationContext.SaveChanges();
        }

        public T Update(T model)
        {
            if (model != null)
            {
                entities.Update(model);
                SaveChanges();

            }
            return model!;
        }
    }
}
