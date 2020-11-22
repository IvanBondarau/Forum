using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.ViewModel
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string About { get; set; }

        public UserViewModel()
        {
        }

        public UserViewModel(User user)
        {
            this.Email = user.Email;
            this.Username = user.Username;
            this.Name = user.Profile.Name;
            this.ImagePath = user.Profile.ImagePath;
            this.About = user.Profile.About;
        }
    }
}
