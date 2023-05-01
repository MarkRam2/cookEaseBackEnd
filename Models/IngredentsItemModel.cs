using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace cookEaseBackEnd.Models
{

    [Keyless]
    public class IngredientsItemModel
    {
        public int Id { get; set; }
        public int? RecipeId { get; set; }
        public string? Ingredent { get; set; }
        public int? Weight { get; set; }

        public IngredientsItemModel() { }
    }

    public class IngredentArray

    public class Program
    {
        static void Main(string[] args)
        {
            IngredientsItemModel IngArray = new IngredientsItemModel
            {
                
            };
            var options = new JsonSerializerOptions();
            
            string json = JsonSerializer.Serialize<IngredientsItemModel>(IngArray);
        }
    }
}
