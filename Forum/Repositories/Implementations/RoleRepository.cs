using Forum.Database;
using Forum.Models;
using Forum.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Repositories.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ForumDbContext context;

        public RoleRepository(ForumDbContext forumDbContext)
        {
            this.context = forumDbContext;
        }

        public Role FindByName(string name)
        {
            return context.Role.First(r => r.Name.Equals(name));
        }
    }
}
