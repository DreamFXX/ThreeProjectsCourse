namespace FoodMenu.Models;

public class DishIngredient
{
    public int Id { get; set; }
    public Dish? Dish { get; set; }

    public int IngredientId { get; set; }
    public Ingredient? Ingredient { get; set; }
}
