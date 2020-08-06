using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services
{
    public interface ITopicService : ICrudService<Topic, int>
    {
        Topic FindByName(string name);
        ICollection<Topic> FindBySection(Section section);
    }
}
