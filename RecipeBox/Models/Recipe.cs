using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Recipe
  {
    public int RecipeId {get;set;}
    public string Description {get;set;}
    public float Rating {get;set;}
    public string Instructions {get; set;}

    public Icollection<CategoryIngredientRecipe> Join {get; set;}

    public Recipe()
    {
      this.Join = new HashSet<CategoryIngredientRecipe>();
    }
  }
}