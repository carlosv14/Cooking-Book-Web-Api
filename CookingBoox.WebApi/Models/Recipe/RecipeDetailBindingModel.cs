namespace CookingBoox.WebApi.Models.Recipe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class RecipeDetailBindingModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Servings { get; set; }

        public TimeSpan AmountOfTime { get; set; }

        public string Author { get; set; }

        public IEnumerable<RecipeIngredientBindingModel> RecipeIngredientDetails { get; set; }

        public string Steps { get; set; }

        public string ImageUrl { get; set; }

        public int Votes { get; set; }
    }
}