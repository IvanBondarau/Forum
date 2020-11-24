using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Profile Profile { get; set; }

        public ICollection<Topic> Featured { get; set; }

        public User()
        {

        }

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

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   UserId == user.UserId &&
                   Username == user.Username &&
                   Email == user.Email;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UserId, Username, Email);
        }
    }
}
