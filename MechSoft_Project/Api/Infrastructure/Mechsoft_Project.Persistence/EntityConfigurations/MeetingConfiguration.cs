using Mechsoft_Project.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechsoft_Project.Persistence.EntityConfigurations
{
    public class MeetingConfiguration : BaseEntityConfiguration<Meeting>
    {
        public override void Configure(EntityTypeBuilder<Meeting> builder)
        {
            // Burada Configuration ayarlarını yapabiliriz.
            builder.Property(p => p.StartTime).IsRequired();
            builder.Property(p => p.Subject).IsRequired();

           
        }
    }
}
