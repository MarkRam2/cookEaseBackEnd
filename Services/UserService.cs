using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookEaseBackEnd.Models;
using cookEaseBackEnd.Models.Dto;
using cookEaseBackEnd.Services.Context;
using System.Security.Cryptography;

namespace cookEaseBackEnd.Services
{
    public class UserService
    {
        public readonly DataContext _context;
        public UserService(DataContext context){
            _context = context;
        }
        public bool DoesUserExist(string? Username){
            // check ithe tble to see if the username exists
            // if 1 item matches the condition, return the item
            // if no item matches the condition it will return null
            // if multiple items match return error
            return _context.UserInfo.SingleOrDefault(user => user.Username == Username ) != null;
        }
        public bool AddUser(CreateAccountDto UserToAdd){
            bool result = false;
            if(!DoesUserExist(UserToAdd.Username)){
                UserModel newUser = new UserModel();
                var hashPassword = HashPassword(UserToAdd.Password);
                newUser.Id = UserToAdd.Id;
                newUser.Username = UserToAdd.Username;
                newUser.Salt = hashPassword.Salt;
                newUser.Hash = hashPassword.Hash;

                _context.Add(newUser);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }
        public PasswordDto HashPassword(string? password){
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
            // get our existing salt and change it to base 64 string
            var SaltBytes = Convert.FromBase64String(storedSalt);
            // making the password that the user inputed and using the stored salt
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);
            // created the new hash
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            // checking if the new hash is the same as the stored hash
            return newHash == storedHash;
        }

    }
}