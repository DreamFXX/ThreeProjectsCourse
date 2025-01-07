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
        modelBuilder.Entity<DishIngredient>().HasOne(di => di.Dish).WithMany(d => d.DishIngredients).HasForeignKey(di => di.DishId);
        modelBuilder.Entity<DishIngredient>().HasOne(di => di.Ingredient).WithMany(i => i.DishIngredients).HasForeignKey(di => di.IngredientId);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<DishIngredient> DishIngredients { get; set; }

}
