using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookEaseBackEnd.Models.Dto;
using cookEaseBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

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

        public bool VerifyUserPassword(string? Password, string? storedHash, string? storedSalt){
            var SaltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            return newHash == storedHash;
        }
    }
}