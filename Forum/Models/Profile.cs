using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string About { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public Profile()
        {

        }

        public Profile(string name = null,
               string imagePath = null,
               string about = null)
        {
            Name = name;
            ImagePath = imagePath;
            About = about;
        }

        public override string ToString()
            => JsonSerializer.Serialize(this);

        public override bool Equals(object obj)
        {
            return obj is Profile profile &&
                   ProfileId == profile.ProfileId &&
                   Name == profile.Name &&
                   ImagePath == profile.ImagePath &&
                   About == profile.About;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProfileId, Name, ImagePath, About);
        }
    }
}
