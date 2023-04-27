using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookEaseBackEnd.Models;
using cookEaseBackEnd.Services.Context;
using Microsoft.AspNetCore.Mvc;

namespace cookEaseBackEnd.Services
{
    public class NutritionService : ControllerBase
    {
        private readonly DataContext _context;
        public NutritionService(DataContext context){
            _context = context;
        }

        public bool AddNutrition( NutritionItemModel newNewtritionItem){
            _context.Add(newNewtritionItem);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<NutritionItemModel> GetItemsByName(string IngredientName){
            return _context.NutritionInfo.Where(item => item.IngredientName == IngredientName);
        }

        public bool UpdateNutritionItem(NutritionItemModel NutritionUpdate){
            _context.Update<NutritionItemModel>(NutritionUpdate);
            return _context.SaveChanges() != 0;
        }
    }
}