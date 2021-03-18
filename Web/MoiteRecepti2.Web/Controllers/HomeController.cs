namespace MoiteRecepti2.Web.Controllers
{
    using System.Diagnostics;

    using MoiteRecepti2.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using MoiteRecepti2.Web.ViewModels.Home;
    using MoiteRecepti2.Data;
    using System.Linq;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                RecipesCount = this.db.REcipes.Count(),
                CategoriesCount = this.db.Categories.Count(),
                ImagesCount = this.db.Images.Count(),
                IngredientsCount = this.db.Ingredients.Count(),
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
