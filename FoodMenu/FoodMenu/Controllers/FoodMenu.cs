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
    }
}
