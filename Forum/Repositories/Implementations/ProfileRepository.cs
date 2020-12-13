using Forum.Database;
using Forum.Exceptions;
using Forum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Repositories.Implementations
{
    public class ProfileRepository: IProfileRepository
    {
        private readonly ForumDbContext context;

        public ProfileRepository(ForumDbContext forumDbContext)
        {
            this.context = forumDbContext;
        }

        public Profile Create(Profile item)
        {
            context.Profile.Add(item);
            context.SaveChanges();
            return item;
        }

        public Profile Read(int key)
        {
            Profile result = context.Profile.Find(key);
            if (result == null)
            {
                throw new BusinessException(ErrorCode.USER_NOT_FOUND);
            }
            return result;
        }

        public void Update(Profile item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }


        public void Delete(int key)
        {
            Profile result = context.Profile.Find(key);
            if (result == null)
            {
                throw new BusinessException(ErrorCode.USER_NOT_FOUND);
            }
            context.Profile.Remove(result);
        }

        public ICollection<Profile> FindAll()
        {
            return context.Profile.ToList();
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
    }
}
