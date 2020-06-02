using system.collections.generic;

namespace RecipeBox.Models
{
  public class Category
  {
    public int CategoryId {get; set;}
    public string Name {get; set;}

    public Icollection<CategoryIngredientRecipe> Join {get; set;}

    public Category()
    {
      this.Join = new HashSet<CategoryIngredientRecipe>();
    }
  }
}