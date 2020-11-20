using Forum.Database;
using Forum.Exceptions;
using Forum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Forum.Repositories.Implementations
{
    public class TopicRepository : ITopicRepository
    {
        private readonly ForumDbContext context;

        public TopicRepository(ForumDbContext forumDbContext)
        {
            this.context = forumDbContext;
        }

        public Topic Create(Topic item)
        {
            context.Topic.Add(item);
            context.SaveChanges();
            return item;
        }

        public Topic Read(int key)
        {
            Topic result = context.Topic.Find(key);
            if (result == null)
            {
                throw new TopicNotFoundException("Topic with id " + key + " not found");
            }
            return result;
        }

        public void Update(Topic item)
        {
            context.Entry(item).State = EntityState.Modified;
        }


        public void Delete(int key)
        {
            Topic result = context.Topic.Find(key);
            if (result == null)
            {
                throw new TopicNotFoundException("Topic with id " + key + " not found");
            }
            context.Topic.Remove(result);
        }

        public ICollection<Topic> FindAll()
        {
            return context.Topic.ToList();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Topic FindByName(string name)
        {
            return context.Topic.First(topic => topic.Name.Equals(name));
        }
    }
}
