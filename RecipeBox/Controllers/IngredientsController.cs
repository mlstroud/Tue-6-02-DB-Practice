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
  public class IngredientsController : Controller
  {
    private readonly RecipeBoxContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public IngredientsController(UserManager<ApplicationUser> userManager, RecipeBoxContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index() 
    {
      List<Ingredient> allIngredients = _db.Ingredients.ToList();
      return View("Index", allIngredients);
    }

    public ActionResult Create()
    {
      return View("Create");
    }

    [HttpPost]
    public ActionResult Create(Ingredient Ingredient)
    {
      _db.Ingredients.Add(Ingredient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Ingredient thisIngredient = _db.Ingredients.FirstOrDefault(Ingredient => Ingredient.IngredientId == id);
      return View("Details", thisIngredient);
    }

    public ActionResult Edit(int id)
    {
      return View("Edit");
    }

    [HttpPost]
    public ActionResult Edit(Ingredient Ingredient)
    {
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Ingredient thisIngredient = _db.Ingredients.FirstOrDefault(Ingredient => Ingredient.IngredientId == id);
      return View("Delete", thisIngredient);
    }
    
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Ingredient thisIngredient = _db.Ingredients.FirstOrDefault(Ingredient => Ingredient.IngredientId == id);
      _db.Ingredients.Remove(thisIngredient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}