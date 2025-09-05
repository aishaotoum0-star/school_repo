using Microsoft.AspNetCore.Mvc;
using SchoolSystems.Models;
using SchoolSystems.Models.Repositories;
using System;

namespace SchoolSystems.Controllers
{
    public class BranchController : Controller
    {
        private readonly IRepository<Branch> _branchRepository;

        public BranchController(IRepository<Branch> branchRepository)
        {
            _branchRepository = branchRepository;
        }

        // GET: BranchController
        public IActionResult Index()
        {
            var branchData = _branchRepository.View();
            return View(branchData);
        }

        // GET: BranchController/Details/5
        public IActionResult Details(int id)
        {
            var branchData = _branchRepository.Find(id);
            if (branchData == null)
                return NotFound();
            return View(branchData);
        }

        // GET: BranchController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BranchController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Branch branch)
        {
            if (!ModelState.IsValid)
                return View(branch);

            try
            {
                _branchRepository.Add(branch);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An error occurred while creating the branch.");
                return View(branch);
            }
        }

        // GET: BranchController/Edit/5
        public IActionResult Edit(int id)
        {
            var branchData = _branchRepository.Find(id);
            if (branchData == null)
                return NotFound();
            return View(branchData);
        }

        // POST: BranchController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Branch branch)
        {
            if (!ModelState.IsValid)
                return View(branch);

            try
            {
                _branchRepository.Update(id, branch);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An error occurred while editing the branch.");
                return View(branch);
            }
        }

        // GET: BranchController/Delete/5
        public IActionResult Delete(int id)
        {
            var branchData = _branchRepository.Find(id);
            if (branchData == null)
                return NotFound();
            return View(branchData);
        }

        // POST: BranchController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _branchRepository.Delete(id, null);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An error occurred while deleting the branch.");
                return RedirectToAction(nameof(Delete), new { id });
            }
        }
    }
}