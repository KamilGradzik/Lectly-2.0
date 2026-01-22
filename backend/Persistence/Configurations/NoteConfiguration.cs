using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Persistence.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            //Id.
            builder.HasKey(x => x.Id);

            //Name.
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired(true);
            
            //Content.
            builder.Property(x => x.Content)
                .HasMaxLength(500)
                .IsRequired(true);
            
            //Creation date.
            builder.Property(x => x.CreatedAt);
                // .HasDefaultValue(DateTime.Now);

            //Foreign Key referencing on owner user.
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.OwnerUserId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}