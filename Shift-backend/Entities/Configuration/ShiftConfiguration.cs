using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities
{
    public class ShiftConfiguration : IEntityTypeConfiguration<Shift>
    {

        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.HasData
            (
                new Shift
                {
                    Id = "c9d4c053-49b6-410c-bc78-2d54a9991870",
                    Date = new DateTime(2015, 12, 25),
                    StartAt = "2",
                    EndAt = "3",
                    StaffName = "Khoi"
                }
            );
        }

    }
}
