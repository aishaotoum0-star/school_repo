using SchoolSystems.Models.Data;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystems.Models.Repositories
{
    public class DbBooksRepository : IRepository<Books>
    {
        public AppDbContext Context { get; }
        public DbBooksRepository(AppDbContext _Context)
        {
            Context = _Context;
        }
        public bool Add(Books entity)
        {
            bool result = false;
            if (entity != null)
            {
                Context.Books.Add(entity);
                Context.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool Delete(int id, Books entity)
        {
            bool result = false;
                Context.Books.Remove(entity);
                Context.SaveChanges();
                result = true;
            
            return result;
        }

        public Books Find(int id)
        {
            return Context.Books.SingleOrDefault(x => x.BooksId == id);
        }

        public bool Update(int id, Books entity)
        {
            bool result = false;

                Context.Books.Update(entity);
                Context.SaveChanges();
                result = true;
            return result;
        }

        public IList<Books> View()
        {
            return Context.Books.ToList();
        }
    }
}
