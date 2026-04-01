using System;
using System.Collections.Generic;
using System.Text;
using ComBravoControl.Domains.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace ComBravoControl.DataAccess.Context
{
    public class UserContext : DbContext
    {
        public DbSet<UserData> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionString);
        }
    }
}
