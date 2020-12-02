using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.ViewModel
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string About { get; set; }
        public List<String> Roles { get; set; }
        public bool Banned { get; set; }

        public UserViewModel()
        {
        }

        public UserViewModel(User user)
        {
            this.UserId = user.UserId;
            this.Email = user.Email;
            this.Username = user.Username;
            this.Name = user.Profile.Name;
            this.ImagePath = user.Profile.ImagePath;
            this.About = user.Profile.About;
            this.Banned = user.Banned;
            this.Roles = new List<string>();
            
            if (user.Roles != null)
            {
                foreach (var role in user.Roles)
                {
                    Roles.Add(role.Name);
                }
            }
        }
    }
}
