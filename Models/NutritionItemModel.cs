using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cookEaseBackEnd.Models
{
    public class NutritionItemModel
    {
		public int Id { get; set; }
		public string? IngredientName { get; set; }
		public int Calories { get; set; }
		public int protein { get; set; }
		public int Carbs { get; set; }
		public int Fat { get; set; }
		public int Sodium { get; set; }
		public bool isDeleted { get; set; }

		public NutritionItemModel(){
			
		}
    }
}