using Mechsoft_Project.Application.Features.Queries.GetMeeting;
using Mechsoft_Project.Application.Interfaces.Repositories;
using Mechsoft_Project.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechsoft_Project.Application.Features.Queries.GetOneMeeting
{
    public class GetOneMeetingQueryHandler : IRequestHandler<GetOneMeetingQuery, GetMeetingViewModel>
    {
        private readonly IMeetingRepository _meetingRepository;

        public GetOneMeetingQueryHandler(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }

        public async Task<GetMeetingViewModel> Handle(GetOneMeetingQuery request, CancellationToken cancellationToken)
        {
            var meeting = await _meetingRepository.GetByIdAsync(request.Id);

            return new GetMeetingViewModel()
            {
                Id = meeting.Id,
                Subject = meeting.Subject,
                MeetingDate = meeting.MeetingDate,
                StartTime = meeting.StartTime,
                EndTime = meeting.EndTime,
                Participants = meeting.Participants,
            };

        }
    }
}
