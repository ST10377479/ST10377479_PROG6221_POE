using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace RecipeManager
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes = new List<Recipe>();

        public MainWindow()
        {
            InitializeComponent();

            // Initialize UI with default placeholder texts
            RecipeNameTextBox.Text = "Enter recipe name";
            IngredientsStackPanel.Children.Add(new TextBox { Margin = new Thickness(0, 3, 0, 3), Width = 200, Text = "Enter ingredient" });
            StepsStackPanel.Children.Add(new TextBox { Margin = new Thickness(0, 3, 0, 3), Width = 200, Text = "Enter step" });

            // Initialize Food Group ComboBox
            FoodGroupComboBox.Items.Add(new ComboBoxItem { Content = "Select food group", IsEnabled = false });
            FoodGroupComboBox.Items.Add(new ComboBoxItem { Content = "Vegetables" });
            FoodGroupComboBox.Items.Add(new ComboBoxItem { Content = "Fruits" });
            FoodGroupComboBox.Items.Add(new ComboBoxItem { Content = "Proteins" });
            FoodGroupComboBox.Items.Add(new ComboBoxItem { Content = "Grains" });
            FoodGroupComboBox.Items.Add(new ComboBoxItem { Content = "Dairy" });
            FoodGroupComboBox.SelectedIndex = 0;

        }

        // Placeholder handling for TextBoxes
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && (textBox.Text == "Enter recipe name"
                                           || textBox.Text == "Enter ingredient"
                                           || textBox.Text == "Enter step"
                                           || textBox.Text == "Max calories"))
            {
                textBox.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == RecipeNameTextBox)
                    textBox.Text = "Enter recipe name";
                else if (textBox == FilterTextBox)
                    textBox.Text = "Enter ingredient";
                else if (textBox == MaxCaloriesTextBox)
                    textBox.Text = "Max calories";
                else
                    textBox.Text = "Enter step";  // Assuming this is the default for Steps
            }
        }

        // Event handlers for buttons and other UI elements
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            TextBox newIngredientTextBox = new TextBox
            {
                Margin = new Thickness(0, 3, 0, 3),
                Width = 200,
                Text = "Enter ingredient"
            };
            IngredientsStackPanel.Children.Add(newIngredientTextBox);
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            TextBox newStepTextBox = new TextBox
            {
                Margin = new Thickness(0, 3, 0, 3),
                Width = 200,
                Text = "Enter step"
            };
            StepsStackPanel.Children.Add(newStepTextBox);
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text;
            List<string> ingredients = GetTextBoxValues(IngredientsStackPanel);
            List<string> steps = GetTextBoxValues(StepsStackPanel);
            string foodGroup = (FoodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            int calories = 0; // Placeholder for calories, replace with actual value

            // Example: Assigning a default value of 0 for calories
            if (!int.TryParse(MaxCaloriesTextBox.Text, out calories))
            {
                calories = 0; // or handle accordingly if parsing fails
            }

            Recipe newRecipe = new Recipe(recipeName, ingredients, steps, foodGroup, calories);
            recipes.Add(newRecipe);
            RecipeListBox.Items.Add(recipeName);

            // Clear UI elements
            RecipeNameTextBox.Text = "Enter recipe name";
            IngredientsStackPanel.Children.Clear();
            StepsStackPanel.Children.Clear();
            IngredientsStackPanel.Children.Add(new TextBox { Margin = new Thickness(0, 3, 0, 3), Width = 200, Text = "Enter ingredient" });
            StepsStackPanel.Children.Add(new TextBox { Margin = new Thickness(0, 3, 0, 3), Width = 200, Text = "Enter step" });
        }

        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            string filterIngredient = FilterTextBox.Text;
            string foodGroup = (FoodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string maxCaloriesStr = MaxCaloriesTextBox.Text;
            int maxCalories = 0;
            bool isNumeric = int.TryParse(maxCaloriesStr, out maxCalories);

            // Apply filtering logic
            List<Recipe> filteredRecipes = recipes;

            // Filter by ingredient
            if (!string.IsNullOrWhiteSpace(filterIngredient) && filterIngredient != "Enter ingredient")
            {
                filteredRecipes = filteredRecipes.Where(r => r.Ingredients.Any(ingredient =>
                    ingredient.IndexOf(filterIngredient, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();
            }

            // Filter by food group
            if (!string.IsNullOrWhiteSpace(foodGroup) && foodGroup != "Select food group")
            {
                filteredRecipes = filteredRecipes.Where(r => r.FoodGroup.Equals(foodGroup, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Filter by max calories
            if (isNumeric && maxCalories > 0)
            {
                filteredRecipes = filteredRecipes.Where(r => r.Calories <= maxCalories).ToList();
            }

            // Update RecipeListBox with filtered recipes
            RecipeListBox.Items.Clear();
            foreach (Recipe recipe in filteredRecipes)
            {
                RecipeListBox.Items.Add(recipe.Name);
            }
        }

        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            FilterTextBox.Text = "Enter ingredient";
            FoodGroupComboBox.SelectedIndex = 0; // Select the placeholder item
            MaxCaloriesTextBox.Text = "Max calories";

            // Restore RecipeListBox to show all recipes, sorted alphabetically
            RecipeListBox.Items.Clear();
            foreach (Recipe recipe in recipes.OrderBy(r => r.Name))
            {
                RecipeListBox.Items.Add(recipe.Name);
            }
        }


        private void ExportRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Export recipes logic
            StringBuilder sb = new StringBuilder();
            foreach (Recipe recipe in recipes)
            {
                sb.AppendLine($"Recipe: {recipe.Name}");
                sb.AppendLine("Ingredients:");
                foreach (string ingredient in recipe.Ingredients)
                {
                    sb.AppendLine($"- {ingredient}");
                }
                sb.AppendLine("Steps:");
                foreach (string step in recipe.Steps)
                {
                    sb.AppendLine($"- {step}");
                }
                sb.AppendLine();
            }

            string filePath = "Recipes.txt";
            File.WriteAllText(filePath, sb.ToString());

            MessageBox.Show($"Recipes exported successfully to {filePath}");
        }

        private void RecipeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecipeListBox.SelectedIndex != -1)
            {
                string selectedRecipeName = RecipeListBox.SelectedItem.ToString();
                Recipe selectedRecipe = recipes.FirstOrDefault(r => r.Name == selectedRecipeName);

                if (selectedRecipe != null)
                {
                    RecipeDetailsTextBox.Text = $"Recipe: {selectedRecipe.Name}\n\nIngredients:\n";
                    foreach (string ingredient in selectedRecipe.Ingredients)
                    {
                        RecipeDetailsTextBox.Text += $"- {ingredient}\n";
                    }
                    RecipeDetailsTextBox.Text += "\nSteps:\n";
                    foreach (string step in selectedRecipe.Steps)
                    {
                        RecipeDetailsTextBox.Text += $"- {step}\n";
                    }
                }
            }
        }

        private void ShowPieChart(Dictionary<string, double> foodGroupPercentages)
        {
            PieChartWindow pieChartWindow = new PieChartWindow(foodGroupPercentages);
            pieChartWindow.Show();
        }

        // Example method to trigger showing the pie chart window
        private void ShowPieChartButton_Click(object sender, RoutedEventArgs e)
        {
            // Replace foodGroupPercentages with your actual data
            Dictionary<string, double> foodGroupPercentages = new Dictionary<string, double>
            {
                { "Vegetables", 30.0 },
                { "Fruits", 20.0 },
                { "Proteins", 25.0 },
                { "Grains", 15.0 },
                { "Dairy", 10.0 }
            };

            ShowPieChart(foodGroupPercentages);
        }

        // Helper method to get values from TextBoxes in a StackPanel
        private List<string> GetTextBoxValues(StackPanel stackPanel)
        {
            List<string> values = new List<string>();
            foreach (var child in stackPanel.Children)
            {
                if (child is TextBox textBox)
                {
                    values.Add(textBox.Text);
                }
            }
            return values;
        }
    }
}
// References
//Troelsen, A. and Japokse, P., 2022.PRo C# 10 with .NET 6 : Foundational Principles and Practices in Programming. 11th ed.  NEW York: Apress.(24 June 2024)