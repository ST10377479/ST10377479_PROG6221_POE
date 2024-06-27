# Recipe App

## Introduction

In today's dynamic culinary landscape, managing recipes effectively can greatly enhance the cooking experience. The Recipe App is designed to simplify the process of creating, organizing, and modifying recipes, catering to both novice cooks and seasoned chefs alike. This comprehensive command-line tool offers robust features, intuitive usability, and error-free handling, ensuring a seamless journey from ingredient entry to recipe scaling.

## Project Overview

The Recipe App serves as a versatile solution for individuals seeking to streamline their cooking routines. Whether you're planning a single meal or managing an extensive menu, this application empowers users with tools to manage recipes effortlessly. Built with clarity and user experience in mind, it provides a structured approach to recipe management that eliminates complexities often associated with culinary preparation.

## Installation & Setup

Getting started with the Recipe App is straightforward. Follow these steps to set up and run the application on your local machine:

1. **Clone the Repository:** Start by cloning the Recipe App repository to your local computer using Git.
   ```bash
   git clone <https://github.com/ST10377479/ST10377479_PROG6221_POE.git>
2. **Navigate to the Project Directory:** Once cloned, navigate into the project directory using your command-line interface.
   ```bash
   cd RecipeApp
3. **Compile and Run the Application:** Use the .NET SDK to compile and run the Recipe App.
      ```bash
   dotnet run
4. **Follow On-screen Instructions:** Upon running the application, follow the on-screen prompts to interact with the Recipe App's functionalities.

## Features and Functionality
The Recipe App encompasses a wide array of features designed to enhance recipe management:

1. **Adding Recipes**
***Input Ingredients: Users can effortlessly input ingredients with details such as name, quantity, unit, calories, and food group.
Define Steps: Define cooking steps with clear descriptions for each recipe.
2. **Viewing and Managing Recipes**
Display Recipes: View all entered recipes in a structured format, including ingredients, steps, and total calories.
Edit Recipes: Modify existing recipes by adding, removing, or updating ingredients and steps.
3. **Scaling Recipes**
Adjust Serving Sizes: Scale recipe quantities based on desired servings, automatically adjusting ingredient quantities proportionally.
Reset Recipes: Revert scaled recipes back to their original quantities effortlessly.
4. **Error Handling and Validation**
Input Validation: Validate user inputs to ensure data integrity and prevent errors such as negative quantities or empty fields.
Error Messaging: Provide clear and informative error messages to guide users in correcting input mistakes.
5. **Food Group Selection and Calorie Information**
Food Group Management: Select food groups from a predefined list to categorize ingredients accurately.
Calorie Calculation: Automatically calculate total calories based on ingredient quantities, aiding in dietary planning.
6. **User-friendly Interface**
Intuitive Navigation: Navigate through the Recipe App using clear menu options and interactive prompts.
Feedback and Confirmation: Receive feedback and confirmations after actions to ensure clarity and user confidence.

## Usage Instructions
Using the Recipe App is straightforward due to its intuitive interface. Here's a step-by-step guide to common actions:

**Example Usage:**
***Add a New Recipe:***

Select the option to add a recipe.
Enter the recipe name, followed by ingredient details including name, quantity, unit, calories, and food group.
Define cooking steps with clear descriptions.

**View Recipes:**

Choose to display all recipes currently stored in the application.
Navigate through recipes to view detailed ingredient lists, cooking steps, and total calories.

**Scale a Recipe:**

Select a recipe from the list to scale.
Enter the scaling factor (e.g., double the servings) to adjust ingredient quantities accordingly.

**Reset Recipe Data:**

Opt to reset a recipe's ingredient quantities back to their original values.
Confirm the action to finalize the reset process.

**Clear Recipe Data:**

Clear all ingredients and steps for a specific recipe.
Confirm the action to remove all data associated with the selected recipe.

## Class Structure
The Recipe App is built upon a well-structured class hierarchy to ensure modularity and maintainability:

Recipe Class: Represents a recipe entity with properties for name, ingredients (list), steps (list), and total calories.

Ingredient Class: Defines individual ingredients with attributes such as name, quantity, unit, calories, and food group.

Step Class: Represents sequential steps in cooking with detailed descriptions.

**Advanced Features and Enhancements**
1. Future Enhancements
Enhanced GUI: Consider implementing a graphical user interface (GUI) for enhanced user interaction and visual feedback.
Cloud Integration: Introduce cloud storage options to synchronize recipes across multiple devices.
Nutritional Insights: Incorporate nutritional analysis tools to provide detailed dietary information per recipe.
2. Contribution and Feedback
We value your feedback and contributions to improving the Recipe App. Whether it's fixing bugs, adding new features, or suggesting enhancements, your input drives our continuous improvement efforts.

## Lecturer Feedback
**Feedback Summary**
**User Feedback**
***Clarity:*** Ensure clear feedback is provided to users following prompts or confirmation messages for each action.
***Error Handling:** Implement robust error handling throughout the application. Display informative error messages when users enter invalid data, such as negative quantities or incorrect formats. The current implementation should include comprehensive error and exception handling to enhance user experience and manage input errors effectively.

## Conclusion
The Recipe App stands as a testament to effective recipe management, offering a seamless blend of functionality and user experience. Whether you're a culinary enthusiast or a professional chef, this application provides the tools needed to streamline your cooking process. With robust error handling, intuitive navigation, and comprehensive features, the Recipe App is your ultimate companion in the kitchen.

## License
This project is licensed under the MIT License. See the LICENSE file for details.
This README file is structured to provide comprehensive information about the Recipe App, including installation instructions, detailed features, usage instructions, class structure, advanced features, and conclusion. Adjustments can be made based on specific requirements or additional feedback.

 
