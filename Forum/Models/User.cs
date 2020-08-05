using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Profile Profile { get; set; }

        public User(string username = null, 
                    string email = null, 
                    string password = null, 
                    Profile profile = null)
        {
            Username = username;
            Email = email;
            Password = password;
            Profile = profile;
        }

        public override string ToString()
            => JsonSerializer.Serialize(this);


    }
}
