using FoodMenu.Data;
using FoodMenu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.EntityFrameworkCore;

namespace FoodMenu.Controllers
{
    public class FoodMenu : Controller
    {
        // Add a constructor to inject the FoodMenuContext
        private readonly FoodMenuContext _context;
        public FoodMenu(FoodMenuContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var dishes = from d in _context.Dishes
                         select d;

            if (!string.IsNullOrEmpty(searchString))
            {
                dishes = dishes.Where(d => d.Name.Contains(searchString));
                return View(await dishes.ToListAsync());
            }

            //await počká na odpověd contextu. async a await se používají pro asynchronní programování (Příprava snídaně).
            return View(await dishes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var dish = await _context.Dishes
                    .Include(di => di.DishIngredients)
                    .ThenInclude(i => i.Ingredient)
                    .FirstOrDefaultAsync(x => x.Id == id);

            if (dish == null)
            {
                return NotFound();
            }
            return View(dish);
        }
    }
}
