using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public User Author { get; set; }
        public DateTime Created { get; set; }
        public IList<Message> Messages { get; set; }

        public Topic(string name = null, 
                     string description = null, 
                     User author = null)
        {
            Name = name;
            Description = description;
            Author = author;
            Messages = new List<Message>();
            Created = DateTime.Now;
        }

        public override string ToString()
            => JsonSerializer.Serialize(this);
    }
}
