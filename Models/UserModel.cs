using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cookEaseBackEnd.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Salt { get; set; }
        public string? Hash { get; set; }
        public string? AboutMe { get; set; }
        public string? ProfilePic { get; set; }
        public string? NutrionalGoals { get; set; }
        public UserModel(){}
    }
}