using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public User Author { get; set; }
        public DateTime Created { get; set; }

        public Message(string text = null,
                       User author = null)
        {
            Text = text;
            Author = author;
            Created = DateTime.Now;
        }

        public override string ToString()
            => JsonSerializer.Serialize(this);
    }
}
