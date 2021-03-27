namespace MoiteRecepti2.Web.Controllers
{
    using System.Diagnostics;

    using MoiteRecepti2.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using MoiteRecepti2.Web.ViewModels.Home;
    using MoiteRecepti2.Data;
    using System.Linq;
    using MoiteRecepti2.Data.Common.Repositories;
    using MoiteRecepti2.Data.Models;
    using MoiteRecepti2.Services.Data;
    using AutoMapper;

    public class HomeController : BaseController
    {
        private readonly IGetCountsService countsServise;

        public HomeController(
                IGetCountsService countsServise)
        {
            this.countsServise = countsServise;
        }

        public IActionResult Index()
        {
            var counts = this.countsServise.GetCounts();

            //var viewModel = this.mapper.Map<IndexViewModel>(counts);
            var viewModel = new IndexViewModel
            {
                CategoriesCount = counts.CategoriesCount,
                ImagesCount = counts.ImagesCount,
                IngredientsCount = counts.IngredientsCount,
                RecipesCount = counts.RecipesCount,
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
