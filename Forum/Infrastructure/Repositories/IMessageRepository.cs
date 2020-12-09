using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Repositories
{
    public interface IMessageRepository: ICrudRepository<int, Message>
    {
        ICollection<Message> FindByTopicId(int topicId, int pageNumber, int pageSize);
        public int Count();
    }
}
