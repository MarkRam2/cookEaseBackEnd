using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cookEaseBackEnd.Models
{
    public class ArticleItemModel
    {
        public int Id { get; set; }
        public string? ArticleName { get; set; }
        public string? PublisherName { get; set; }
        public string? Date { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string? Tags { get; set; }
        public string? Categories { get; set; }
        public bool isPublished { get; set; }
        public bool isDeleted { get; set; }
    }   
}