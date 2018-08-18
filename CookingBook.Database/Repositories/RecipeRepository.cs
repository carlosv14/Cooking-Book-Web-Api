namespace CookingBook.Database.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CookingBook.Database.Contexts;
    using CookingBook.Database.Models;

    public class RecipeRepository : CookingBookBaseRepository<Recipe>
    {
        public RecipeRepository(CookingBookContext context)
            : base(context)
        {
        }

        public override IQueryable<Recipe> All()
        {
            return this.Context.Recipes;
        }
    }
}
