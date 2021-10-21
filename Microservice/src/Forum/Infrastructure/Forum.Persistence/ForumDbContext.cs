using Common.Services.Entities;
using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Persistence
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options)
            : base(options)
        {

        }
        public DbSet<ForumEntity> Forums { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostReply> PostReplies { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForumDbContext).Assembly);

            var forumId = Guid.Parse("{f25932d0-20a1-4e02-90b5-b1d83009efb5}");
            var forumId2 = Guid.Parse("{f25932d1-21a1-4e12-91b5-b1d83019efb5}");


            modelBuilder.Entity<ForumEntity>().HasData(new ForumEntity
            {
                Id = forumId,
                Title = "C#",
                Description = "Object oriented programming (OOP)"
            });
            modelBuilder.Entity<ForumEntity>().HasData(new ForumEntity
            {
                Id = forumId2,
                Title = "Quasar",
                Description = "Vue js framework"
            });

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedAt = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
