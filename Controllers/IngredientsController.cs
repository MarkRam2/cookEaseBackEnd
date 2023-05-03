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
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientService _data;
        public IngredientsController(IngredientService dataFromService){
            _data = dataFromService;
        }

        [HttpPost]
        [Route("AddIngredients")]
        public bool AddIngredients( IngredientsItemModel newIngredientsItem){
            return _data.AddIngredients(newIngredientsItem);
        }

        [HttpGet]
        [Route("GetItemsByRecipeId/{RecipeId}")]
        public IEnumerable<IngredientsItemModel> GetItemsByRecipeId(int RecipeId){
            return _data.GetItemsByRecipeId(RecipeId);
            
        }

        [HttpPost]
        [Route("UpdateIngrdientItem")]
        public bool UpdateIngredientItem(IngredientsItemModel IngredientUpdate){
            return _data.UpdateIngredientItem(IngredientUpdate);
        }


    }
}