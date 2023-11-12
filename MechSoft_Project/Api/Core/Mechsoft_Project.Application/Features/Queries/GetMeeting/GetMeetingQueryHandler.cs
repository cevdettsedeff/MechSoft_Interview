using AutoMapper;
using Mechsoft_Project.Application.Interfaces.Repositories;
using Mechsoft_Project.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechsoft_Project.Application.Features.Queries.GetMeeting
{
    public class GetMeetingQueryHandler : IRequestHandler<GetMeetingQuery, List<GetMeetingViewModel>>
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IMapper _mapper;

        public GetMeetingQueryHandler(IMeetingRepository meetingRepository, IMapper mapper)
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper;
        }

        public async Task<List<GetMeetingViewModel>> Handle(GetMeetingQuery request, CancellationToken cancellationToken)
        {
            var meetings = _meetingRepository.GetAll().ToList();

            var meetingDtos = meetings.Select(m => new GetMeetingViewModel
            {
                Id = m.Id,
                Subject = m.Subject,
                MeetingDate = m.MeetingDate,
                StartTime = m.StartTime,
                EndTime = m.EndTime,
                Participants = m.Participants,
                
                // Diğer bilgiler
            }).ToList();

            return meetingDtos;
        }
    }
}
