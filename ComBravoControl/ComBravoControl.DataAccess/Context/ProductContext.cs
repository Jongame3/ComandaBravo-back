using Microsoft.EntityFrameworkCore;
using ComBravo.Domains.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravo.DataAccess.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductData> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionString);
        }
    }
}
