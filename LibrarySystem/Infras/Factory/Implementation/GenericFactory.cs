using Infrastructure.Entity;
using LibrarySystem.Infrastructure.Factory;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace LibrarySystem.Infrastructure
{
    public class GenericFactory<T, M> : IDisposable, IGenericFactory<T> 
        where T : class
        where M : DbContext
    {
        protected BaseEntity Db = new BaseEntity();
        public void Add(T obj)
        {
            using (var context = (M)Activator.CreateInstance(typeof(M)))
            {
                context.Set<T>().Add(obj);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = (M)Activator.CreateInstance(typeof(M)))
            {
                T entity = context.Set<T>().Find(id);
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            List<T> list = new List<T>();
            using (var context = (M)Activator.CreateInstance(typeof(M)))
            {
                foreach (T entity in context.Set<T>().AsNoTracking<T>())
                {
                    list.Add(entity);
                }
            }
            return list;
        }
        public T Get(int id)
        {
            using (var context = (M)Activator.CreateInstance(typeof(M)))
            {
                return context.Set<T>().Find(id);
            }
        }
        public void Update(T obj)
        {
            using (var context = (M)Activator.CreateInstance(typeof(M)))
            {
                context.Entry(obj).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
