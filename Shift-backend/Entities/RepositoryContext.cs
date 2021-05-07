using System;
using System.Collections.Generic;
using System.Text;
using Entities.Configuration;
using Entities.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Entities
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*modelBuilder.ApplyConfiguration(new ShiftConfiguration());*/
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.Entity<User>()
               .HasMany(u => u.WorkingDates)
               .WithOne(d => d.User);

            modelBuilder.Entity<User>()
               .HasMany(u => u.Shifts)
               .WithOne(d => d.User);
        }



        public DbSet<Shift> Shifts { get; set; }
        public override DbSet<User> Users { get; set; }
        public DbSet<Notification> Notifications{ get; set; }
        public DbSet<WorkingDate> WorkingDates { get; set; }

       
    }
}
