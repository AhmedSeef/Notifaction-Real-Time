using Microsoft.EntityFrameworkCore;
using Notifaction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notifaction.DB
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Patient> patient { get; set; }
        public DbSet<Doctor> doctor { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<Notification> notification { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
