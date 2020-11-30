using Forum.Database;
using Forum.Exceptions;
using Forum.Models;
using Microsoft.EntityFrameworkCore;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

        public ICollection<Topic> FindPage(int pageNumber, int pageSize)
        {
            return context.Topic.Include(t => t.Author).Include(t => t.Labels).ToPagedList(pageNumber, pageSize).ToList<Topic>();
        }

        public ICollection<Topic> Find(string name, ICollection<Label> labels, int pageNumber, int pageSize)
        {

            Regex regex = new Regex(".*" + name + ".*");
            return context.Topic.Include(t => t.Author).Include(t => t.Labels)
                 .AsEnumerable()
                 .Where(t => regex.IsMatch(t.Name) && labels.All(label => t.Labels.Any(tlabel => tlabel.Name.Equals(label.Name))))
                 .ToPagedList(pageNumber, pageSize).ToList();
        }

        public ICollection<Topic> FindFeatured(string username, int pageNumber, int pageSize)
        {
            return context.Topic.Include(t => t.FeaturedUsers).Include(t => t.Labels)
                .Where(t => t.FeaturedUsers.Any(u => u.Username.Equals(username)))
                .ToPagedList(pageNumber, pageSize)
                .ToList();
        }

        public int Count()
        {
            return context.Topic.Count();
        }
    }
}
