using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cookEaseBackEnd.Models
{
    public class RecipeItemModel
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string? date { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string? Diet { get; set; }
        public string? Tags { get; set; }
        public string? Region { get; set; }
        public bool isPublished { get; set; }
        public bool isDeleted { get; set; }
    }
}