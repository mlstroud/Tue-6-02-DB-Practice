using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Controllers
{
  public class RecipeBoxController : Controller
  {
    private readonly RecipeBoxContext _db;
    public RecipeBoxController(RecipeBoxContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Recipe> allRecipes = _db.Recipes.ToList();
      return View("Index", allRecipes);
    }

    public ActionResult Create()
    {
      return View("Create");
    }

    [HttpPost]
    public ActionResult Create(Recipe recipe)
    {
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      return View("Details");
    }

    public ActionResult Edit(int id)
    {
      return View("Edit");
    }

    [HttpPost]
    public ActionResult Edit(Recipe recipe)
    {
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      return View("Delete");
    }
    
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      return RedirectToAction("Index");
    }
  }
}