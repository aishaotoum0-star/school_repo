using SchoolSystems.Models.Data;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystems.Models.Repositories
{
    public class DbPermissionRepository : IRepository<Permission>
    {
        public AppDbContext Context { get; }
        public DbPermissionRepository(AppDbContext _Context)
        {
            Context = _Context;
        }
        public bool Add(Permission entity)
        {
            bool result = false;
            if (entity != null)
            {
                Context.Permission.Add(entity);
                Context.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool Delete(int id, Permission entity)
        {
            bool result = false;
                Context.Permission.Remove(entity);
                Context.SaveChanges();
                result = true;
            return result;
        }

        public Permission Find(int id)
        {
            return Context.Permission.SingleOrDefault(x => x.PermissionId == id);
        }

        public bool Update(int id, Permission entity)
        {
            bool result = false;
                Context.Permission.Update(entity);
                Context.SaveChanges();
                result = true;

            return result;
        }

        public IList<Permission> View()
        {
            return Context.Permission.ToList();
        }
    }
}
