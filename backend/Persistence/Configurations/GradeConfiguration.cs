using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Persistence.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {   
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            //Id.
            builder.HasKey(x => x.Id);

            //Value.
            builder.Property(x => x.Value)
                .IsRequired(true);
            
            //Weight.
            builder.Property(x => x.Weight)
                .IsRequired(true);

            //Description.
            builder.Property(x => x.Desc)
                .HasMaxLength(300)
                .IsRequired(true);
            
            //Date issued.
            builder.Property(x => x.DateIssued)
                .HasDefaultValue(DateTime.Now)
                .IsRequired(true);
            
            //Foreign key referencing subject.
            builder.HasOne<Subject>()
                .WithMany()
                .HasForeignKey(x => x.SubjectId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
            
            //Foreign key referencing student.
            builder.HasOne<Student>()
                .WithMany()
                .HasForeignKey(x => x.StudentId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}