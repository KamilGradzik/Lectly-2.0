using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Persistence.Configurations
{
    public class ClassSessionConfiguration : IEntityTypeConfiguration<ClassSession>
    {
        public void Configure(EntityTypeBuilder<ClassSession> builder)
        {
            //Id.
            builder.HasKey(x => x.Id);

            //Day of the week.
            builder.Property(x => x.DayOfWeek)
                .IsRequired(true);
            
            //Start time.
            builder.Property(x => x.StartTime)
                .IsRequired(true);
            
            //End time.
            builder.Property(x => x.EndTime)
                .IsRequired(true);

            //Classrom.
            builder.Property(x => x.Classroom)
                .HasMaxLength(100)
                .IsRequired(true);
            
            //Foreign key referencing subject.
            builder.HasOne<Subject>()
                .WithMany()
                .HasForeignKey(x => x.SubjectId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
            
            //Foreign key referencing group.
            builder.HasOne<Group>()
                .WithMany()
                .HasForeignKey(x => x.GroupId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}