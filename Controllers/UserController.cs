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
        // login end point

        // add a user 
            // if the user alredy exists
            // if they don't exist create the account
            // else throw a false
            public bool AddUser(CreateAccountDto UserToAdd){
                return _data.AddUser(UserToAdd);
            }
        // update USER ACCOUNT
        // delete user account
        public PasswordDto HashPassword(string password){
            PasswordDto newHashedPassword = new PasswordDto();
            byte[] SaltByte = new byte[64];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(SaltByte);

            var Salt = Convert.ToBase64String(SaltByte);

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltByte, 10000);

            var Hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            newHashedPassword.Salt = Salt;
            newHashedPassword.Hash = Hash;

            return newHashedPassword;
        }

        public bool VerifyUserPassword(string? Password, string? storedHash, string? storedSalt){
            var SaltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            return newHash == storedHash;
        }
    }
}