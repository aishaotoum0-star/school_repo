using SchoolSystems.Models.Data;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystems.Models.Repositories
{
    public class DbLoginRepository : IRepository<Login>
    {
        public AppDbContext Context { get; }

        public DbLoginRepository(AppDbContext _Context)
        {
            Context = _Context;
        }
        public bool Add(Login entity)
        {
            bool result = false;
            if (entity != null)
            {
                Context.Login.Add(entity);
                Context.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool Delete(int id, Login entity)
        {
            bool result = false;

                Context.Login.Remove(entity);
                Context.SaveChanges();
                result = true;

            return result;
        }

        public Login Find(int id)
        {
            return Context.Login.SingleOrDefault(x => x.LoginId == id);
        }

        public bool Update(int id, Login entity)
        {
            bool result = false;
                Context.Login.Update(entity);
                Context.SaveChanges();
                result = true;
            return result;
        }

        public IList<Login> View()
        {
            return Context.Login.ToList();
        }
    }
}
