namespace MoiteRecepti2.Services.Data
{
    using System.Linq;

    using MoiteRecepti2.Data.Common.Repositories;
    using MoiteRecepti2.Data.Models;
    using MoiteRecepti2.Services.Data.DTOs;
    using MoiteRecepti2.Web.ViewModels.Home;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IRepository<Image> imageRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;
        private readonly IDeletableEntityRepository<Recipe> recipiesRepository;

        public GetCountsService(
            IDeletableEntityRepository<Category> categoriesRepository,
            IRepository<Image> imageRepository,
            IDeletableEntityRepository<Ingredient> ingredientRepository,
            IDeletableEntityRepository<Recipe> recipiesRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.imageRepository = imageRepository;
            this.ingredientRepository = ingredientRepository;
            this.recipiesRepository = recipiesRepository;
        }

        public CountsDTO GetCounts()
        {
            var data = new CountsDTO
            {
                RecipesCount = this.recipiesRepository.All().Count(),
                CategoriesCount = this.categoriesRepository.All().Count(),
                ImagesCount = this.imageRepository.All().Count(),
                IngredientsCount = this.ingredientRepository.All().Count(),
            };

            return data;
        }
    }
}
