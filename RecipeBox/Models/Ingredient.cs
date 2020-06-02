using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Ingredient
  {
    public int IngredientId {get; set;}
    public string Name {get; set;}
    public ICollection<CategoryIngredientRecipe> Join {get; set;}

    public Ingredient()
    {
      this.Join = new HashSet<CategoryIngredientRecipe>();
    }
  }
}