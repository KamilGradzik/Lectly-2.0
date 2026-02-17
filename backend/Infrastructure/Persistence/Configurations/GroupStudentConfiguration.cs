using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Persistence.Configurations
{
    public class GroupStudentConfiguration : IEntityTypeConfiguration<GroupStudent>
    {
        public void Configure(EntityTypeBuilder<GroupStudent> builder)
        {
            //Unique Id based on group's Id and student's Id.
            builder.HasKey(x => new {x.GroupId, x.StudentId});
            
            //Many to Many relation between subjects and groups.
            //Foreign Key referencing group.
            builder.HasOne<ClassGroup>()
                .WithMany()
                .HasForeignKey(x => x.GroupId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            
            //Foreign Key referencing student.
            builder.HasOne<Student>()
                .WithMany()
                .HasForeignKey(x => x.StudentId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}