using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookEaseBackEnd.Models;
using cookEaseBackEnd.Models.Dto;
using cookEaseBackEnd.Services.Context;

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

    }
}