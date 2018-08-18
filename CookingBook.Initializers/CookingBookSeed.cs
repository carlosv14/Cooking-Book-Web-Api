using CookingBook.Database.Contexts;
using CookingBook.Database.Models;
using CookingBook.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingBook.Initializers
{
    public static class CookingBookSeed
    {
        public static async Task GenerateTestData(CookingBookContext cookingBookContext)
        {
            var appUser = new ApplicationUser();
            appUser.UserName = "cvarela";
            appUser.Email = "cvarela1496@gmail.com";
            appUser.PasswordHash = "AGwu0Rve83bj8IDQ6TYxjEguZBtQfOCyOmJZfUAAg/lYiLCQasQPE9yp+pi/cIl5+w==";

            var recipeRepository = new RecipeRepository(cookingBookContext);

            var firstRecipe = new Recipe
            {
                Votes = 0,
                Description = @"Although we can’t lay claim to the “put it in a bag and shake” method used to cook these pork cutlets, we’ll acknowledge that it’s pretty genius. That’s because it makes breading meat about as quick and easy as can be (and yes, it’s so juicy). After it’s covered with breadcrumbs, the pork is fried in a pan ’til golden and served with toasted garlic bread and a crisp salad. If that sounds like a lot, fret not—this meal can be made in as little as 20 minutes.",
                Name = "Shake it Up! Pork Cutlets",
                AmountOfTime = new TimeSpan(0, 25, 0),
                Servings = 4,
                Steps = @"1)Wash and dry all produce. Adjust rack to upper position and preheat oven to 450 degrees. Mince garlic. Place panko in a gallon-sized zip-close bag and season with salt and pepper (we used 2 tsp kosher salt).
2)Place sour cream in a medium bowl, then add pork and toss to coat. Place coated pork and fry seasoning in bag with panko and seal to close. Shake until pork is evenly coated. TIP: You may need to move around cutlets in bag, pressing with your hands to spread out panko and make it stick.
3)Heat a ¼-inch layer of oil in a large pan over medium-high heat (use a nonstick pan if you have one). Halve and core apples, then slice into thin half-moons. Thinly slice celery on a diagonal. Split ciabattas in half (as if you were making sandwiches).
4)Once oil is hot (it should sizzle if you add a breadcrumb), remove pork from bag (discard any panko that doesn’t stick). Add half the pork to pan and cook until panko is golden brown and crisp, 2-3 minutes per side. Transfer to a paper-towel-lined plate and set aside. Repeat with remaining pork.
5)Meanwhile, place 6 TBSP butter and garlic in a small, microwave-safe bowl. Microwave on high until butter melts, about 30 seconds. Place ciabatta halves cut-side up on a baking sheet and drizzle with butter mixture. Toast in oven until crisp and golden, about 5 minutes. Halve on a diagonal to create triangles.,
6)While ciabattas toast, toss together apples, celery, arugula, sunflower seeds, 2 TBSP olive oil, and lemon juice to taste in a medium bowl. Season with salt and pepper. Divide pork, salad, and ciabattas between plates.",
                RecipeIngredientDetails = new List<RecipeIngredientDetail>
                {
                   new RecipeIngredientDetail{ IngredientName = "Garlic", QuantityDescription = "2 gloves" },
                   new RecipeIngredientDetail{ IngredientName = "Sour Cream", QuantityDescription = "4 tablespoons"},
                   new RecipeIngredientDetail{ IngredientName = "Celery", QuantityDescription = "6 units" },
                   new RecipeIngredientDetail{ IngredientName = "Arugula", QuantityDescription = "4 ounces" },
                },
                ImageUrl = "https://res.cloudinary.com/hellofresh/image/upload/f_auto,fl_lossy,q_80,w_auto:100:1280/v1/hellofresh_s3/image/w36-r5-family-73aeb975.jpg",
                Author = appUser,
                AddedOn = DateTime.Now
            };

            var secondRecipe = new Recipe
            {
                Votes = 0,
                Description = @"Not many tacos can boast that they’re rich in vitamin A. Ours, however, are full of it, thanks to tender roasted cubes of sweet potato. They’re joined by black beans and a zesty avocado crema for some of the most delectable veggie goodness to be found inside the fold of a tortilla. You could say that they bring their A-game in every single way.",
                Name = "Sweet Potato and Black Bean Tacos",
                AmountOfTime = new TimeSpan(0, 40, 0),
                Servings = 4,
                Steps = @"1)Wash and dry all produce. Adjust rack to middle position and preheat oven to 400 degrees. Cut sweet potatoes into ½-inch cubes. Toss on a baking sheet with 1 TBSP olive oil and a pinch of salt and pepper. Roast in oven until tender and lightly browned, about 20 minutes.
2)Meanwhile, halve, peel, and dice onion. Pick cilantro leaves from stems; discard stems. Mince or grate garlic. Drain and rinse half the beans from the box (use the rest as you like). Zest ½ tsp zest from lime, then cut into halves.
3)Heat 1 TBSP olive oil in a large pan over medium heat. Add onion and cook, tossing occasionally, until softened, 5-6 minutes. Season with salt and pepper. Add garlic and beans to pan. Cook, tossing, until fragrant and warmed through, 3-4 minutes.
4)Wrap tortillas in foil and place in oven to warm, about 5 minutes. (TIP: Alternatively, wrap tortillas in a damp paper towel and microwave on high until warm, about 30 seconds.) Toss sweet potatoes, honey, cumin, and juice from one lime half into pan with beans and cook until liquid is mostly evaporated, 2-3 minutes. Season with salt and pepper.
5)Halve, pit, and peel avocado. Cut one half into thin slices. Roughly chop other half and place in a medium bowl along with sour cream, juice from remaining lime half, and lime zest. Mash with a fork until mostly smooth. Season with salt and pepper.
6)Spread avocado crema onto tortillas, then top each with filling, avocado slices, and cilantro. TIP: Break out the hot sauce if you like it spicy.",
                RecipeIngredientDetails = new List<RecipeIngredientDetail>
                {
                   new RecipeIngredientDetail{ IngredientName = "Black Beans", QuantityDescription = "6.7 ounces" },
                   new RecipeIngredientDetail{ IngredientName = "Flour Tortillas", QuantityDescription = "6 units" },
                   new RecipeIngredientDetail{ IngredientName = "Sweet Potato", QuantityDescription = "2 units" },
                   new RecipeIngredientDetail{ IngredientName = "Garlic", QuantityDescription = "2 gloves" },
                },
                ImageUrl = "https://res.cloudinary.com/hellofresh/image/upload/f_auto,fl_lossy,q_80,w_auto:100:1280/v1/hellofresh_s3/image/5abd494fae08b54b610ca122-8bfc3c25.jpg",
                Author = appUser,
                AddedOn = DateTime.Now
            };

            recipeRepository.Create(firstRecipe);
            recipeRepository.Create(secondRecipe);
            await recipeRepository.SaveChangesAsync();
        }
    }
}
