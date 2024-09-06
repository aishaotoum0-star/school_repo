using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystems.Models;
using SchoolSystems.Models.Repositories;

namespace SchoolSystems.Controllers
{
    public class LoginController : Controller
    {
        private readonly IRepository<Login> login;
        private readonly IRepository<User> user;
        private readonly IRepository<Roles> roles;

        public LoginController(IRepository<Login> _Login,IRepository<User> _User,IRepository<Roles> _Roles)
        {
            login = _Login;
            user = _User;
            roles = _Roles;
        }
        // GET: LoginController
        public ActionResult Index()
        {
            var loginData = login.View();
            foreach (var item in loginData)
            {
                item.Roles = roles.Find(item.RoleId);
                item.User = user.Find(item.UserId);
            }
            return View(loginData);
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            var loginData = login.Find(id);
            loginData.Roles = roles.Find(loginData.RoleId);
            loginData.User = user.Find(loginData.UserId);
            return View(loginData);
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Login collection)
        {
            try
            {
                login.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            var loginData = login.Find(id);
            loginData.Roles = roles.Find(loginData.RoleId);
            loginData.User = user.Find(loginData.UserId);
            return View(loginData);
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Login collection)
        {
            try
            {
                login.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            var loginData = login.Find(id);
            loginData.Roles = roles.Find(loginData.RoleId);
            loginData.User = user.Find(loginData.UserId);
            return View(loginData);
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Login collection)
        {
            try
            {
                login.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
