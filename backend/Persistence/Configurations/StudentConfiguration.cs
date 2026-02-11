using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Persistence.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
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
            
            //Additional informations.
            builder.Property(x => x.AdditionalInfo)
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