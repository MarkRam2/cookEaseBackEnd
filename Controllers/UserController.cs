using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookEaseBackEnd.Models.Dto;
using cookEaseBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using cookEaseBackEnd.Models;

namespace cookEaseBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _data;
        public UserController(UserService dataFromService){
            _data = dataFromService;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDto User){
            return _data.Login(User);
        }

        [HttpPost]
        [Route("AddUser")]
        public bool AddUser(CreateAccountDto UserToAdd){
            return _data.AddUser(UserToAdd);
        }

        [HttpPost]
        [Route("AddUser")]
        public bool UpdateUser(UserModel userToUpdate){
            return _data.UpdateUser(userToUpdate);
        }

    }
}