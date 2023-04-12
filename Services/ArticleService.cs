using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookEaseBackEnd.Models;
using cookEaseBackEnd.Services.Context;

namespace cookEaseBackEnd.Services
{
    public class ArticleService
    {
        private readonly DataContext _context;
        public ArticleService(DataContext context){
            _context = context;
        }

        public bool AddArtcleItem( ArticleItemModel newArticelItem){
            _context.Add(newArticelItem);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<ArticleItemModel> GetAllArticleItems(){
            return _context.ArticleInfo;
        }

        public IEnumerable<ArticleItemModel> GetItemsByUserId(int UserId){
            return _context.ArticleInfo.Where(item => item.UserID == UserId);
        }

        public IEnumerable<ArticleItemModel> GetArticleById(int Id){
            return _context.ArticleInfo.Where(item => item.Id == Id);
        }

        public IEnumerable<ArticleItemModel> GetItemsByCategory(string Categories){
            return _context.ArticleInfo.Where(item => item.Categories == Categories);
        }

        public IEnumerable<ArticleItemModel> GetItemsByDate(string Date){
            return _context.ArticleInfo.Where(item => item.Date == Date);
        }

        public IEnumerable<ArticleItemModel> GetItemsByTitle(string Title){
            return _context.ArticleInfo.Where(item => item.Title == Title);
        }

        public List<ArticleItemModel> GetItemsByTags(string Tags){

            List<ArticleItemModel> AllArticlesWithTags = new List<ArticleItemModel>();
            var allItems = GetAllArticleItems().ToList();

            for(int i=0; i< allItems.Count; i++){
                ArticleItemModel Item = allItems[i];
                var itemArr = Item.Tags.Split(",");
                for(int j=0; j < itemArr.Length; j++){
                    // checking if the item array has the tag we're looking for
                    if(itemArr[j].Contains(Tags)){
                        AllArticlesWithTags.Add(Item);
                    }
                }
            }
            return AllArticlesWithTags;
        }

        public IEnumerable<ArticleItemModel> GetItemsByPublisherName(string PublisherName){
            return _context.ArticleInfo.Where(item => item.PublisherName == PublisherName);
        }

        public IEnumerable<ArticleItemModel> GetItemsByPublished(){
            return _context.ArticleInfo.Where(item => item.isPublished);
        }
        public bool UpdateArticleItem(ArticleItemModel ArticleUpdate){
            _context.Update<ArticleItemModel>(ArticleUpdate);
            return _context.SaveChanges() != 0;
        }
        public bool DeleteArticleItem(ArticleItemModel ArticleDelete){
            ArticleDelete.isDeleted = true;
            _context.Update<ArticleItemModel>(ArticleDelete);
            return _context.SaveChanges() != 0;
        }
    }
}