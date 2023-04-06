using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookEaseBackEnd.Models;
using cookEaseBackEnd.Services.Context;

namespace cookEaseBackEnd.Services
{
    public class RecipeService
    {
        private readonly DataContext _context;
        public RecipeService(DataContext context){
            _context = context;
        }
        public bool AddRecipeItem(RecipeItemModel newRecipeItem){
            _context.Add(newRecipeItem);
            return _context.SaveChanges() != 0;
        }
        public IEnumerable<RecipeItemModel> GetAllRecipeItems(){
            return _context.RecipeInfo;
        }
        public IEnumerable<RecipeItemModel> GetItemsByUserId(int UserId){
            return _context.RecipeInfo.Where(item => item.UserID == UserId);
        }
        public IEnumerable<RecipeItemModel> GetItemsByDate(string Date){
            return _context.RecipeInfo.Where(item => item.Date == Date);
        }
        public IEnumerable<RecipeItemModel> GetItemsByTitle(string Title){
            return _context.RecipeInfo.Where(item => item.Title == Title);
        }
        public List<RecipeItemModel> GetItemsByTags(string Tags){

            List<RecipeItemModel> AllRecipeWithTags = new List<RecipeItemModel>();
            var allItems = GetAllRecipeItems().ToList();

            for(int i=0; i< allItems.Count; i++){
                RecipeItemModel Item = allItems[i];
                var itemArr = Item.Tags.Split(",");
                for(int j=0; j < itemArr.Length; j++){
                    // checking if the item array has the tag we're looking for
                    if(itemArr[j].Contains(Tags)){
                        AllRecipeWithTags.Add(Item);
                    }
                }
            }
            return AllRecipeWithTags;
        }
        public IEnumerable<RecipeItemModel> GetItemsByPublisherName(string PublisherName){
            return _context.RecipeInfo.Where(item => item.PublisherName == PublisherName);
        }
        public IEnumerable<RecipeItemModel> GetItemsByPublished(){
            return _context.RecipeInfo.Where(item => item.isPublished);
        }
        public IEnumerable<RecipeItemModel> GetItemsByDiet(string Diet){
            return _context.RecipeInfo.Where(item => item.Diet == Diet);
        }
        public IEnumerable<RecipeItemModel> GetItemsByRegion(string Region){
            return _context.RecipeInfo.Where(item => item.Region == Region);
        }
        public bool UpdateRecipeItem(RecipeItemModel RecipeUpdate){
            _context.Update<RecipeItemModel>(RecipeUpdate);
            return _context.SaveChanges() != 0;
        }
        public bool DeleteRecipeItem(RecipeItemModel RecipeDelete){
            RecipeDelete.isDeleted = true;
            _context.Update<RecipeItemModel>(RecipeDelete);
            return _context.SaveChanges() != 0;
        }
    }
}