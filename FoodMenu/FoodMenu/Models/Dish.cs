namespace FoodMenu.Models;

public class Dish
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }

    public decimal Price { get; set; }

    public List<DishIngredient>? DishIngredients { get; set; }
}
