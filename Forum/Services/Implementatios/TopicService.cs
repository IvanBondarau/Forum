using Forum.Constants;
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

        public ICollection<Topic> FindPage(int? pageNumber)
        {
            return topicRepository.FindPage(
                pageNumber == null ? 1 : (int)pageNumber,
                ApplicationConstants.TOPIC_PAGE_SIZE
            );
        }

        public Topic FindByName(string name)
        {
            return this.topicRepository.FindByName(name);
        }

        public ICollection<Topic> FindTopics(string name, ICollection<Label> labels, int? pageNumber)
        { 
            var cleanedName = name == null ? "" : name;
            var cleanedLabels = labels == null ? new List<Label>() : labels;
            return this.topicRepository.FindTopics(cleanedName, cleanedLabels, pageNumber == null ? 1 : (int)pageNumber, ApplicationConstants.TOPIC_PAGE_SIZE);
        }
    }
}
