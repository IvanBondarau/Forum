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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId);
        }

        public DbSet<Label> Label { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Profile> Profile { get; set; }
    }
}
