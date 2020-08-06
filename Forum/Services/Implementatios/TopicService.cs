using Forum.Exceptions;
using Forum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
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

        public Topic Create(Topic topic)
        {
            _topics.Add(topic);
            return topic;
        }

        public Topic Read(int id)
        {
            Topic searchResult =  (from topic in _topics
                                    where topic.Id.Equals(id)
                                    select topic).First();
            if (searchResult == null)
            {
                throw new EntityNotFoundException();
            }

            return searchResult;
        }

        public void Update(Topic item)
        {
            var removed = from topic in _topics
            where topic.Id == item.Id
            select topic;
            foreach (var removeItem in removed)
            {
                _topics.Remove(removeItem);
            }

            _topics.Add(item);
        }

         
        public void Delete(int id)
        {
            Topic searchResult = (from topic in _topics
                                  where topic.Id.Equals(id)
                                  select topic).First();
            if (searchResult == null)
            {
                throw new EntityNotFoundException();
            }

            _topics.Remove(searchResult);
        }

        public ICollection<Topic> FindAll()
        {
            return _topics;
        }

        public ICollection<Topic> FindBySection(Section section)
        {
            return (from topic in _topics
                    where topic.Section.Equals(section)
                    select topic).ToList();
        }

        public Topic FindByName(string name)
        {
            return (from topic in _topics
                    where topic.Name.Equals(name)
                    select topic).FirstOrDefault();
        }
    }
}
