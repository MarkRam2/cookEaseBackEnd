using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace cookEaseBackEnd.Models
{
    [Keyless]
    public class IngredientsModel
    {
        public string? Ingredient { get; set; }
        public int? Quantity { get; set; }
    }

    [Keyless]
    public class RecipeItemModel
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string? PublisherName { get; set; }
        public string? Date { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string? Diet { get; set; }
        public string? Tags { get; set; }
        public string? Region { get; set; }
        public List<IngredientsModel> Ingredients { get; set; }
        public bool isPublished { get; set; }
        public bool isDeleted { get; set; }

        public RecipeItemModel() { }
    }
}
