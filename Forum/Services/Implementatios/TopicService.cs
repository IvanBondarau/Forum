using Forum.Models;
using Forum.Repositories;
using Forum.Services.Implementatios;
using System.Collections.Generic;
using System.Linq;

namespace Forum.Services.Implementations
{
    public class TopicService 
        : AbstractCrudService<int, Topic>, ITopicService
    {

        private readonly ITopicRepository topicRepository;

        public TopicService(ITopicRepository topicRepository)
            : base(topicRepository)
        {
            this.topicRepository = topicRepository;
        }

        public Topic FindByName(string name)
        {
            return this.topicRepository.FindByName(name);
        }
    }
}
