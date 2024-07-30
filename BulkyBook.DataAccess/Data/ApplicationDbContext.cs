using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action" ,DisplayOrder = 21},
                new Category { Id = 2, Name = "Sci-Fi" ,DisplayOrder = 22},
                new Category { Id = 3, Name = "Horror" ,DisplayOrder = 23}
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Fortune Of Time",
                    Author = "Billy Spark",
                    Description = "King is time, time is everything, you are bound to time, and time is eternal. Nothing else is true!",
                    ISBN = "SWD00785",
                    ListPrice = 99,
                    Price1 = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = ""

                },
                new Product
                {
                    Id = 2,
                    Title = "Echoes of Destiny",
                    Author = "Maya Rivers",
                    Description = "In a world where choices echo through time, three lives intertwine, revealing their shared destiny.",
                    ISBN = "EOD12345",
                    ListPrice = 120,
                    Price1 = 110,
                    Price50 = 105,
                    Price100 = 100,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 3,
                    Title = "Whispers in the Mist",
                    Author = "Olivia Gray",
                    Description = "Amidst fog-shrouded secrets, a forbidden love blooms, threatening to unravel the town's hidden past.",
                    ISBN = "WIM67890",
                    ListPrice = 80,
                    Price1 = 75,
                    Price50 = 70,
                    Price100 = 65,
                    CategoryId = 6,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 4,
                    Title = "The Alchemist's Legacy",
                    Author = "Sebastian Stone",
                    Description = "Alchemy, betrayal, and ancient prophecies collide as an unlikely hero seeks the philosopher's stone.",
                    ISBN = "TAL45678",
                    ListPrice = 105,
                    Price1 = 95,
                    Price50 = 90,
                    Price100 = 85,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 5,
                    Title = "Sands of Serendipity",
                    Author = "Isabella Sands",
                    Description = "Lost artifacts, hidden maps, and a quest for serendipity lead a group of adventurers across deserts and time.",
                    ISBN = "SOS23456",
                    ListPrice = 70,
                    Price1 = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId = 4,
                    ImageUrl = ""
                }
                );
        }
    }
}
