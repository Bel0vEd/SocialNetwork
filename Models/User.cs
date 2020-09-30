using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public int ProfileLink { get; set; }
        public string SecondName { get; set; }
        public string Avatar { get; set; }
        public int Year { get; set; }
    }
    public class User2 : IdentityUser
    {
        public string FirstName { get; set; }
        public int ProfileLink { get; set; }
        public string SecondName { get; set; }
        public string Avatar { get; set; }
        public int Year { get; set; }
    }
}
