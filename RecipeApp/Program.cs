using System;
using System.Collections.Generic;

namespace RecipeApp
{
    class Recipe
    {
        private List<string[]> recipes;
        private string[] sampleRecipe;

        public Recipe()
        {
            recipes = new List<string[]>();
            sampleRecipe = new string[2];
            sampleRecipe[0] = "2 Chicken breasts; 1 half teaspoon of salt; 2 tablespoons of Mayo";
            sampleRecipe[1] = "1. Add water to a pot and bring it to a boil.;2. Add the 2 breasts of chicken and 1 half teaspoon of salt and boil till cooked well.;3. Once chicken is done take it out of the pot and place on a plate to cool.;4. Shread the chicken to your desired sizes.;5. Add the 2 tablespoons of Mayo, mix and enjoy with any dish or in a sandwich.";
        }

        // Method to input recipe details
        public void InputRecipe()
        {
            string[] newRecipe = new string[2]; // Array to hold ingredients and steps
            Console.Write("Enter the name of the recipe: ");
            string name = Console.ReadLine();

            Console.Write("Enter the number of ingredients: ");
            int numIngredients = Convert.ToInt32(Console.ReadLine());
            string[] ingredients = new string[numIngredients];

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter details for ingredient {i + 1}:");
                Console.Write("Name: ");
                string ingredientName = Console.ReadLine();
                Console.Write("Quantity: ");
                string quantity = Console.ReadLine();
                Console.Write("Unit of Measurement: ");
                string unit = Console.ReadLine();
                ingredients[i] = $"{quantity} {unit} of {ingredientName}";
            }
            newRecipe[0] = string.Join(";", ingredients); // Store ingredients as a single string separated by semicolon

            Console.Write("\nEnter the number of steps: ");
            int numSteps = Convert.ToInt32(Console.ReadLine());
            string[] steps = new string[numSteps];

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                steps[i] = Console.ReadLine();
            }
            newRecipe[1] = string.Join(";", steps); // Store steps as a single string separated by semicolon

            recipes.Add(newRecipe); // Add new recipe to the list
        }

        // Method to display all recipes
        public void DisplayRecipes()
        {
            Console.WriteLine("\nAvailable Recipes:");
            Console.WriteLine("Sample Recipe:");
            DisplayRecipe(sampleRecipe);

            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"Recipe {i + 1}:");
                DisplayRecipe(recipes[i]);
            }
        }

        // Method to display a single recipe
        private void DisplayRecipe(string[] recipe)
        {
            Console.WriteLine("Ingredients:");
            string[] ingredients = recipe[0].Split(';');
            foreach (string ingredient in ingredients)
            {
                Console.WriteLine(ingredient);
            }

            Console.WriteLine("\nSteps:");
            string[] steps = recipe[1].Split(';');
            for (int j = 0; j < steps.Length; j++)
            {
                Console.WriteLine($"{j + 1}. {steps[j]}");
            }
            Console.WriteLine();
        }

        // Method to clear all data except for the sample recipe
        public void ClearData()
        {
            recipes.Clear();
            Console.WriteLine("All inputted recipes cleared.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                Console.WriteLine("\n=============================");
                Console.WriteLine("Welcome to Cook-A-Fair");
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Enter Recipe Details");
                Console.WriteLine("2. View Available Recipes");
                Console.WriteLine("3. Clear Inputted Recipes");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        recipe.InputRecipe();
                        break;
                    case 2:
                        recipe.DisplayRecipes();
                        break;
                    case 3:
                        recipe.ClearData();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
        }
    }
}
