namespace CookingBoox.WebApi.Models.Recipe
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class RecipeCreateBindingModel
    {

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public decimal Servings { get; set; }

        public TimeSpan AmountOfTime { get; set; }

        public IEnumerable<RecipeIngredientBindingModel> RecipeIngredientDetails { get; set; }

        [StringLength(5000)]
        public string Steps { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        public int Votes { get; set; }
    }
}