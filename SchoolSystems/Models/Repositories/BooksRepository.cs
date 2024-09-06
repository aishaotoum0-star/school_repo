using System.Collections.Generic;
using System.Linq;

namespace SchoolSystems.Models.Repositories
{
    public class BooksRepository : IRepository<Books>
    {
        List<Books> lstBooks;
        public BooksRepository()
        {
            lstBooks=new List<Books>
            {
                new Books{ BooksId=1,BookName="Java",BooksPrice=350,BookBrnPrice=200,AuthorName="Ahmed",BookImgeUrl="Users.png",AuthorImgeUrl="Users.png"},
                new Books{ BooksId=2,BookName="Python",BooksPrice=700,BookBrnPrice=300,AuthorName="Zaid",BookImgeUrl="Users.png",AuthorImgeUrl="Users.png"},
                new Books{ BooksId=3,BookName="C#",BooksPrice=500,BookBrnPrice=150,AuthorName="Abdallah",BookImgeUrl="Users.png",AuthorImgeUrl="Users.png"},
                new Books{ BooksId=4,BookName="C++",BooksPrice=200,BookBrnPrice=100,AuthorName="Yazan",BookImgeUrl="Users.png",AuthorImgeUrl="Users.png"},
                new Books{ BooksId=5,BookName="Asp.net",BooksPrice=325,BookBrnPrice=120,AuthorName="Moath",BookImgeUrl="Users.png",AuthorImgeUrl="Users.png"},
            };
        }
        public bool Add(Books entity)
        {
            bool result = false;
            if (entity != null)
            {
                lstBooks.Add(entity);
                result = true;
            }
            return result;
        }

        public bool Delete(int id, Books entity)
        {
            bool result = false;
            entity = Find(id);
            if (entity != null)
            {
                lstBooks.Remove(entity);
                result = true;
            }
            return result;
        }

        public Books Find(int id)
        {
            return lstBooks.Find(x => x.BooksId == id);
        }

        public bool Update(int id, Books entity)
        {
            bool result = false;
            var data  = Find(id);
            if (entity != null && data!=null)
            {
                data.BookName = entity.BookName;
                data.AuthorName = entity.AuthorName;
                data.BooksPrice = entity.BooksPrice;
                data.BookImgeUrl = entity.BookImgeUrl;
                data.BookBrnPrice = entity.BookBrnPrice;
                data.AuthorImgeUrl = entity.AuthorImgeUrl;

                result = true;
            }
            return result;
        }

        public IList<Books> View()
        {
            return lstBooks.ToList();
        }
    }
}
