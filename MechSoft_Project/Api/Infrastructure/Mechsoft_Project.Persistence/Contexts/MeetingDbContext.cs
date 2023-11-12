using Mechsoft_Project.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechsoft_Project.Persistence.Contexts
{
    public class MeetingDbContext : DbContext
    {
        public MeetingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Meeting> Meetings { get; set; }

        
    }
}
