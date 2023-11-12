using Mechsoft_Project.Application.Interfaces.Repositories;
using Mechsoft_Project.Domain.Models;
using Mechsoft_Project.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechsoft_Project.Persistence.Repositories
{
    public class MeetingRepository : GenericRepository<Meeting>, IMeetingRepository
    {
        public MeetingRepository(MeetingDbContext context) : base(context)
        {
            
        }

    }
}
