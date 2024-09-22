using SchoolSystems.Models.Data;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystems.Models.Repositories
{
    public class DbBranchRepository : IRepository<Branch>
    {
        public AppDbContext Context { get; }
        public DbBranchRepository(AppDbContext _Context)
        {
            Context = _Context;
        }
        public bool Add(Branch entity)
        {
            bool result = false;
            if (entity != null)
            {
                Context.Branch.Add(entity);
                Context.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool Delete(int id, Branch entity)
        {
            bool result = false;

                Context.Branch.Remove(entity);
                Context.SaveChanges();
                result = true;
            return result;
        }

        public Branch Find(int id)
        {
            return Context.Branch.SingleOrDefault(x => x.BranchId == id);
        }

        public bool Update(int id, Branch entity)
        {
            bool result = false;
                Context.Branch.Update(entity);
                Context.SaveChanges();
                result = true;
            return result;
        }

        public IList<Branch> View()
        {
            return Context.Branch.ToList();
        }
    }
}
