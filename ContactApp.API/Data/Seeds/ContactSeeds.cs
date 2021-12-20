using ContactApp.API.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Data.Seeds
{
    public class ContactSeeds : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasData(new Contact
            {
                Id = "e96bb9b2-0d70-4c8f-8344-20872e24010c",
                FirstName = "Hasan",
                LastName = "Erdal",
                Firm = "Rise Consulting",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            }, new Contact
            {
                Id = "06aa8dd6-12b2-45f0-9087-222889639d1c",
                FirstName = "Mehmet",
                LastName = "Erdal",
                Firm = "No Firm",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            }, new Contact
            {
                Id = "13539989-0439-4698-b694-ad6a8e65d5ab",
                FirstName = "Mustafa",
                LastName = "Erdal",
                Firm = "No Firm",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            });
        }
    }
}
