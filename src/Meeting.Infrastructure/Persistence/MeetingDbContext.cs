using Meeting.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Meeting.Infrastructure.Persistence
{
    public sealed class MeetingDbContext : DbContext
    {
        // dotnet ef migrations add Initial_Create -p .\AwesomeBlog.Infrastructure\ -s .\AwesomeBlog.Api\ -o Persistence\Scripts

        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public MeetingDbContext(DbContextOptions<MeetingDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
