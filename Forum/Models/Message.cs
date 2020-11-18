using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public Topic Topic { get; set; }
        public User Author { get; set; }

        public Message()
        {

        }

        public Message(string text = null,
                       User author = null,
                       Topic topic = null)
        {
            Text = text;
            Author = author;
            Created = DateTime.Now;
            this.Topic = topic;
        }

        public override string ToString()
            => JsonSerializer.Serialize(this);

        public override bool Equals(object obj)
        {
            return obj is Message message &&
                   MessageId == message.MessageId &&
                   Text == message.Text &&
                   EqualityComparer<User>.Default.Equals(Author, message.Author) &&
                   Created == message.Created &&
                   EqualityComparer<Topic>.Default.Equals(Topic, message.Topic);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(MessageId, Text, Author, Created, Topic);
        }
    }
}
