using ContactApp.API.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FirstName).IsRequired();
            builder.Property(c => c.FirstName).HasMaxLength(35);
            builder.Property(c => c.LastName).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(35);
            builder.Property(c => c.Firm).IsRequired();
            builder.Property(c => c.Firm).HasMaxLength(150);
            builder.Property(c => c.IsDeleted).HasDefaultValue(false); 
            builder.Property(ci => ci.CreatedAt).HasDefaultValue(DateTime.UtcNow);
        }
    }
}
