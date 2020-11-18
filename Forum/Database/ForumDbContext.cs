using Forum.Models;
using Microsoft.EntityFrameworkCore;


namespace Forum.Database
{
    public class ForumDbContext: DbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options)
            : base(options)
        {
        }
        public DbSet<Label> Label { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Profile> Profile { get; set; }
    }
}
