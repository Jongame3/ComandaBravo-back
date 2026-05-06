using ComBravo.Domains.Entities.Appointment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravo.DataAccess.Context
{
    public class AppointmentContext : DbContext
    {

        public DbSet<AppointmentData> Appointments {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionString);
        }
    }
}
