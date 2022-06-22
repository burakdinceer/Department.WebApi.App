using Department.WebApi.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Department.WebApi.App.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) 
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Work> works { get; set; }
        public DbSet<Person> people { get; set; }

    }
}
