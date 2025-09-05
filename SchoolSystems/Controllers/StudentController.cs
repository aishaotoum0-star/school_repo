using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystems.Models;
using SchoolSystems.Models.Repositories;
using System.IO;
using System;
using SchoolSystems.ViewModels;

namespace SchoolSystems.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRepository<Student> student;
        private readonly IWebHostEnvironment webHosting;

        public StudentController(IRepository<Student> _Student,IWebHostEnvironment _WebHosting)
        {
            student = _Student;
            webHosting = _WebHosting;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var studentData = student.View();
            return View(studentData);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var studentData = student.Find(id);
            return View(studentData);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentVM collection)
        {
            try
            {
                var imgUrl = CreateImages(collection.File, "Student");
                var viewData = new Student
                {
                    StudentEmail = collection.StudentEmail,
                    StudentName = collection.StudentName,
                    StudentDob = collection.StudentDob,
                    StudentPhone = collection.StudentPhone,
                    StudentImageURL = imgUrl,
                };
                student.Add(viewData);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var studentData = student.Find(id);
            var viewData = new StudentVM
            {
                StudentId = studentData.StudentId,
                StudentEmail = studentData.StudentEmail,
                StudentName = studentData.StudentName,
                StudentDob = studentData.StudentDob,
                StudentPhone = studentData.StudentPhone,
                StudentImageURL = studentData.StudentImageURL,
            };
            return View(viewData);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentVM collection)
        {
            try
            {
                var imgUrl = CreateImages(collection.File, "Student");
                var viewData = new Student
                {
                    StudentId = collection.StudentId,
                    StudentEmail= collection.StudentEmail,
                    StudentName= collection.StudentName,
                    StudentDob= collection.StudentDob,
                    StudentPhone= collection.StudentPhone,
                    StudentImageURL = imgUrl,
                };
                student.Update(id, viewData);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var studentData = student.Find(id);
            return View(studentData);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Student collection)
        {
            try
            {
                student.Delete(id,collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public string CreateImages(IFormFile formFile, string filePaths)
        {
            try
            {
                string ImagesURL = "";
                if (formFile != null)
                {

                    string pathURL = Path.Combine(webHosting.WebRootPath + "/Images/" + filePaths);
                    FileInfo fileInfo = new FileInfo(formFile.FileName);
                    ImagesURL = "Images_" + Guid.NewGuid() + fileInfo.Extension;
                    string fullPath = Path.Combine(pathURL, ImagesURL);
                    formFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                return ImagesURL;
            }
            catch (Exception)
            {

            }
            return "";
        }
    }
}
