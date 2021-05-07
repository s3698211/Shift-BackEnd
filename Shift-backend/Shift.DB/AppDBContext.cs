using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shifts.DB
{
    public class AppDBContext : DbContext
    {
        public DbSet<Shift> Shifts { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Shift;Integrated Security=True");
        }
    }
}
