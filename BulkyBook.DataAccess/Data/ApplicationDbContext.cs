﻿using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action" ,DisplayOrder = 21},
                new Category { Id = 2, Name = "Sci-Fi" ,DisplayOrder = 22},
                new Category { Id = 3, Name = "Horror" ,DisplayOrder = 23}
                );
        }
    }
}
