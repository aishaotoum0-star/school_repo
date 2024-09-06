using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystems.Models;
using SchoolSystems.Models.Repositories;

namespace SchoolSystems.Controllers
{
    public class PermissionController : Controller
    {
        private readonly IRepository<Permission> permission;
        private readonly IRepository<Roles> roles;

        public PermissionController(IRepository<Permission> _Permission,IRepository<Roles> _Roles)
        {
            permission = _Permission;
            roles = _Roles;
        }
        // GET: PermissionController
        public ActionResult Index()
        {
            var permissionData = permission.View();
            foreach (var item in permissionData)
            {
                item.Roles = roles.Find(item.RolesId);
            }
            return View(permissionData);
        }

        // GET: PermissionController/Details/5
        public ActionResult Details(int id)
        {
            var permissionData = permission.Find(id);
            permissionData.Roles = roles.Find(permissionData.RolesId);
            return View(permissionData);
        }

        // GET: PermissionController/Create
        public ActionResult Create()
        {
            var lstRoles = roles.View();
            ViewBag.Roles = lstRoles;
            return View();
        }

        // POST: PermissionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Permission collection)
        {
            try
            {
                permission.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PermissionController/Edit/5
        public ActionResult Edit(int id)
        {
            var permissionData = permission.Find(id);
            permissionData.Roles = roles.Find(permissionData.RolesId);


            var lstRoles = roles.View();
            ViewBag.Roles = lstRoles;


            return View(permissionData);
        }

        // POST: PermissionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Permission collection)
        {
            try
            {
                permission.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PermissionController/Delete/5
        public ActionResult Delete(int id)
        {
            var permissionData = permission.Find(id);
            permissionData.Roles = roles.Find(permissionData.RolesId);
            return View(permissionData);
        }

        // POST: PermissionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Permission collection)
        {
            try
            {
                permission.Delete(id,collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
