using FoodMenu.Data;
using FoodMenu.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            //await počká na odpověd contextu. async a await se používají pro asynchronní programování (Příprava snídaně).
            return View(await _context.Dishes.ToListAsync());
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
