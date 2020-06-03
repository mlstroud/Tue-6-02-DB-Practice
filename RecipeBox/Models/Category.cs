using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Category
  {
    public int CategoryId {get; set;}
    public string Name {get; set;}
    public virtual ApplicationUser User {get; set;}

    public ICollection<CategoryIngredientRecipe> Join {get; set;}

    public Category()
    {
      this.Join = new HashSet<CategoryIngredientRecipe>();
    }
  }
}