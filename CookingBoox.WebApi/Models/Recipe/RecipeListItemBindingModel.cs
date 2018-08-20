namespace CookingBoox.WebApi.Models.Recipe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class RecipeListItemBindingModel
    {
        public long Id { get; set; }

        public string Author { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int Votes { get; set; }

        public decimal Servings { get; set; }

        public TimeSpan AmountOfTime { get; set; }
    }
}