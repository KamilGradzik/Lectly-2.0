using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Persistence.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {   
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            //Id.
            builder.HasKey(x => x.Id);

            //Value.
            builder.Property(x => x.Value)
                .HasPrecision(3,2)
                .IsRequired(true);
            
            //Weight.
            builder.Property(x => x.Weight)
                .HasPrecision(4,2)
                .IsRequired(true);

            //Description.
            builder.Property(x => x.Desc)
                .HasMaxLength(300)
                .IsRequired(true);
            
            //Date issued.
            builder.Property(x => x.DateIssued)
                .IsRequired(true);
            
            //Foreign key referencing subject.
            builder.HasOne<Subject>()
                .WithMany()
                .HasForeignKey(x => x.SubjectId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            
            //Foreign key referencing student.
            builder.HasOne<Student>()
                .WithMany()
                .HasForeignKey(x => x.StudentId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.OwnerUserId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}