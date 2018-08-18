using CookingBook.Database.Contexts;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CookingBook.Initializers
{
    public class DropCreateCookingBookIfModelChanges : DropCreateDatabaseIfModelChanges<CookingBookContext>
    {
        protected override void Seed(CookingBookContext context)
        {
            var task = Task.Run(async () => await CookingBookSeed.GenerateTestData(context));
            task.Wait();
        }
    }
}
