using SchoolSystems.Models.Data;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystems.Models.Repositories
{
    public class DbStudentRepository : IRepository<Student>
    {
        public AppDbContext Context { get; }
        public DbStudentRepository(AppDbContext _Context)
        {
            Context = _Context;
        }
        public bool Add(Student entity)
        {
            bool result = false;
            if (entity != null)
            {
                Context.Student.Add(entity);
                Context.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool Delete(int id, Student entity)
        {
            bool result = false;
            Context.Student.Remove(entity);
            Context.SaveChanges();
            return result;
        }

        public Student Find(int id)
        {
            return Context.Student.SingleOrDefault(x => x.StudentId == id);
        }

        public bool Update(int id, Student entity)
        {
            bool result = false;
            Context.Student.Update(entity);
            Context.SaveChanges();
            result = true;
            return result;
        }

        public IList<Student> View()
        {
            return Context.Student.ToList();
        }
    }
}
