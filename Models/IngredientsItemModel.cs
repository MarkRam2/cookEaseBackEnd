using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace cookEaseBackEnd.Models
{

    [Keyless]
    public class IngredientsItemModel
    {
        public int Id { get; set; }
        public int? RecipeId { get; set; }
        public string? Ingredient { get; set; }
        public int? Weight { get; set; }

        public IngredientsItemModel() { }
    }
}
