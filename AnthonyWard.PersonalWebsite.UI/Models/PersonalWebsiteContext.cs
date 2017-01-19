using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AnthonyWard.PersonalWebsite.UI.Models
{
    public class PersonalWebiteContext : DbContext
    {
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Ramble> Rambles { get; set; }

        public DbSet<Media> Medias { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // these are so I can use my own database schema
            modelBuilder.Entity<Forum>().ToTable("Forums", "Forum");
            modelBuilder.Entity<Thread>().ToTable("Threads", "Forum");
            modelBuilder.Entity<Post>().ToTable("Posts", "Forum");

            modelBuilder.Entity<User>().ToTable("Users", "Domain");

            modelBuilder.Entity<Comment>().ToTable("Comments", "Website");
            modelBuilder.Entity<Tag>().ToTable("Tags", "Website");
            modelBuilder.Entity<Ramble>().ToTable("Rambles", "Website");

            modelBuilder.Entity<Media>().ToTable("Medias", "Data");
            modelBuilder.Entity<MediaType>().ToTable("MediaTypes", "Data");
        }
    }
}