using Microsoft.EntityFrameworkCore;
using ComBravo.Domains.Entities.Pet;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravo.DataAccess.Context
{
    public class PetContext : DbContext
    {
        public DbSet<PetData> Pets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionString);
        }
    }
}
