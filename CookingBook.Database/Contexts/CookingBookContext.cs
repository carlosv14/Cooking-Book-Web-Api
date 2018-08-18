namespace CookingBook.Database.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CookingBook.Database.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class CookingBookContext : IdentityDbContext<ApplicationUser>
    {
        public CookingBookContext()
            : base("CookingBookConnection")
        {
            this.Database.Log = (s) => Debug.Write(s);
        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeIngredientDetail> RecipeIngredientDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Properties<DateTime>().Configure(t => t.HasPrecision(6));
            modelBuilder.Properties<string>().Configure(t => t.IsUnicode(false));
        }
    }
}
