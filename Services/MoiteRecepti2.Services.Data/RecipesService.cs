namespace MoiteRecepti2.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MoiteRecepti2.Data.Common.Repositories;
    using MoiteRecepti2.Data.Models;
    using MoiteRecepti2.Web.ViewModels.Recipes;

    public class RecipesService : IRecipesService
    {
        private readonly IDeletableEntityRepository<Recipe> recipeRepo;
        private readonly IDeletableEntityRepository<Ingredient> ingredientsRepo;

        public RecipesService(
            IDeletableEntityRepository<Recipe> recipeRepo,
            IDeletableEntityRepository<Ingredient> ingredientsRepo)
        {
            this.recipeRepo = recipeRepo;
            this.ingredientsRepo = ingredientsRepo;
        }

        public async Task CreateAsync(CreateRecipeInputModel input)
        {
            var recipe = new Recipe
            {
                CategoryId = input.CategoryId,
                PreparationTime = TimeSpan.FromMinutes(input.PreparationTime),
                CookingTime = TimeSpan.FromMinutes(input.CookingTime),
                Name = input.Name,
                PortionsCount = input.PortionsCount,
                Instructions = input.Instructions,
            };

            foreach (var item in input.Ingredients)
            {
                var ingredient = this.ingredientsRepo.All().FirstOrDefault(x => x.Name == item.IngredientName);

                if (ingredient == null)
                {
                    ingredient = new Ingredient { Name = item.IngredientName };
                }

                recipe.Ingredients.Add(new RecipeIngredient
                {
                    Ingredient = ingredient,
                    Quantity = item.Quantity,
                });
            }

            await this.recipeRepo.AddAsync(recipe);
            await this.recipeRepo.SaveChangesAsync();
        }
    }
}
