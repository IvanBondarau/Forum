using Forum.Database;
using Forum.Exceptions;
using Forum.Models;
using Microsoft.EntityFrameworkCore;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Repositories.Implementations
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ForumDbContext context;

        public MessageRepository(ForumDbContext forumDbContext)
        {
            this.context = forumDbContext;
        }

        public Message Create(Message item)
        {
            context.Message.Add(item);
            context.SaveChanges();
            return item;
        }

        public Message Read(int key)
        {
            Message result = context.Message.Include(m => m.Likes).First(m => m.MessageId == key);
            if (result == null)
            {
                throw new BusinessException(ErrorCode.MESSAGE_NOT_FOUND);
            }
            return result;
        }

        public void Update(Message item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }


        public void Delete(int key)
        {
            Message result = context.Message.Find(key);
            if (result == null)
            {
                throw new BusinessException(ErrorCode.MESSAGE_NOT_FOUND);
            }
            context.Message.Remove(result);
            context.SaveChanges();
        }

        public ICollection<Message> FindAll()
        {
            return context.Message.Include(m => m.Author).Include(m => m.Likes).ToList();
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

        public ICollection<Message> FindByTopicId(int topicId, int pageNumber, int pageSize)
        {
            return context.Message
                .Include(m => m.Author)
                .ThenInclude(u => u.Profile)
                .Include(m => m.Topic)
                .Include(m => m.Likes)
                .OrderByDescending(m => m.Created)
                .Where(m => m.Topic.TopicId.Equals(topicId))
                .ToPagedList(pageNumber, pageSize)
                .ToList();
        }

        public int Count()
        {
            return context.Message.Count();
        }
    }
}
