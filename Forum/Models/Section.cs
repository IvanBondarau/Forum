using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Topic> Topics { get; set; }

        public Section(string name)
        {
            Name = name;
            Topics = new List<Topic>();
        }
        
        public override string ToString()
            => JsonSerializer.Serialize(this);
    }
}
