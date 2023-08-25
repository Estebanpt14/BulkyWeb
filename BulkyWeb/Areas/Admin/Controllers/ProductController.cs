using Bulky.DataAccess;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class ProductController : Controller
  {
    private readonly IProductRepository _productRepository;
    public ProductController(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }
    public IActionResult Index()
    {
      var objProductList = _productRepository.GetAll().ToList();
      return View(objProductList);
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
      Product? product = _productRepository.GetFirstOrDefault(u => u.ProductId == id);
      if (product == null)
      {
        return NotFound();
      }
      return View(product);
    }

    [HttpPost]
    public IActionResult Create(Product obj)
    {
      if (ModelState.IsValid)
      {
        _productRepository.Add(obj);
        _productRepository.Save();
        TempData["success"] = "Product Created successfully";
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
      Product? product = _productRepository.GetFirstOrDefault(u => u.ProductId == id);
      if (product == null)
      {
        return NotFound();
      }
      return View(product);
    }

    [HttpPost]
    public IActionResult Edit(Product obj)
    {
      if (ModelState.IsValid)
      {
        _productRepository.Update(obj);
        _productRepository.Save();
        TempData["success"] = "Product Updated successfully";
        return RedirectToAction("Index");
      }
      return View();
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteD(int? id)
    {
      Product? obj = _productRepository.GetFirstOrDefault(u => u.ProductId == id);
      if (obj == null)
      {
        return NotFound();
      }
      _productRepository.Remove(obj);
      _productRepository.Save();
      TempData["success"] = "Product Removed successfully";
      return RedirectToAction("Index");
    }

  }
}