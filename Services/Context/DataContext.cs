using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookEaseBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace cookEaseBackEnd.Services.Context
{
    public class DataContext : DbContext
    {
        public DbSet<UserModel> UserInfo { get; set; }
        public DbSet<RecipeItemModel> RecipeInfo { get; set; }
        public DbSet<ArticleItemModel> ArticleInfo { get; set; }
        public DbSet<IngredientsItemModel> IngredientInfo { get; set; }

        public DataContext(DbContextOptions options): base(options){
        }

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
        }
    }
}