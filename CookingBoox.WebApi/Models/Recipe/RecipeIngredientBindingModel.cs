namespace CookingBoox.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class RecipeIngredientBindingModel
    {
        public long Id { get; set; }

        [StringLength(30)]
        [Required]
        public string IngredientName { get; set; }

        [StringLength(20)]
        [Required]
        public string QuantityDescription { get; set; }
    }
}