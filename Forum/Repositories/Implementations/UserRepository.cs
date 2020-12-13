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
    public class UserRepository : IUserRepository
    {
        private readonly ForumDbContext context;

        public UserRepository(ForumDbContext forumDbContext)
        {
            this.context = forumDbContext;
        }

        public User Create(User item)
        {
            context.User.Add(item);
            context.SaveChanges();
            return item;
        }

        public User Read(int key)
        {
            User result = context.User.Include(u => u.Profile).Include(u => u.Roles).FirstOrDefault(u => u.UserId == key);
            if (result == null)
            {
                throw new BusinessException(ErrorCode.USER_NOT_FOUND);
            }
            return result;
        }

        public void Update(User item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }


        public void Delete(int key)
        {
            User result = context.User.Find(key);
            if (result == null)
            {
                throw new BusinessException(ErrorCode.USER_NOT_FOUND);
            }
            context.User.Remove(result);
        }

        public ICollection<User> FindAll()
        {
            return context.User.Include(u => u.Profile).ToList();
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

        public User FindByUsername(string username)
        {
            return context.User
                .Include(u => u.Profile)
                .Include(u => u.Roles)
                .Include(u => u.Featured)
                .FirstOrDefault(user => user.Username == username);
        }
    }
}
