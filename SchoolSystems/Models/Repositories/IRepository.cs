using System.Collections.Generic;

namespace SchoolSystems.Models.Repositories
{
    public interface IRepository<T>
    {
        T Find(int id);
        bool Add(T entity);
        bool Update(int id,T entity);
        bool Delete(int id,T entity);
        IList<T> View();
    }
}
