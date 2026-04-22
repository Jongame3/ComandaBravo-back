using System;
using System.Collections.Generic;
using System.Text;
using ComBravo.Domains.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace ComBravo.DataAccess.Context
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
