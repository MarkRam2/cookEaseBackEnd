using System.Text.Json;
using cookEaseBackEnd.Services;
using cookEaseBackEnd.Services.Context;
using Microsoft.EntityFrameworkCore;

namespace cookEaseBackEnd.Models
{
    public class IngredientsItemModel
    {
        public int Id { get; set; }
        public int? RecipeId { get; set; }
        public string? Ingredient { get; set; }
        public int? Weight { get; set; }

        public IngredientsItemModel() { }
        
    }
                
    
    public class Program
    {

        static void Main(string[] args)
        {
            List<IngredientsItemModel> ingredients = new List<IngredientsItemModel>();

            using (var dbContext = new DataContext())
            {
                var ingredientsFromDb = dbContext.IngredientInfo
                    .Where(i => i.RecipeId == 1)
                    .ToList();

                foreach (var Ingredient in ingredientsFromDb)
                {
                    IngredientsItemModel model = new IngredientsItemModel
                    {
                        Ingredient = Ingredient.Ingredient,
                        Weight = Ingredient.Weight, 
                    };
                    ingredients.Add(model);
                }
            }

            var options = new JsonSerializerOptions();

            string jsonString = JsonSerializer.Serialize<List<IngredientsItemModel>>(ingredients);
        }
    }
}
