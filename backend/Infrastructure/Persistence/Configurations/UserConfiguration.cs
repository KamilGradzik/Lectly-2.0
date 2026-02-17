using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Id.
            builder.HasKey(x => x.Id);

            //First Name.
            builder.Property(x => x.FirstName)
                .HasMaxLength(100)
                .IsRequired(true);

            //Last Name.
            builder.Property(x => x.LastName)
                .HasMaxLength(100)
                .IsRequired(true);
            
            //Email.
            builder.Property(x => x.Email)
                .HasMaxLength(255)
                .IsRequired(true);
            builder.HasIndex(x => x.Email)
                .IsUnique(true);

            //Password.
            builder.Property(x => x.Password)
                .HasMaxLength(128)
                .IsRequired(true);
            
            //Is Active.
            builder.Property(x => x.IsActive)
                .IsRequired(true)
                .HasDefaultValue(false);
                
        }
    }
}