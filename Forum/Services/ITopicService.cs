using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services
{
    public interface ITopicService
    {
        IList<Topic> GetTopics();
        IList<Topic> GetTopicsBySection(Section section);
        Topic AddTopic(Topic topic);
    }
}
