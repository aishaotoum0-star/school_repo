using SchoolSystems.Models.Data;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystems.Models.Repositories
{
    public class DbUserRepository : IRepository<User>
    {
        public AppDbContext Context { get; }
        public DbUserRepository(AppDbContext _Context)
        {
            Context = _Context;
        }
        public bool Add(User entity)
        {
            bool result = false;
            if (entity != null)
            {
                Context.User.Add(entity);
                Context.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool Delete(int id, User entity)
        {
            bool result = false;
            Context.User.Remove(entity);
            Context.SaveChanges();
            result = true;
            
            return result;
        }

        public User Find(int id)
        {
            return Context.User.SingleOrDefault(x => x.UserId == id);
        }

        public bool Update(int id, User entity)
        {
            bool result = false;
            Context.User.Update(entity);
            Context.SaveChanges();
            result = true;
            
            return result;
        }

        public IList<User> View()
        {
            return Context.User.ToList();
        }
    }
}
