namespace it.Services.Base
{
    public interface IRepository <T> where T : class
    {
        List<T> FindAll();
        T? Find(int id);
        bool Delete(int id);


        void update(T entity);
        void Add(T entity);


        void save();       

    }
}
