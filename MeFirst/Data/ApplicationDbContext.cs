using MeFirst.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeFirst.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        // make global references to our models for use with our DB connection
        public DbSet<Browse> Browses { get; set; }
        public DbSet<SkinType> SkinTypes { get; set; }
        public DbSet<Treatments> Treatments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    }
}
