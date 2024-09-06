using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystems.Models;
using SchoolSystems.Models.Repositories;

namespace SchoolSystems.Controllers
{
    public class BranchController : Controller
    {
        private readonly IRepository<Branch> Branch;

        public BranchController(IRepository<Branch> _Branch)
        {
            Branch = _Branch;
        }
        // GET: BranchController
        public ActionResult Index()
        {
            var branchData = Branch.View();
            return View(branchData);
        }

        // GET: BranchController/Details/5
        public ActionResult Details(int id)
        {
            var branchData = Branch.Find(id);
            return View(branchData);
        }

        // GET: BranchController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BranchController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Branch collection)
        {
            try
            {
                Branch.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BranchController/Edit/5
        public ActionResult Edit(int id)
        {
            var branchData = Branch.Find(id);
            return View(branchData);
        }

        // POST: BranchController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Branch collection)
        {
            try
            {
                Branch.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BranchController/Delete/5
        public ActionResult Delete(int id)
        {
            var branchData = Branch.Find(id);
            return View(branchData);
        }

        // POST: BranchController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Branch collection)
        {
            try
            {
                Branch.Delete(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
