using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookEaseBackEnd.Models;
using cookEaseBackEnd.Models.Dto;
using cookEaseBackEnd.Services.Context;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace cookEaseBackEnd.Services
{
    public class UserService : ControllerBase
    {
        public readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public bool DoesUserExist(string? Username)
        {
            // check ithe tble to see if the username exists
            // if 1 item matches the condition, return the item
            // if no item matches the condition it will return null
            // if multiple items match return error
            return _context.UserInfo.SingleOrDefault(user => user.Username == Username) != null;
        }

        public bool AddUser(CreateAccountDto UserToAdd)
        {
            bool result = false;
            if (!DoesUserExist(UserToAdd.Username))
            {
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

        public PasswordDto HashPassword(string? password)
        {
            PasswordDto newHashedPassword = new PasswordDto();
            byte[] SaltByte = new byte[64];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(SaltByte);

            var Salt = Convert.ToBase64String(SaltByte);

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(
                password,
                SaltByte,
                10000
            );

            var Hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            newHashedPassword.Salt = Salt;
            newHashedPassword.Hash = Hash;

            return newHashedPassword;
        }

        public bool VerifyUserPassword(string? Password, string? storedHash, string? storedSalt)
        {
            // get our existing salt and change it to base 64 string
            var SaltBytes = Convert.FromBase64String(storedSalt);
            // making the password that the user inputed and using the stored salt
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);
            // created the new hash
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            // checking if the new hash is the same as the stored hash
            return newHash == storedHash;
        }

        public IActionResult Login(LoginDto User)
        {
            IActionResult Result = Unauthorized();

            if (DoesUserExist(User.Username))
            {
                // true
                // we want to store the user object
                // to create another helper function
                UserModel foundUser = GetUserByUsername(User.Username);
                // check if user password is correct
                if (VerifyUserPassword(User.Password, foundUser.Hash, foundUser.Salt))
                {
                    var secretKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("SuperSecretKey@345")
                    );
                    var signinCredentials = new SigningCredentials(
                        secretKey,
                        SecurityAlgorithms.HmacSha256
                    );
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    Result = Ok(new { Token = tokenString });
                }
            }
            return Result;
        }

        public UserModel GetUserByUsername(string? username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }

        public bool UpdateUser(UserModel userToUpdate)
        {
            _context.Update<UserModel>(userToUpdate);
            return _context.SaveChanges() != 0;
        }

        public bool UpdateUsername(int id, string username)
        {
            var foundUser = GetUserById(id);
            // this one is sending over just the id and username
            // we have to get the object to then be updated
            UserModel founduser = GetUserById(id);
            bool result = false;
            if (foundUser != null)
            {
                // a user was found
                foundUser.Username = username;
                _context.Update<UserModel>(foundUser);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }

        public UserModel GetUserById(int? Id)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Id == Id);
        }

        public bool DeleteUser(string userToDelete)
        {
            // this one is just sending ove the username
            // we have to get the object to be deleted
            UserModel foundUser = GetUserByUsername(userToDelete);
            bool result = false;
            if (foundUser != null)
            {
                _context.Remove<UserModel>(foundUser);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }
    }
}
