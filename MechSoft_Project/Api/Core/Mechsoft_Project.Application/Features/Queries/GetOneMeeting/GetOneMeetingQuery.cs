using Mechsoft_Project.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechsoft_Project.Application.Features.Queries.GetOneMeeting
{
    public class GetOneMeetingQuery : IRequest<GetMeetingViewModel>
    {
        public GetOneMeetingQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
