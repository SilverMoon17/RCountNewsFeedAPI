﻿using Microsoft.EntityFrameworkCore;
using RCountNewsFeedAPI.Models;

namespace RCountNewsFeedAPI.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<News> News { get; set; }
    public DbSet<Category> Categories { get; set; }

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

    }
}