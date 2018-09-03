namespace CookingBoox.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using CookingBook.Database.Models;
    using CookingBook.Database.Repositories;
    using CookingBoox.WebApi.Models;
    using CookingBoox.WebApi.Models.Recipe;
    using Microsoft.AspNet.Identity;

    public class RecipesController : ApiController
    {
        private readonly IRepository<Recipe> recipeRepository;

        public RecipesController(IRepository<Recipe> recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        public IEnumerable<RecipeListItemBindingModel> Get()
        {
            return this.recipeRepository.All().OrderByDescending(x => x.AddedOn).Select(x =>
                new RecipeListItemBindingModel
                {
                    Author = x.Author.UserName,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Votes = x.Votes,
                    Id = x.Id,
                    AmountOfTime = x.AmountOfTime,
                    Servings = x.Servings
                }).Take(10);
        }

        public async Task<RecipeDetailBindingModel> Get(long id)
        {
            var recipe = await this.recipeRepository.FirstOrDefaultAsync(x => x.Id == id);
            var result = new RecipeDetailBindingModel
            {
                Id = recipe.Id,
                AmountOfTime = recipe.AmountOfTime,
                Author = recipe.Author.UserName,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                Name = recipe.Name,
                RecipeIngredientDetails = recipe.RecipeIngredientDetails.Select(ri => new RecipeIngredientBindingModel
                {
                    Id = ri.Id,
                    IngredientName = ri.IngredientName,
                    QuantityDescription = ri.QuantityDescription
                }),
                Votes = recipe.Votes,
                Servings = recipe.Servings,
                Steps = recipe.Steps
            };

            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<RecipeListItemBindingModel>> Search(string searchTerm)
        {
            var recipes = await this.recipeRepository.All()
                .Where(x => x.Name.Contains(searchTerm) || x.Author.UserName.Contains(searchTerm)).ToListAsync();
            return recipes.Select(x => new RecipeListItemBindingModel
            {
                Author = x.Author.UserName,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Votes = x.Votes,
                Id = x.Id
            });
        }

        [Authorize]
        public async Task<IHttpActionResult> Post(RecipeCreateBindingModel recipe)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var recipeEntity = new Recipe
            {
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                AmountOfTime = TimeSpan.Parse(recipe.AmountOfTime),
                Servings = recipe.Servings,
                Name = recipe.Name,
                Steps = recipe.Steps,
                Votes = recipe.Votes,
                RecipeIngredientDetails = recipe.RecipeIngredientDetails.Select(x => new RecipeIngredientDetail
                {
                    IngredientName = x.IngredientName,
                    QuantityDescription = x.QuantityDescription
                }).ToList(),
                AuthorId = Thread.CurrentPrincipal.Identity.GetUserId(),
                AddedOn = DateTime.Now
            };

            this.recipeRepository.Create(recipeEntity);
            await this.recipeRepository.SaveChangesAsync();
            return this.Ok();
        }

        [Authorize]
        public async Task<IHttpActionResult> Put(int id)
        {
            var recipe = await this.recipeRepository.FirstOrDefaultAsync(x => x.Id == id);
            recipe.Votes++;
            this.recipeRepository.Update(recipe);
            await this.recipeRepository.SaveChangesAsync();
            return this.Ok();
        }
    }
}
