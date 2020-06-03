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
using System;


namespace RecipeBox.Controllers
{
  public class RecipesController : Controller
  {
    private readonly RecipeBoxContext _db;
    public RecipesController(RecipeBoxContext db)
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
      _db.Recipes.Add(recipe);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Recipe thisRecipe = _db.Recipes
            .Include(recipe => recipe.Join)
              .ThenInclude(join => join.Category)
            .Include(recipe => recipe.Join)
              .ThenInclude(join => join.Ingredient)           
            .FirstOrDefault(Recipe => Recipe.RecipeId == id);
      return View("Details", thisRecipe);
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
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      return View("Delete", thisRecipe);
    }
    
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      _db.Recipes.Remove(thisRecipe);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddCategory(int id)
    {
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      ViewBag.RecipeId = id;
      return View("AddCategory");
    }

    [HttpPost]
    public ActionResult AddCategory(int RecipeId, int CategoryId)
    {
      if (CategoryId != 0)
      {
    
      _db.CategoryIngredientRecipe.Add(new CategoryIngredientRecipe() { CategoryId = CategoryId, RecipeId = RecipeId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult DeleteCategory(int id)
    {
      CategoryIngredientRecipe joinEntry = _db.CategoryIngredientRecipe.FirstOrDefault(entry => entry.CategoryIngredientRecipeId == id);
      _db.CategoryIngredientRecipe.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

     public ActionResult AddIngredient(int id)
    {
      ViewBag.IngredientId = new SelectList(_db.Ingredients, "IngredientId", "Name");
      ViewBag.RecipeId = id;
      return View("AddIngredient");
    }

    [HttpPost]
    public ActionResult AddIngredient(int RecipeId, int IngredientId)
    {
      if (IngredientId != 0)
      {
    
      _db.CategoryIngredientRecipe.Add(new CategoryIngredientRecipe() { IngredientId = IngredientId, RecipeId = RecipeId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult DeleteIngredient(int id)
    {
      CategoryIngredientRecipe joinEntry = _db.CategoryIngredientRecipe.FirstOrDefault(entry => entry.CategoryIngredientRecipeId == id);
      _db.CategoryIngredientRecipe.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

 
  }
}



