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
    public class RecipeController : ControllerBase
    {
        private readonly RecipeService _data;
        public RecipeController(RecipeService dataFromService){
            _data = dataFromService;
        }

        [HttpPost]
        [Route("AddRecipeItem")]
        public bool AddRecipeItem( RecipeItemModel newRecipeItem){
            return _data.AddRecipeItem(newRecipeItem);
        }

        [HttpGet]
        [Route("GetAllRecipeItems")]
        public IEnumerable<RecipeItemModel> GetAllRecipeItems(){
            return _data.GetAllRecipeItems();
        }

        [HttpGet]
        [Route("GetItemsByUserId/{UserId}")]
        public IEnumerable<RecipeItemModel> GetItemsByUserId(int UserID){
            return _data.GetItemsByUserId(UserID);
        }

        [HttpGet]
        [Route("GetItemsByDate/{Date}")]
        public IEnumerable<RecipeItemModel> GetItemsByDate(string Date){
            return _data.GetItemsByDate(Date);
        }

        [HttpGet]
        [Route("GetItemsByTitle/{Title}")]
        public IEnumerable<RecipeItemModel> GetItemsByTitle(string Title){
            return _data.GetItemsByTitle(Title);
        }

        [HttpGet]
        [Route("GetItemsByTags/{Tags}")]
        public List<RecipeItemModel> GetItemsByTags(string Tags){
            return _data.GetItemsByTags(Tags);
        }

        [HttpGet]
        [Route("GetItemsByPublisherName/{PublisherName}")]
        public IEnumerable<RecipeItemModel> GetItemsByPublisherName(string PublisherName){
            return _data.GetItemsByPublisherName(PublisherName);
        }

        [HttpGet]
        [Route("GetItemsByPublished")]
        public IEnumerable<RecipeItemModel> GetItemsByPublished(){
            return _data.GetItemsByPublished();
        }

        [HttpGet]
        [Route("GetItemsByDiet/{Diet}")]
        public IEnumerable<RecipeItemModel> GetItemsByDiet(string Diet){
            return _data.GetItemsByDiet(Diet);
        }

        [HttpGet]
        [Route("GetItemsByRegion/{Region}")]
        public IEnumerable<RecipeItemModel> GetItemsByRegion(string Region){
            return _data.GetItemsByRegion(Region);
        }

        [HttpPost]
        [Route("UpdateRecipeItem")]
        public bool UpdateRecipeItem(RecipeItemModel RecipeUpdate){
            return _data.UpdateRecipeItem(RecipeUpdate);
        }

        [HttpPost]
        [Route("DeleteRecipeItem")]
        public bool DeleteRecipeItem(RecipeItemModel RecipeDelete){
            return _data.DeleteRecipeItem(RecipeDelete);
        }

        
    }
}