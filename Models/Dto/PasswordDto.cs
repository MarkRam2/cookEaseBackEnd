using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cookEaseBackEnd.Models.Dto
{
    public class PasswordDto
    {
        public string? Saltt { get; set; }
        public string? hash { get; set; }
        
    }
}