using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitRepo;
        public CategoryController(IUnitOfWork db)
        {
            _unitRepo = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitRepo.Category.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("", "Name and Order Can't be Same");
            }
            if (ModelState.IsValid)
            {
                _unitRepo.Category.Add(obj);
                _unitRepo.Save();
                TempData["success"] = "Created Successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? obj = _unitRepo.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("", "Name and Order Can't be Same");
            }
            if (ModelState.IsValid)
            {
                _unitRepo.Category.Update(obj);
                _unitRepo.Save();
                TempData["success"] = "Updated Successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            Category? obj = _unitRepo.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _unitRepo.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitRepo.Category.Remove(obj);
            _unitRepo.Save();
            TempData["error"] = "Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}
