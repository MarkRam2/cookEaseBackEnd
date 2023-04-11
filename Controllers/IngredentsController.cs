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



    }
}