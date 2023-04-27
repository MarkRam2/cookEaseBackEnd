using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookEaseBackEnd.Models;
using cookEaseBackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace cookEaseBackEnd.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class NutritionController : ControllerBase
    {
        private readonly NutritionService _data;
        public NutritionController(NutritionService dataFromService){
            _data = dataFromService;
        }

        [HttpPost]
        [Route("AddNutrition")]
        public bool AddNutrition( NutritionItemModel newNutritionItem){
            return _data.AddNutrition(newNutritionItem);
        }

        [HttpGet]
        [Route("GetItemsByName/{IngredientName}")]
        public IEnumerable<NutritionItemModel> GetItemsByName(string IngredientName){
            return _data.GetItemsByName(IngredientName);
        }

        [HttpPost]
        [Route("UpdateNutritionItem")]
        public bool UpdateNutritionItem(NutritionItemModel NutritionUpdate){
            return _data.UpdateNutritionItem(NutritionUpdate);
        }

    }
}
