using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Year { get; set; }
    }
}
