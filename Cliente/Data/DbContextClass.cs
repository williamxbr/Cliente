﻿using Microsoft.EntityFrameworkCore;
using Cliente.Model;

namespace Cliente.Data
{
    public class DbContextClass: DbContext
    {
        protected readonly IConfiguration _configuration;
        public DbContextClass(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")); 
        }

        public DbSet<Client> Clients { get; set; }
    }
}
