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
        private readonly ArticleService _data;
        public IngredentsController(ArticleService dataFromService){
            _data = dataFromService;
        }

        [HttpPost]
        [Route("AddIngredents")]
        public bool AddIngredents( ArticleItemModel newArticelItem){
            return _data.AddIngredents(newArticelItem);
        }

        [HttpGet]
        [Route("GetItemsByRecipeId/{UserId}")]
        public IEnumerable<RecipeItemModel> GetItemsByRecipeId(int RecipeId){
            return _data.GetItemsByRecipeId(RecipeId);
        }



    }
}