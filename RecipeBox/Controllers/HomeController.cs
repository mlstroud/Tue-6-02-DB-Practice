using Microsoft.AspNetCore.Mvc;

namespace RecipeBox.Controllers
{
  public class HomeController: Controllers
  {
    public ActionResult Index()
    {
      return View("Index");
    }
  }
}