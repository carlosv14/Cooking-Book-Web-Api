namespace CookingBook.Database.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RecipeIngredientDetail
    {
        [Key]
        public long Id { get; set; }

        [StringLength(30)]
        [Required]
        public string IngredientName { get; set; }

        [StringLength(20)]
        [Required]
        public string QuantityDescription { get; set; }

        [ForeignKey(nameof(Recipe))]
        public long RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
