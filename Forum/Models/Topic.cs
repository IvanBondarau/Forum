using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Forum.Models
{
    public class Topic
    {
        public int TopicId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        public User Author { get; set; }

        public ICollection<Label> Labels { get; set; }
        public ICollection<User> FeaturedUsers { get; set; }

        public Topic()
        {

        }

        public Topic(string name = null,
                     string description = null,
                     ICollection<Label> labels = null,
                     User user = null)
        {
            Author = user;
            Name = name;
            Description = description;
            Labels = labels;
            Created = DateTime.Now;
        }

        public override string ToString()
            => JsonSerializer.Serialize(this);

        public override bool Equals(object obj)
        {
            return obj is Topic topic &&
                   TopicId == topic.TopicId &&
                   Name == topic.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TopicId, Name);
        }
    }
}
