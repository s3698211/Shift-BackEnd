using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    class NotificationConfiguration  : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasData
            (
                new Notification
                {
                    Id = "80abbca8-664d-4b20-b5de-024705497d4a",
                    Message = "Shift allocated",

                }
            );
        }
    }
}
