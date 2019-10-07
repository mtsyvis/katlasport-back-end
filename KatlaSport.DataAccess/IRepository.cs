using System;
using System.Linq;
using System.Linq.Expressions;

namespace KatlaSport.DataAccess
{
    public interface IRepository<T>
        where T : class
    {
        void Add(T obj);

        void Delete(T obj);

        void Update(T obj);

        T GetItem(int id);

        IQueryable<T> GetItems(Expression<Func<T, bool>> query);

        IQueryable<T> GetItems();

        void SaveChanges();
    }
}
