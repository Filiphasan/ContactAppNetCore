using ContactApp.API.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Data.Seeds
{
    public class ContactInfoSeeds : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder.HasData(new ContactInfo
            {
                Id = 1,
                ContactId = "e96bb9b2-0d70-4c8f-8344-20872e24010c",
                Key = "Telefon Numarası",
                Value = "+90 537 035 2059",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            }, new ContactInfo
            {
                Id = 2,
                ContactId = "e96bb9b2-0d70-4c8f-8344-20872e24010c",
                Key = "E-Mail Adresi",
                Value = "hasaerda@hotmail.com",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            }, new ContactInfo
            {
                Id = 3,
                ContactId = "e96bb9b2-0d70-4c8f-8344-20872e24010c",
                Key = "Konum",
                Value = "Şahinbey/Gaziantep",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            }, new ContactInfo
            {
                Id = 4,
                ContactId = "06aa8dd6-12b2-45f0-9087-222889639d1c",
                Key = "Telefon Numarası",
                Value = "+90 537 035 2059",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            }, new ContactInfo
            {
                Id = 5,
                ContactId = "06aa8dd6-12b2-45f0-9087-222889639d1c",
                Key = "E-Mail Adresi",
                Value = "hasaerda@hotmail.com",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            }, new ContactInfo
            {
                Id = 6,
                ContactId = "06aa8dd6-12b2-45f0-9087-222889639d1c",
                Key = "Konum",
                Value = "Şahinbey/Gaziantep",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            }, new ContactInfo
            {
                Id = 7,
                ContactId = "13539989-0439-4698-b694-ad6a8e65d5ab",
                Key = "Telefon Numarası",
                Value = "+90 537 035 2059",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            }, new ContactInfo
            {
                Id = 8,
                ContactId = "13539989-0439-4698-b694-ad6a8e65d5ab",
                Key = "E-Mail Adresi",
                Value = "hasaerda@hotmail.com",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            }, new ContactInfo
            {
                Id = 9,
                ContactId = "13539989-0439-4698-b694-ad6a8e65d5ab",
                Key = "Konum",
                Value = "Şehitkamil/Gaziantep",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            });
        }
    }
}
