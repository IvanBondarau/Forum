using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.ViewModel
{
    public class MessageListViewModel
    {
        public Topic Topic { get; set; }
        public User User { get; set; }
        public ICollection<Message> Messages { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }

        public MessageListViewModel(Topic topic, ICollection<Message> messages, User user, int pageNumber, int totalPages)
        {
            PageNumber = pageNumber;
            Topic = topic;
            User = user;
            Messages = messages;
            TotalPages = totalPages;
        }
    }
}
