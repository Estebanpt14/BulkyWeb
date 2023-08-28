using BulkyWeb.Repository.IRepository;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class CategoryController : Controller
  {
    private readonly ICategoryRepository _categoryRepository;
    public CategoryController(ICategoryRepository categoryRepository)
    {
      _categoryRepository = categoryRepository;
    }
    public IActionResult Index()
    {
      var objCategoryList = _categoryRepository.GetAll().ToList();
      return View(objCategoryList);
    }

    public IActionResult Create()
    {
      return View();
    }

    public IActionResult Delete(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }
      Category? category = _categoryRepository.GetFirstOrDefault(u => u.CategoryId == id);
      if (category == null)
      {
        return NotFound();
      }
      return View(category);
    }

    [HttpPost]
    public IActionResult Create(Category obj)
    {
      if (ModelState.IsValid)
      {
        _categoryRepository.Add(obj);
        _categoryRepository.Save();
        TempData["success"] = "Category Created successfully";
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
      Category? category = _categoryRepository.GetFirstOrDefault(u => u.CategoryId == id);
      if (category == null)
      {
        return NotFound();
      }
      return View(category);
    }

    [HttpPost]
    public IActionResult Edit(Category obj)
    {
      if (ModelState.IsValid)
      {
        _categoryRepository.Update(obj);
        _categoryRepository.Save();
        TempData["success"] = "Category Updated successfully";
        return RedirectToAction("Index");
      }
      return View();
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteD(int? id)
    {
      Category? obj = _categoryRepository.GetFirstOrDefault(u => u.CategoryId == id);
      if (obj == null)
      {
        return NotFound();
      }
      _categoryRepository.Remove(obj);
      _categoryRepository.Save();
      TempData["success"] = "Category Removed successfully";
      return RedirectToAction("Index");
    }

  }
}