namespace MoiteRecepti2.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MoiteRecepti2.Services.Data;
    using MoiteRecepti2.Web.ViewModels.Recipes;

    public class RecipesController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IRecipesService recipeService;

        public RecipesController(ICategoriesService categoriesService, IRecipesService recipeService)
        {
            this.categoriesService = categoriesService;
            this.recipeService = recipeService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateRecipeInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKVP();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesService.GetAllAsKVP();
                return this.View(input);
            }

            await this.recipeService.CreateAsync(input);

            return this.Redirect("/");
        }
    }
}
