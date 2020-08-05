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
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string About { get; set; }

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
    }
}
