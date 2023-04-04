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
    public class ArticleController : ControllerBase
    {
        private readonly ArticleService _data;
        public ArticleController(ArticleService dataFromService){
            _data = dataFromService;
        }

        [HttpPost]
        [Route("AddArticleItem")]
        public bool AddArtcleItem( ArticleItemModel newArticelItem){
            return _data.AddArtcleItem(newArticelItem);
        }

        [HttpGet]
        [Route("GetAllArticleItems")]
        public IEnumerable<ArticleItemModel> GetAllArticleItems(){
            return _data.GetAllArticleItems();
        }

        [HttpGet]
        [Route("GetItemsByUserId/{UserId}")]
        public IEnumerable<ArticleItemModel> GetItemsByUserId(int UserID){
            return _data.GetItemsByUserId(UserID);
        }

        [HttpGet]
        [Route("GetItemsByCategory/{Categories}")]
        public IEnumerable<ArticleItemModel> GetItemsByCategory(string Categories){
            return _data.GetItemsByCategory(Categories);
        }

        [HttpGet]
        [Route("GetItemsByDate/{Date}")]
        public IEnumerable<ArticleItemModel> GetItemsByDate(string Date){
            return _data.GetItemsByDate(Date);
        }
        
        [HttpGet]
        [Route("GetItemsByTitle/{Title}")]
        public IEnumerable<ArticleItemModel> GetItemsByTitle(string Title){
            return _data.GetItemsByTitle(Title);
        }

        [HttpGet]
        [Route("GetItemsByTags/{Tags}")]
        public List<ArticleItemModel> GetItemsByTags(string Tags){
            return _data.GetItemsByTags(Tags);
        }

        [HttpGet]
        [Route("GetItemsByPublisherName/{PublisherName}")]
        public IEnumerable<ArticleItemModel> GetItemsByPublisherName(string PublisherName){
            return _data.GetItemsByPublisherName(PublisherName);
        }

        [HttpGet]
        [Route("GetItemsByPublished")]
        public IEnumerable<ArticleItemModel> GetItemsByPublished(){
            return _data.GetItemsByPublished();
        }

    }
}