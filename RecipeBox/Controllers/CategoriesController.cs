using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace RecipeBox.Controllers
{
  [Authorize]
  public class CategoriesController : Controller
  {
    private readonly RecipeBoxContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    
    public CategoriesController(UserManager<ApplicationUser> userManager, RecipeBoxContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      List<Category> allCategories = _db.Categories.ToList();
      return View("Index", allCategories);
    }

    public ActionResult Create()
    {
      return View("Create");
    }

    [HttpPost]
    public ActionResult Create(Category Category)
    {
      _db.Categories.Add(Category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Category thisCategory = _db.Categories.FirstOrDefault(Category => Category.CategoryId == id);
      return View("Details", thisCategory);
    }

    public ActionResult Edit(int id)
    {
      return View("Edit");
    }

    [HttpPost]
    public ActionResult Edit(Category Category)
    {
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Category thisCategory = _db.Categories.FirstOrDefault(Category => Category.CategoryId == id);
      return View("Delete", thisCategory);
    }
    
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Category thisCategory = _db.Categories.FirstOrDefault(Category => Category.CategoryId == id);
      _db.Categories.Remove(thisCategory);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}