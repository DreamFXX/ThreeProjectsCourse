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
            new Dish { Id = 1, Name = "Svíčková", ImageUrl = "https://sl.bing.net/hU2GbJ0bHZk", Price = 179.90m },
            new Dish { Id = 2, Name = "Smažený Sýr", ImageUrl = "https://sl.bing.net/icCY8QK8c1c", Price = 129.90m },
            new Dish { Id = 3, Name = "Lasaně", ImageUrl = "https://sl.bing.net/h7PZLOZ90LY", Price = 149.99m }
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
