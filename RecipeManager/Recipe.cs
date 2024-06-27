using System.Collections.Generic;
using System.Text;

public class Recipe
{
    public string Name { get; }
    public List<string> Ingredients { get; }
    public List<string> Steps { get; }
    public string FoodGroup { get; }
    public int Calories { get; private set; }

    public Recipe(string name, List<string> ingredients, List<string> steps, string foodGroup, int calories)
    {
        Name = name;
        Ingredients = ingredients;
        Steps = steps;
        FoodGroup = foodGroup;
        Calories = calories;
    }

    public void Scale(double factor)
    {
        for (int i = 0; i < Ingredients.Count; i++)
        {
            Ingredients[i] = ScaleIngredient(Ingredients[i], factor);
        }
        Calories = (int)(Calories * factor);
    }

    private string ScaleIngredient(string ingredient, double factor)
    {
        string[] parts = ingredient.Split(',');
        if (parts.Length >= 2 && double.TryParse(parts[0], out double quantity))
        {
            quantity *= factor;
            parts[0] = quantity.ToString();
        }
        return string.Join(",", parts);
    }

    public string GetRecipeDetails()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Recipe Name: {Name}");
        sb.AppendLine("Ingredients:");
        foreach (var ingredient in Ingredients)
        {
            sb.AppendLine($"- {ingredient}");
        }
        sb.AppendLine("Steps:");
        foreach (var step in Steps)
        {
            sb.AppendLine($"- {step}");
        }
        sb.AppendLine($"Food Group: {FoodGroup}");
        sb.AppendLine($"Calories: {Calories}");

        return sb.ToString();
    }

    public Recipe Clone()
    {
        return new Recipe(Name, new List<string>(Ingredients), new List<string>(Steps), FoodGroup, Calories);
    }
}
