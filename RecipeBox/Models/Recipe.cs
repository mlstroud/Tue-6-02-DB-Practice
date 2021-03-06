using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Recipe
  {
    public int RecipeId {get;set;}
    public string Description {get;set;}
    public float Rating {get;set;}
    public string Instructions {get; set;}
    public virtual ApplicationUser User {get; set;}

    public ICollection<CategoryIngredientRecipe> Join {get; set;}

    public Recipe()
    {
      this.Join = new HashSet<CategoryIngredientRecipe>();
    }
  }
}