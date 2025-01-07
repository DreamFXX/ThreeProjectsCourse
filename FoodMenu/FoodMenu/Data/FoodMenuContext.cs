using FoodMenu.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodMenu.Data;

public class FoodMenuContext : DbContext
{
    public FoodMenuContext(DbContextOptions<FoodMenuContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DishIngredient>().HasKey(di => new
        {
            di.DishId,
            di.IngredientId
        });
        modelBuilder.Entity<DishIngredient>()
                    .HasOne(di => di.Dish)
                    .WithMany(d => d.DishIngredients)
                    .HasForeignKey(di => di.DishId);
        modelBuilder.Entity<DishIngredient>()
                    .HasOne(di => di.Ingredient)
                    .WithMany(i => i.DishIngredients)
                    .HasForeignKey(di => di.IngredientId);

        // Price column configuration, so it can store any form of worldwide prices.
        modelBuilder.Entity<Dish>()
            .Property(d => d.Price)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Dish>().HasData(
            new Dish { Id = 1, Name = "Svíčková", ImageUrl = "https://www.kulinar.cz/uploads/media/default/0001/01/thumb_676_default_big.jpeg", Price = 179.90m },
            new Dish { Id = 2, Name = "Smažený Sýr", ImageUrl = "https://1884403144.rsc.cdn77.org/foto/smazak-syr/NDk4eDI4OC9jZW50ZXIvbWlkZGxlL3NtYXJ0L2ZpbHRlcnM6cXVhbGl0eSg4NSkvaW1n/3433384.jpg?v=0&st=FdPWU4F-PU22Qj8j33mYOEtoB67hEQg9Hlf7t9N7c-s&ts=1600812000&e=0", Price = 129.90m },
            new Dish { Id = 3, Name = "Lasaně", ImageUrl = "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/69EE02DA-213D-44A2-8B08-A590225B221B/Derivates/F40AD961-73B3-4E31-BC0F-A173E296F841.jpg", Price = 149.99m }
        );

        modelBuilder.Entity<Ingredient>().HasData(
            new Ingredient { Id = 1, Name = "Hovězí maso" },
            new Ingredient { Id = 2, Name = "Smetana" },
            new Ingredient { Id = 3, Name = "Listové těsto" },
            new Ingredient { Id = 4, Name = "Sýr" },
            new Ingredient { Id = 5, Name = "Rajčata" },
            new Ingredient { Id = 6, Name = "Knedlíky" },
            new Ingredient { Id = 7, Name = "Hranolky" }
        );

        modelBuilder.Entity<DishIngredient>().HasData(
            new DishIngredient { DishId = 1, IngredientId = 1 },
            new DishIngredient { DishId = 1, IngredientId = 2 },
            new DishIngredient { DishId = 1, IngredientId = 6 },
            new DishIngredient { DishId = 2, IngredientId = 4 },
            new DishIngredient { DishId = 2, IngredientId = 7 },
            new DishIngredient { DishId = 3, IngredientId = 3 },
            new DishIngredient { DishId = 3, IngredientId = 5 }
        );

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<DishIngredient> DishIngredients { get; set; }

}
