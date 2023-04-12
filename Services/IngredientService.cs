using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookEaseBackEnd.Models;
using cookEaseBackEnd.Services.Context;

namespace cookEaseBackEnd.Services
{
    public class IngredentService
    {

        private readonly DataContext _context;
        public IngredentService(DataContext context){
            _context = context;
        }

        public IEnumerable<IngredentsItemModel> GetItemsByRecipeId(int RecipeId){
            return _context.IngredientInfo.Where(item => item.RecipeId == RecipeId);
        }

        public bool AddIngredents( IngredentsItemModel newIngredentsItem){
             _context.Add(newIngredentsItem);
            return _context.SaveChanges() != 0;
        }
        
    }
}