using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystems.Models.Repositories
{
    public class IssuesRepository : IRepository<Issues>
    {
        List<Issues> lstIssues;
        public IssuesRepository()
        {
            lstIssues=new List<Issues> 
            {
                new Issues{IssuesId=1,IssuesDate=DateTime.Now,BooksId=1,StudentId=5 },
                new Issues{IssuesId=2,IssuesDate=DateTime.Now,BooksId=2,StudentId=4 },
                new Issues{IssuesId=3,IssuesDate=DateTime.Now,BooksId=3,StudentId=3 },
                new Issues{IssuesId=4,IssuesDate=DateTime.Now,BooksId=4,StudentId=2 },
                new Issues{IssuesId=5,IssuesDate=DateTime.Now,BooksId=5,StudentId=1 },
            };
        }
        public bool Add(Issues entity)
        {
            bool result = false;
            if (entity != null)
            {
                lstIssues.Add(entity);
                result = true;
            }
            return result;
        }

        public bool Delete(int id, Issues entity)
        {
            bool result = false;
            entity = Find(id);
            if (entity != null)
            {
                lstIssues.Remove(entity);
                result = true;
            }
            return result;
        }

        public Issues Find(int id)
        {
            return lstIssues.Find(x => x.IssuesId == id);
        }

        public bool Update(int id, Issues entity)
        {
            bool result = false;
            var data = Find(id);
            if (entity != null && data != null)
            {
                data.BooksId = entity.BooksId;
                data.StudentId = entity.StudentId;
                data.IssuesDate = entity.IssuesDate;
                result = true;
            }
            return result;
        }

        public IList<Issues> View()
        {
            return lstIssues.ToList();
        }
    }
}
