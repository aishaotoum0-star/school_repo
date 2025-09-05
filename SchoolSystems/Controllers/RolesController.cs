using Microsoft.AspNetCore.Mvc;
using SchoolSystems.Models;
using SchoolSystems.Models.Repositories;
using SchoolSystems.ViewModels;

namespace SchoolSystems.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRepository<Roles> _roles;

        public RolesController(IRepository<Roles> roles)
        {
            _roles = roles;
        }

        // GET: RolesController
        public IActionResult Index()
        {
            var rolData = _roles.View();
            return View(rolData);
        }

        // GET: RolesController/Details/5
        public IActionResult Details(int id)
        {
            var rolData = _roles.Find(id);
            if (rolData == null)
                return NotFound();
            return View(rolData);
        }

        // GET: RolesController/FullAction
        public IActionResult FullAction(int editId = 0, int deleteId = 0)
        {
            if (deleteId > 0)
            {
                try
                {
                    _roles.Delete(deleteId, null);
                }
                catch
                {
                    // Optionally, add error handling here
                }
            }
            var rolData = _roles.View();
            var newData = new RolesVM
            {
                Roles = (editId != 0 ? _roles.Find(editId) : new Roles()),
                ListRoles = rolData
            };
            return View(newData);
        }

        // POST: RolesController/FullAction
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FullAction(RolesVM collection)
        {
            if (!ModelState.IsValid)
            {
                collection.ListRoles = _roles.View();
                return View(collection);
            }

            try
            {
                var data = new Roles
                {
                    RolesId = collection.Roles.RolesId,
                    RolesIvI = collection.Roles.RolesIvI,
                    RolesName = collection.Roles.RolesName,
                };
                if (collection.Roles.RolesId == 0)
                {
                    _roles.Add(data);
                }
                else
                {
                    _roles.Update(data.RolesId, data);
                }
                return RedirectToAction(nameof(FullAction));
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while saving the role.");
                collection.ListRoles = _roles.View();
                return View(collection);
            }
        }

        // GET: RolesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Roles collection)
        {
            if (!ModelState.IsValid)
                return View(collection);

            try
            {
                _roles.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while creating the role.");
                return View(collection);
            }
        }

        // GET: RolesController/Edit/5
        public IActionResult Edit(int id)
        {
            var rolData = _roles.Find(id);
            if (rolData == null)
                return NotFound();
            return View(rolData);
        }

        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Roles collection)
        {
            if (!ModelState.IsValid)
                return View(collection);

            try
            {
                _roles.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while editing the role.");
                return View(collection);
            }
        }

        // GET: RolesController/Delete/5
        public IActionResult Delete(int id)
        {
            var rolData = _roles.Find(id);
            if (rolData == null)
                return NotFound();
            return View(rolData);
        }

        // POST: RolesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var rolData = _roles.Find(id);
            if (rolData == null)
                return NotFound();

            try
            {
                _roles.Delete(id, null);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while deleting the role.");
                return View("Delete", rolData);
            }
        }
    }
}