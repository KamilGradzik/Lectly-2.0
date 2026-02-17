using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Persistence.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            //Id.
            builder.HasKey(x => x.Id);

            //Name.
            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(100);
            
            //Description.
            builder.Property(x => x.Desc)
                .HasMaxLength(300);

            //Foreign Key referencing on owner user.
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.OwnerUserId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}