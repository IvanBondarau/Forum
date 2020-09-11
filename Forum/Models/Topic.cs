﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Topic: BaseModel
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public User Author { get; set; }
        public DateTime Created { get; set; }
        public Section Section { get; set; }
        public IList<Message> Messages { get; set; }

        public Topic(string name = null, 
                     string description = null, 
                     User author = null,
                     Section section = null)
        {
            Name = name;
            Description = description;
            Author = author;
            Messages = new List<Message>();
            Created = DateTime.Now;
            Section = section;
        }

        public override string ToString()
            => JsonSerializer.Serialize(this);

        public override bool Equals(object obj)
        {
            return obj is Topic topic &&
                   Id == topic.Id &&
                   Name == topic.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}