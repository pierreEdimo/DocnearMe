﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using userVoice.Model;

namespace userVoice.DBContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DatabaseContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasMany(c => c.Items).WithOne(a => a.Category).HasForeignKey(a => a.CategoryId);

            modelBuilder.Entity<Item>().HasOne(a => a.Category).WithMany(a => a.Items);

            modelBuilder.Entity<Item>().HasMany(a => a.Reviews).WithOne(a => a.Item).HasForeignKey(a => a.ItemId);

            modelBuilder.Entity<Review>().HasOne(a => a.Item).WithMany(a => a.Reviews);

            modelBuilder.Entity<Review>().HasMany(a => a.Comments).WithOne(a => a.Review).HasForeignKey(a => a.ReviewId);

            modelBuilder.Entity<Comment>().HasOne(a => a.Review).WithMany(a => a.Comments);

            modelBuilder.Seed(); 
       
        }


        public DbSet<Item> items { get; set; }
        public DbSet<Category> categories { get; set;  }
        public DbSet<Review> reviews { get; set;  }
        public DbSet<Comment> comments { get; set;  }
      
    }
}