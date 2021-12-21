using ContactApp.API.Data.Configurations;
using ContactApp.API.Data.Model;
using ContactApp.API.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Data
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options):base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new ContactInfoConfiguration());
            modelBuilder.ApplyConfiguration(new ContactSeeds());
            modelBuilder.ApplyConfiguration(new ContactInfoSeeds());
            base.OnModelCreating(modelBuilder);
        }
    }
}
