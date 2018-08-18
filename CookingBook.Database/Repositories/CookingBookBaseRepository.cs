namespace CookingBook.Database.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CookingBook.Database.Contexts;

    public abstract class CookingBookBaseRepository<TEntity> : BaseRepository<TEntity, CookingBookContext>
        where TEntity : class
    {
        protected CookingBookBaseRepository(CookingBookContext context)
            : base(context)
        {
            this.Context = context;
        }
    }
}
