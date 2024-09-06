using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystems.Models;
using SchoolSystems.Models.Repositories;

namespace SchoolSystems.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRepository<Roles> roles;

        public RolesController(IRepository<Roles> _Roles)
        {
            roles = _Roles;
        }
        // GET: RolesController
        public ActionResult Index()
        {
            var rolData = roles.View();
            return View(rolData);
        }

        // GET: RolesController/Details/5
        public ActionResult Details(int id)
        {
            var rolData = roles.Find(id);
            return View(rolData);
        }

        // GET: RolesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Roles collection)
        {
            try
            {
                roles.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolesController/Edit/5
        public ActionResult Edit(int id)
        {
            var rolData = roles.Find(id);
            return View(rolData);
        }

        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Roles collection)
        {
            try
            {
                roles.Update(id,collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolesController/Delete/5
        public ActionResult Delete(int id)
        {
            var rolData = roles.Find(id);
            return View(rolData);
        }

        // POST: RolesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Roles collection)
        {
            try
            {
                roles.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
