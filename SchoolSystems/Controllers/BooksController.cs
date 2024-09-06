using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystems.Models;
using SchoolSystems.Models.Repositories;
using SchoolSystems.ViewModels;
using System;
using System.IO;
using System.Linq;

namespace SchoolSystems.Controllers
{
    public class BooksController : Controller
    {
        private readonly IRepository<Books> Book;
        private readonly IHostingEnvironment hosting;

        public BooksController(IRepository<Books> _Books, IHostingEnvironment _Hosting)
        {
            Book = _Books;
            hosting = _Hosting;
        }
        // GET: BooksController
        public ActionResult Index()
        {
            var Bookdata = Book.View();

            return View(Bookdata);
        }

        // GET: BooksController/Details/5
        public ActionResult Details(int id)
        {
            var Bookdata = Book.Find(id);
            return View(Bookdata);
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BooksVM collection)
        {
            try
            {
                var imgAuthorUrl = CreateImages(collection.AuthorFile, "Author");
                var imgBooksUrl = CreateImages(collection.BookFile, "Books");
                var viewData = new Books 
                {
                    BookImgeUrl= imgBooksUrl,
                    BooksId=collection.BooksId,
                    AuthorImgeUrl = imgAuthorUrl,
                    BookName = collection.BookName,
                    BooksPrice = collection.BooksPrice,
                    AuthorName = collection.AuthorName,
                    BookBrnPrice=collection.BookBrnPrice,
                };
                Book.Add(viewData);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id)
        {
            var Bookdata = Book.Find(id);
            var dataBooksVM = new BooksVM
            {
                AuthorImgeUrl = Bookdata.AuthorImgeUrl,
                AuthorName = Bookdata.AuthorName,
                BookBrnPrice = Bookdata.BookBrnPrice,
                BookName = Bookdata.BookName,
                BookImgeUrl = Bookdata.BookImgeUrl,
                BooksId = Bookdata.BooksId,
                BooksPrice = Bookdata.BooksPrice
            };
            return View(dataBooksVM);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BooksVM collection)
        {
            try
            {
                var imgAuthorUrl = CreateImages(collection.AuthorFile, "Author");
                var imgBooksUrl = CreateImages(collection.BookFile, "Books");
                var viewData = new Books
                {
                    AuthorImgeUrl = imgAuthorUrl,
                    AuthorName = collection.AuthorName,
                    BookBrnPrice = collection.BookBrnPrice,
                    BookName = collection.BookName,
                    BookImgeUrl = imgBooksUrl,
                    BooksId = collection.BooksId,
                    BooksPrice = collection.BooksPrice
                };
                Book.Update(id, viewData);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {
            var Bookdata = Book.Find(id);
            return View(Bookdata);
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Books collection)
        {
            try
            {
                Book.Delete(id,collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public string CreateImages(IFormFile formFile,string filePaths)
        {
            try 
            {
                string ImagesURL = "";
                if (formFile!=null)
                {

                    string pathURL = Path.Combine(hosting.WebRootPath + "/Images/"+ filePaths);
                    FileInfo fileInfo = new FileInfo(formFile.FileName);
                    ImagesURL = "Images_" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(pathURL, ImagesURL);
                    formFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                return ImagesURL;
            }
            catch (Exception ex)
            { 

            }
            return "";
        }

        public ActionResult Search(string strName)
        {
            var Bookdata = Book.View();
            if (!string.IsNullOrEmpty(strName))
            {
                Bookdata= Bookdata.Where(x=>x.BookName.ToLower().Contains(strName.ToLower())).ToList();
            }

            return View("Index", Bookdata);
        }
    }
}
