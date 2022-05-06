using Microsoft.EntityFrameworkCore;

namespace it.Services.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly DbContext _context;
        public Repository(DbContext context )
        {
            this._context = context;
        }

        public void Add(T entity)
        {
            this._context.Set<T>().Add(entity);
            this.save();
        }

        public bool Delete(int id)
        {
            bool deleteStatus  = false;
            T? value = this.Find(id);
            if (value != null) { 
                this._context.Set<T>().Remove(value);
                this.save();
                deleteStatus = true;
            }
            return deleteStatus;
        }

        public T? Find(int id)
        {
            return this._context.Set<T>().Find(id);
        }

        public List<T> FindAll()
        {
            return this._context.Set<T>().ToList();
        }

        public void save()
        {
            this._context.SaveChanges();
        }

        public void update(T entity)
        {

            this._context.Set<T>().Update(entity);
            this.save();
        }

    }
}
