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

            modelBuilder.Entity<User>()
                .HasMany(u => u.Featured)
                .WithMany(t => t.FeaturedUsers)
                .UsingEntity(j => j.ToTable("UserFeaturedTopics"));

            modelBuilder.Entity<User>()
               .HasMany(u => u.Likes)
               .WithMany(m => m.Likes)
               .UsingEntity(j => j.ToTable("MessageLikes"));

            modelBuilder.Entity<User>()
               .HasMany(u => u.Roles)
               .WithMany(r => r.Users)
               .UsingEntity(j => j.ToTable("UserRoles"));

            modelBuilder.Entity<Message>()
               .HasOne(m => m.Author)
               .WithMany();
               

            modelBuilder.Entity<Topic>()
                .HasOne(t => t.Author)
                .WithMany();
            modelBuilder.Entity<Topic>()
                .HasMany(t => t.Labels)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Topic)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Label> Label { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
