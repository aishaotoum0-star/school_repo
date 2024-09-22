using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystems.Models;
using SchoolSystems.Models.Repositories;

namespace SchoolSystems.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IRepository<Issues> issues;
        private readonly IRepository<Books> books;
        private readonly IRepository<Student> student;

        public IssuesController(IRepository<Issues> _Issues,IRepository<Books> _Books, IRepository<Student> _Student)
        {
            issues = _Issues;
            books = _Books;
            student = _Student;
        }
        // GET: IssuesController
        public ActionResult Index()
        {
            var dataIssues = issues.View();
            foreach (var item in dataIssues)
            {
                item.Student = student.Find(item.StudentId);
                item.Books = books.Find(item.BooksId);
            }
            return View(dataIssues);
        }

        // GET: IssuesController/Details/5
        public ActionResult Details(int id)
        {
            var dataIssues = issues.Find(id);
            dataIssues.Student = student.Find(dataIssues.StudentId);
            dataIssues.Books = books.Find(dataIssues.BooksId);
            return View(dataIssues);
        }

        // GET: IssuesController/Create
        public ActionResult Create()
        {
            ViewBag.Student = student.View();
            ViewBag.Books = books.View();
            return View();
        }

        // POST: IssuesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Issues collection)
        {
            try
            {
                issues.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IssuesController/Edit/5
        public ActionResult Edit(int id)
        {
            var dataIssues = issues.Find(id);
            ViewBag.Student = student.View();
            ViewBag.Books = books.View();
            dataIssues.Student = student.Find(dataIssues.StudentId);
            dataIssues.Books = books.Find(dataIssues.BooksId);
            return View(dataIssues);
        }

        // POST: IssuesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Issues collection)
        {
            try
            {
                issues.Update(id,collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IssuesController/Delete/5
        public ActionResult Delete(int id)
        {
            var dataIssues = issues.Find(id);
            dataIssues.Student = student.Find(dataIssues.StudentId);
            dataIssues.Books = books.Find(dataIssues.BooksId);
            return View(dataIssues);
        }

        // POST: IssuesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Issues collection)
        {
            try
            {
                issues.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
