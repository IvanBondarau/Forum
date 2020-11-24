using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Repositories
{
    public interface ITopicRepository: ICrudRepository<int, Topic>
    {
        Topic FindByName(string name);
        ICollection<Topic> FindPage(int pageNumber, int pageSize);
        ICollection<Topic> FindTopics(string name, ICollection<Label> labels, int pageNumber, int pageSize);
    }
}
