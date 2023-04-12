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
    public class IngredentsController : ControllerBase
    {
        private readonly IngredentService _data;
        public IngredentsController(IngredentService dataFromService){
            _data = dataFromService;
        }

        [HttpPost]
        [Route("AddIngredents")]
        public bool AddIngredents( IngredentsItemModel newIngredentsItem){
            return _data.AddIngredents(newIngredentsItem);
        }

        [HttpGet]
        [Route("GetItemsByRecipeId/{UserId}")]
        public IEnumerable<RecipeItemModel> GetItemsByRecipeId(int RecipeId){
            return _data.GetItemsByRecipeId(RecipeId);
        }

    }
}