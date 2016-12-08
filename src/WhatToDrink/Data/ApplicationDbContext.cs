using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WhatToDrink.Models;

namespace WhatToDrink.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

            public DbSet<Beer> Beer { get; set; }
            public DbSet<ABV> ABV { get; set; }
            public DbSet<Feeling> Feeling { get; set; }
            public DbSet<Season> Season { get; set; }
            public DbSet<Style> Style { get; set; }
            public DbSet<TypeOfDay> TypeOfDay { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Beer>()
               .Property(b => b.DateCreated)
               .HasDefaultValueSql("getdate()");

            builder.Entity<ABV>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getdate()");

            builder.Entity<Feeling>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getdate()");
            builder.Entity<Season>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getdate()");

            builder.Entity<Style>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getdate()");
            builder.Entity<TypeOfDay>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getdate()");

            
        }
    }
}
