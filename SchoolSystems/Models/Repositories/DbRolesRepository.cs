using SchoolSystems.Models.Data;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystems.Models.Repositories
{
    public class DbRolesRepository : IRepository<Roles>
    {
        public AppDbContext Context { get; }
        public DbRolesRepository(AppDbContext _Context)
        {
            Context = _Context;
        }
        public bool Add(Roles entity)
        {
            bool result = false;
            if (entity != null)
            {
                Context.Roles.Add(entity);
                Context.SaveChanges ();
                result = true;
            }
            return result;
        }

        public bool Delete(int id, Roles entity)
        {
            bool result = false;

            Context.Roles.Remove(entity);
            Context.SaveChanges();
            result = true;
           
            return result;
        }

        public Roles Find(int id)
        {
            return Context.Roles.SingleOrDefault(x => x.RolesId == id);
        }

        public bool Update(int id, Roles entity)
        {
            bool result = false;
            Context.Roles.Update(entity);
            Context.SaveChanges();
            return result;
        }

        public IList<Roles> View()
        {
            return Context.Roles.ToList();
        }
    }
}
