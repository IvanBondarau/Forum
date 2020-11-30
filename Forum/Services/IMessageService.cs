using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services
{
    public interface IMessageService: ICrudService<int, Message>
    {
        ICollection<Message> FindByTopicId(int topicId, int? page);
        Message Create(int topicId, int authorId, string Text);
        public int CountPages();
    }
}
