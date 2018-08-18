namespace CookingBook.Database.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Recipe
    {
        public Recipe()
        {
            this.RecipeIngredientDetails = new HashSet<RecipeIngredientDetail>();
        }

        [Key]
        public long Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public decimal Servings { get; set; }

        public TimeSpan AmountOfTime { get; set; }

        [ForeignKey(nameof(Author))]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<RecipeIngredientDetail> RecipeIngredientDetails { get; set; }

        [StringLength(5000)]
        public string Steps { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        public int Votes { get; set; }

        public DateTime AddedOn { get; set; }
    }
}
