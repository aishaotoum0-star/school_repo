using SchoolSystems.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystems.Models.Repositories
{
    public class DbIssuesRepository : IRepository<Issues>
    {
        public AppDbContext Context { get; }
        public DbIssuesRepository(AppDbContext _Context)
        {
            Context = _Context;
        }
        public bool Add(Issues entity)
        {
            bool result = false;
            if (entity != null)
            {
                Context.Issues.Add(entity);
                Context.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool Delete(int id, Issues entity)
        {
            bool result = false;

                Context.Issues.Remove(entity);
                Context.SaveChanges();
                result = true;
            return result;
        }

        public Issues Find(int id)
        {
            return Context.Issues.SingleOrDefault(x => x.IssuesId == id);
        }

        public bool Update(int id, Issues entity)
        {
            bool result = false;

                Context.Issues.Update(entity);
                Context.SaveChanges();
                result = true;
            return result;
        }

        public IList<Issues> View()
        {
            return Context.Issues.ToList();
        }
    }
}
