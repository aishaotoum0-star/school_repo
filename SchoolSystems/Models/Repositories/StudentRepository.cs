using System.Collections.Generic;
using System.Linq;

namespace SchoolSystems.Models.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        List<Student> lstStudents;
        public StudentRepository()
        {
            lstStudents= new List<Student> 
            {
                new Student{StudentId=1,StudentName="Ali",StudentEmail="Ali@gmail.com",StudentPhone="0786352551",StudentDob="",StudentImageURL="Users.png" },
                new Student{StudentId=2,StudentName="Ahmmed",StudentEmail="Ahmmed@gmail.com",StudentPhone="0786352551",StudentDob="",StudentImageURL="Users.png" },
                new Student{StudentId=3,StudentName="Khalid",StudentEmail="Khalid@gmail.com",StudentPhone="0786352551",StudentDob="",StudentImageURL="Users.png" },
                new Student{StudentId=4,StudentName="Islam",StudentEmail="Islam@gmail.com",StudentPhone="0786352551",StudentDob="",StudentImageURL="Users.png" },
                new Student{StudentId=5,StudentName="Abd",StudentEmail="Abd@gmail.com",StudentPhone="0786352551",StudentDob="",StudentImageURL="Users.png" },
            };
        }
        public bool Add(Student entity)
        {
            bool result = false;
            if (entity != null)
            {
                lstStudents.Add(entity);
                result = true;
            }
            return result;
        }

        public bool Delete(int id, Student entity)
        {
            bool result = false;
            entity = Find(id);
            if (entity != null)
            {
                lstStudents.Remove(entity);
                result = true;
            }
            return result;
        }

        public Student Find(int id)
        {
            return lstStudents.Find(x => x.StudentId == id);
        }

        public bool Update(int id, Student entity)
        {
            bool result = false;
            var data = Find(id);
            if (entity != null && data != null)
            {
                data.StudentDob = entity.StudentDob;
                data.StudentName = entity.StudentName;
                data.StudentEmail = entity.StudentEmail;
                data.StudentPhone = entity.StudentPhone;
                data.StudentImageURL = entity.StudentImageURL;
                result = true;
            }
            return result;
        }

        public IList<Student> View()
        {
            return lstStudents.ToList();
        }
    }
}
