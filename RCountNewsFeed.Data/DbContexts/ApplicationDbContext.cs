using Microsoft.EntityFrameworkCore;
using RCountNewsFeed.API.Models;
using RCountNewsFeed.Models;

namespace RCountNewsFeed.API.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<News> News { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                CategoryName = "Updates"
            },
            new Category
            {
                Id = 2,
                CategoryName = "Security"
            },
            new Category
            {
                Id = 3,
                CategoryName = "Releases"
            },
            new Category
            {
                Id = 4,
                CategoryName = "Events"
            },
            new Category
            {
                Id = 5,
                CategoryName = "Guides"
            }
        );

        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id = 1,
                ProjectName = "RCount",
                ProjectUrl = "rti.md"
            });
    }
}