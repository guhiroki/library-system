using System.Collections.Generic;

namespace LibrarySystem.Infrastructure.Factory
{
    public interface IGenericFactory<T> where T : class
    {
        void Add(T obj);
        List<T> GetAll();
        void Update(T obj);
        void Delete(int id);
        void Dispose();
    }
}
