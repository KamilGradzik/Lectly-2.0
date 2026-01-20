using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace backend.Persistence.Configurations
{
    public class GroupSubjectConfiguration : IEntityTypeConfiguration<GroupSubject>
    {
        public void Configure(EntityTypeBuilder<GroupSubject> builder)
        {
            //Unique Id based on Group and Subject IDs.
            builder.HasKey(x => new {x.GroupId, x.SubjectId});

            //Many to Many relation between subjects and  groups.
            //Foreign Key referencing group.
            builder.HasOne<Group>()
                .WithMany()
                .HasForeignKey(x => x.GroupId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            //Foreign Key referencing subject.
            builder.HasOne<Subject>()
                .WithMany()
                .HasForeignKey(x => x.SubjectId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}