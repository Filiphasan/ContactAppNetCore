using ContactApp.API.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Data.Configurations
{
    public class ContactInfoConfiguration : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Key).IsRequired();
            builder.Property(ci => ci.Key).HasMaxLength(100);
            builder.Property(ci => ci.Value).IsRequired();
            builder.Property(ci => ci.Value).HasMaxLength(200);
            builder.Property(ci => ci.IsDeleted).HasDefaultValue(false);
            builder.HasOne<Contact>(ci => ci.Contact).WithMany(ci => ci.ContactInfos).HasForeignKey(ci => ci.ContactId).OnDelete(DeleteBehavior.Cascade);
            //builder.HasIndex(ci => new { ci.ContactId, ci.Key }).IsUnique();
        }
    }
}
