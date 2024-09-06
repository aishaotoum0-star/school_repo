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
    public class UserController : Controller
    {
        private readonly IRepository<User> user;
        private readonly IHostingEnvironment webHosting;

        public UserController(IRepository<User> _User,IHostingEnvironment _WebHosting)
        {
            user = _User;
            webHosting = _WebHosting;
        }
        // GET: UserController
        public ActionResult Index()
        {
            var userData = user.View();
            return View(userData);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            var userData = user.Find(id);
            return View(userData);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserVM collection)
        {
            try
            {
                var imgUrl = CreateImages(collection.File, "User");
                var viewData = new User
                {
                    UserName = collection.UserName,
                    UserEmail = collection.UserEmail,
                    UserPhone = collection.UserPhone,
                    UserImageURL = imgUrl,
                };
                user.Add(viewData);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var userData = user.Find(id);
            var viewData = new UserVM
            {
                UserId = id,
                UserName = userData.UserName,
                UserEmail = userData.UserEmail,
                UserPhone = userData.UserPhone,
                UserImageURL = userData.UserImageURL,
            };
            return View(viewData);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserVM collection)
        {
            try
            {
                var imgUrl = CreateImages(collection.File, "User");
                var viewData = new User
                {
                    UserId = id,
                    UserName = collection.UserName,
                    UserEmail=collection.UserEmail,
                    UserPhone = collection.UserPhone,
                    UserImageURL = imgUrl,
                };
                user.Update(id, viewData);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var userData = user.Find(id);
            return View(userData);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User collection)
        {
            try
            {
                user.Delete(id,collection);
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
            catch (Exception ex)
            {

            }
            return "";
        }
    }
}
