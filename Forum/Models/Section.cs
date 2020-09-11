using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Section: BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Topic> Topics { get; set; }

        public Section(string name)
        {
            Name = name;
            Topics = new List<Topic>();
        }
        
        public override string ToString()
            => JsonSerializer.Serialize(this);

        public override bool Equals(object obj)
        {
            return obj is Section section &&
                   Id == section.Id &&
                   Name == section.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}
