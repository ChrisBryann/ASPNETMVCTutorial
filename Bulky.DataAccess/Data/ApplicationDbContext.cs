﻿using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext // anything we have to do with database, we do it here
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category {Id=1, Name="Action", DisplayOrder=1},
                new Category {Id=2, Name="SciFi", DisplayOrder=2},
                new Category {Id=3, Name="History", DisplayOrder=3}
            );
        }

    }
}