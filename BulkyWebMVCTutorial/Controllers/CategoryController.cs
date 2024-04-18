using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWebMVCTutorial.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(ILogger<CategoryController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.CategoryRepository.GetAll().ToList();
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
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category created succesfully";
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

            Category? categoryFromDb = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
            // Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            // Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id == id).FirstOrDefault();
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Update(obj); // based on the ID of obj, it will auto update the corresponding data in db
                _unitOfWork.Save();
                TempData["success"] = "Category updated succesfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
            // Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            // Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id == id).FirstOrDefault();
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.CategoryRepository.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted succesfully";
            return RedirectToAction("Index");
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}