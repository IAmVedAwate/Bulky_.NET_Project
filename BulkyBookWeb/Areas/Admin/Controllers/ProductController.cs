using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork db, IWebHostEnvironment webHost)
        {
            _unitRepo = db;
            _webHostEnvironment = webHost;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitRepo.Product.GetAll(includeProperties: "Category").ToList();
            return View(objProductList);
        }
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new() {
            CategoryList = _unitRepo.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
            }),
                Product = new Product()
            };
            if (id == 0 || id == null)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = _unitRepo.Product.Get(u => u.Id == id);
                return View(productVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {
            if (file == null)
            {
                ModelState.AddModelError("file", "File is Not Selected!");
            }
            if (ModelState.IsValid)
            {

                string productPath = Path.Combine(_webHostEnvironment.WebRootPath, @"Images\Product\");
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                if(!string.IsNullOrEmpty(obj.Product.ImageUrl)) {
                    // Delete Image First
                    var imgPath = obj.Product.ImageUrl.TrimStart('\\');
                    var oldPath = Path.Combine(_webHostEnvironment.WebRootPath, imgPath);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }

                using (var FileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(FileStream);
                }

                obj.Product.ImageUrl = @"\Images\Product\"+fileName;
                if (obj.Product.Id == 0)
                {
                    _unitRepo.Product.Add(obj.Product);
                    TempData["success"] = "Created Successfully!";
                }
                else
                {
                    _unitRepo.Product.Update(obj.Product);
                    TempData["success"] = "Updated Successfully!";
                }
                _unitRepo.Save();

                return RedirectToAction("Index");
            }
            else
            {
                obj.CategoryList = _unitRepo.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                TempData["error"] = "You Missed something!";
                return View(obj);
            }
        }
        public IActionResult Delete(int? id)
        {
            ProductVM productVM = new()
            {
                CategoryList = _unitRepo.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            productVM.Product = _unitRepo.Product.Get(u => u.Id == id);
            return View(productVM);
        }
    
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _unitRepo.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(obj.ImageUrl))
            {
                // Delete Image First
                var imgPath = obj.ImageUrl.TrimStart('\\');
                var oldPath = Path.Combine(_webHostEnvironment.WebRootPath, imgPath);
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
            }
            _unitRepo.Product.Remove(obj);
            _unitRepo.Save();
            TempData["error"] = "Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}
