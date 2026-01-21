using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Persistence.Configurations
{
    public class CalendarEventConfiguration : IEntityTypeConfiguration<CalendarEvent>
    {
        public void Configure(EntityTypeBuilder<CalendarEvent> builder)
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
            
            //Begin date.
            builder.Property(x => x.BeginDate)
                .IsRequired(true);

            //End date.
            builder.Property(x => x.EndDate)
                .IsRequired(true);

            //Event type.
            builder.Property(x => x.Type)
                .IsRequired(true);
            
            //Foreign key referencing on owner user.
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.OwnerUserId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}