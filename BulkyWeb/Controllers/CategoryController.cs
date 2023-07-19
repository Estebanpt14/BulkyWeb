using Bulky.DataAccess;
using Bulky.Models;
using Bulky.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
  public class CategoryController : Controller
  {
    private readonly ApplicationDbContext _db;
    public CategoryController(ApplicationDbContext db)
    {
      _db = db;
    }
    public IActionResult Index()
    {
      var objCategoryList = _db.Categories.ToList();
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
      Category? category = _db.Categories.Where(u => u.CategoryId == id).FirstOrDefault();
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
        _db.Categories.Add(obj);
        _db.SaveChanges();
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
      Category? category = _db.Categories.Where(u => u.CategoryId == id).FirstOrDefault();
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
        _db.Categories.Update(obj);
        _db.SaveChanges();
        TempData["success"] = "Category Updated successfully";
        return RedirectToAction("Index");
      }
      return View();
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteD(int? id)
    {
      Category? obj = _db.Categories.Where(u => u.CategoryId == id).FirstOrDefault();
      if (obj == null)
      {
        return NotFound();
      }
      _db.Categories.Remove(obj);
      _db.SaveChanges();
      TempData["success"] = "Category Removed successfully";
      return RedirectToAction("Index");
    }

  }
}