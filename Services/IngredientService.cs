using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookEaseBackEnd.Models;
using cookEaseBackEnd.Services.Context;

namespace cookEaseBackEnd.Services
{

    public class IngredientService
    {

        private readonly DataContext _context;
        public IngredientService(DataContext context){
            _context = context;
        }

        public bool AddIngredients( IngredientsItemModel newIngredientsItem){
             _context.Add(newIngredientsItem);
            return _context.SaveChanges() != 0;
        }
        public IEnumerable<IngredientsItemModel> GetItemsByRecipeId(int RecipeId){
            return _context.IngredientInfo.Where(item => item.RecipeId == RecipeId);
        }
        public bool UpdateIngredientItem(IngredientsItemModel IngredientUpdate){
            _context.Update<IngredientsItemModel>(IngredientUpdate);
            return _context.SaveChanges() != 0;
        }


    }
}