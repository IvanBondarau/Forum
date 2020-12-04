using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped]
        public Boolean IsFeatured { get; set; }

        public bool Banned { get; set; } = false;

        public bool Verified { get; set; } = false;
        public string VerificationString { get; set; }

        public ICollection<Role> Roles { get; set; }
        public ICollection<Topic> Featured { get; set; }
        public ICollection<Message> Likes { get; set; }

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
