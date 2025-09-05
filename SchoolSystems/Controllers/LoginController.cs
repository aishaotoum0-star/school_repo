using Microsoft.AspNetCore.Mvc;
using SchoolSystems.Models;
using SchoolSystems.Models.Repositories;

namespace SchoolSystems.Controllers
{
    public class LoginController : Controller
    {
        private readonly IRepository<Login> _login;
        private readonly IRepository<User> _user;
        private readonly IRepository<Roles> _roles;

        public LoginController(IRepository<Login> login, IRepository<User> user, IRepository<Roles> roles)
        {
            _login = login;
            _user = user;
            _roles = roles;
        }

        // GET: LoginController
        public IActionResult Index()
        {
            var loginData = _login.View();
            foreach (var item in loginData)
            {
                item.Roles = _roles.Find(item.RoleId);
                item.User = _user.Find(item.UserId);
            }
            return View(loginData);
        }

        // GET: LoginController/Details/5
        public IActionResult Details(int id)
        {
            var loginData = _login.Find(id);
            if (loginData == null)
                return NotFound();

            loginData.Roles = _roles.Find(loginData.RoleId);
            loginData.User = _user.Find(loginData.UserId);
            return View(loginData);
        }

        // GET: LoginController/Create
        public IActionResult Create()
        {
            ViewBag.Roles = _roles.View();
            ViewBag.User = _user.View();
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Login collection)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Roles = _roles.View();
                ViewBag.User = _user.View();
                return View(collection);
            }
            try
            {
                _login.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while creating the login.");
                ViewBag.Roles = _roles.View();
                ViewBag.User = _user.View();
                return View(collection);
            }
        }

        // GET: LoginController/Edit/5
        public IActionResult Edit(int id)
        {
            var loginData = _login.Find(id);
            if (loginData == null)
                return NotFound();

            ViewBag.Roles = _roles.View();
            ViewBag.User = _user.View();
            loginData.Roles = _roles.Find(loginData.RoleId);
            loginData.User = _user.Find(loginData.UserId);
            return View(loginData);
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Login collection)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Roles = _roles.View();
                ViewBag.User = _user.View();
                return View(collection);
            }
            try
            {
                _login.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while editing the login.");
                ViewBag.Roles = _roles.View();
                ViewBag.User = _user.View();
                return View(collection);
            }
        }

        // GET: LoginController/Delete/5
        public IActionResult Delete(int id)
        {
            var loginData = _login.Find(id);
            if (loginData == null)
                return NotFound();

            loginData.Roles = _roles.Find(loginData.RoleId);
            loginData.User = _user.Find(loginData.UserId);
            return View(loginData);
        }

        // POST: LoginController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var loginData = _login.Find(id);
            if (loginData == null)
                return NotFound();

            try
            {
                _login.Delete(id, null);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while deleting the login.");
                loginData.Roles = _roles.Find(loginData.RoleId);
                loginData.User = _user.Find(loginData.UserId);
                return View("Delete", loginData);
            }
        }
    }
}