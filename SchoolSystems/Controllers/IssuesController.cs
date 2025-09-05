using Microsoft.AspNetCore.Mvc;
using SchoolSystems.Models;
using SchoolSystems.Models.Repositories;
using System;

namespace SchoolSystems.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IRepository<Issues> _issues;
        private readonly IRepository<Books> _books;
        private readonly IRepository<Student> _students;

        public IssuesController(IRepository<Issues> issues, IRepository<Books> books, IRepository<Student> students)
        {
            _issues = issues;
            _books = books;
            _students = students;
        }

        // GET: IssuesController
        public IActionResult Index()
        {
            var dataIssues = _issues.View();
            foreach (var item in dataIssues)
            {
                item.Student = _students.Find(item.StudentId);
                item.Books = _books.Find(item.BooksId);
            }
            return View(dataIssues);
        }

        // GET: IssuesController/Details/5
        public IActionResult Details(int id)
        {
            var dataIssues = _issues.Find(id);
            if (dataIssues == null)
                return NotFound();

            dataIssues.Student = _students.Find(dataIssues.StudentId);
            dataIssues.Books = _books.Find(dataIssues.BooksId);
            return View(dataIssues);
        }

        // GET: IssuesController/Create
        public IActionResult Create()
        {
            ViewBag.Student = _students.View();
            ViewBag.Books = _books.View();
            return View();
        }

        // POST: IssuesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Issues collection)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Student = _students.View();
                ViewBag.Books = _books.View();
                return View(collection);
            }

            try
            {
                _issues.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An error occurred while creating the issue.");
                ViewBag.Student = _students.View();
                ViewBag.Books = _books.View();
                return View(collection);
            }
        }

        // GET: IssuesController/Edit/5
        public IActionResult Edit(int id)
        {
            var dataIssues = _issues.Find(id);
            if (dataIssues == null)
                return NotFound();

            ViewBag.Student = _students.View();
            ViewBag.Books = _books.View();
            dataIssues.Student = _students.Find(dataIssues.StudentId);
            dataIssues.Books = _books.Find(dataIssues.BooksId);
            return View(dataIssues);
        }

        // POST: IssuesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Issues collection)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Student = _students.View();
                ViewBag.Books = _books.View();
                return View(collection);
            }

            try
            {
                _issues.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An error occurred while editing the issue.");
                ViewBag.Student = _students.View();
                ViewBag.Books = _books.View();
                return View(collection);
            }
        }

        // GET: IssuesController/Delete/5
        public IActionResult Delete(int id)
        {
            var dataIssues = _issues.Find(id);
            if (dataIssues == null)
                return NotFound();

            dataIssues.Student = _students.Find(dataIssues.StudentId);
            dataIssues.Books = _books.Find(dataIssues.BooksId);
            return View(dataIssues);
        }

        // POST: IssuesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var dataIssues = _issues.Find(id);
            if (dataIssues == null)
                return NotFound();

            try
            {
                _issues.Delete(id, null);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An error occurred while deleting the issue.");
                dataIssues.Student = _students.Find(dataIssues.StudentId);
                dataIssues.Books = _books.Find(dataIssues.BooksId);
                return View("Delete", dataIssues);
            }
        }
    }
}