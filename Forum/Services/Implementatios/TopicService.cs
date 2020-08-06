using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Services.Implementations
{
    public class TopicService : ITopicService
    {
        private readonly IList<Topic> _topics;

        public TopicService()
        {
            _topics = new List<Topic>
            {
                new Topic("Test 1", "Test topic 1", section: new Section("a")),
                new Topic("Test 2", "Test topic 2", section: new Section("a")),
                new Topic("Test 3", "Test topic 3", section: new Section("b"))
            };
        }

        public Topic AddTopic(Topic topic)
        {
            _topics.Add(topic);
            return topic;
        }

        public IList<Topic> GetTopicsBySection(Section section)
        {
            return (from topic in _topics
                    where topic.Section.Equals(section)
                    select topic).ToList();
        }

        public IList<Topic> GetTopics()
        {
            return _topics;
        }
    }
}
