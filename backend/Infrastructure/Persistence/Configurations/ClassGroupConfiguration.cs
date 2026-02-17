using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Persistence.Configurations
{
    public class ClassGroupConfiguration : IEntityTypeConfiguration<ClassGroup>
    {
        public void Configure(EntityTypeBuilder<ClassGroup> builder)
        {
            //Id.
            builder.HasKey(x => x.Id);

            //Name.
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired(true);
            
            //Description.
            builder.Property(x => x.Desc)
                .HasMaxLength(300);
            
            //Foreign key referencing on owner user.
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.OwnerUserId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}