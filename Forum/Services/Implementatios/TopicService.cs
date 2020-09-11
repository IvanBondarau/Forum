using Forum.Models;
using Forum.Services.Implementatios;
using System.Collections.Generic;
using System.Linq;

namespace Forum.Services.Implementations
{
    public class TopicService 
        : InMemoryCrudService<Topic>, ITopicService
    {

        public TopicService()
            : base()
        {
            _items.Add(new Topic("Test 1", "Test topic 1", section: new Section("a")));
            _items.Add(new Topic("Test 2", "Test topic 2", section: new Section("a")));
            _items.Add(new Topic("Test 3", "Test topic 3", section: new Section("b")));
        }

       

        public ICollection<Topic> FindBySection(Section section)
        {
            return (from topic in _items
                    where topic.Section.Equals(section)
                    select topic).ToList();
        }

        public Topic FindByName(string name)
        {
            return (from topic in _items
                    where topic.Name.Equals(name)
                    select topic).FirstOrDefault();
        }
    }
}
