using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RecipeBox.Models
{
  public class RecipeBoxContext : DbContext
  {
    public virtual DbSet<Category> Categories { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<CategoryIngredientRecipe> CategoryIngredientRecipe { get; set; }

    public ToDoListContext(DbContextOptions options) : base(options) { }
  }
}


/*
var entryPoint = (from ep in dbContext.tbl_EntryPoint
                 join e in dbContext.tbl_Entry on ep.EID equals e.EID
                 join t in dbContext.tbl_Title on e.TID equals t.TID
                 where e.OwnerID == user.UID
                 select new {
                     UID = e.OwnerID,
                     TID = e.TID,
                     Title = t.Title,
                     EID = e.EID
                 }).Take(10);

entities.X
.Join(entities.Y, t1 => t1.ID, t2 => t2.ID1, (t1, t2) => new { X = t1, Y = t2 })
.Join(entities.Z.Where(p => p.param == 1), t2 => t2.Y.ID, t3 => t3.ID2, (t, t3) => new { X = t.X, Z = t3 })
.Select(u => u.X)
.Distinct();
*/