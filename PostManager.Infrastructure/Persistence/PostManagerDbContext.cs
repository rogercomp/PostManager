using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostManager.Core.Entities;

namespace PostManager.Infrastructure.Persistence
{
    public class PostManagerDbContext: DbContext
    {

        public PostManagerDbContext(DbContextOptions<PostManagerDbContext> options): base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasKey(e => e.Id);
        }
    }
}
