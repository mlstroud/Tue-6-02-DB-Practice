using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class CategoryIngredientRecipe
  {
    
    public int CategoryIngredientRecipeId {get;set;}
    public int? CategoryId {get;set;}
    public virtual Category Category {get; set;}
    public int? IngredientId {get;set;}
    public virtual Ingredient Ingredient {get; set;}
    public int RecipeId {get; set;}
    public virtual Recipe Recipe {get; set;}
  }
}