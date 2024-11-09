﻿using Microsoft.EntityFrameworkCore;
using Pustok.Core.Entities;

namespace Pustok.DAL.DataContexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<TagProduct> TagProducts { get; set; }


    }
}
