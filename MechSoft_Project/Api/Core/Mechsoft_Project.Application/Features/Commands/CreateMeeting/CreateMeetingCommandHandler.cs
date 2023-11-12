using AutoMapper;
using Mechsoft_Project.Application.Interfaces.Repositories;
using Mechsoft_Project.Common.Models.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechsoft_Project.Application.Features.Commands.CreateMeeting
{
    public class CreateMeetingCommandHandler : IRequestHandler<CreateMeetingCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IMeetingRepository _meetingRepository;
        private readonly ILogger<CreateMeetingCommandHandler> _logger;

        public CreateMeetingCommandHandler(IMapper mapper, IMeetingRepository meetingRepository, ILogger<CreateMeetingCommandHandler> logger)
        {
            _mapper = mapper;
            _meetingRepository = meetingRepository;
            _logger = logger;
        }

        public async Task<int> Handle(CreateMeetingCommand request, CancellationToken cancellationToken)
        {
            var dbMeeting = _mapper.Map<Domain.Models.Meeting>(request);

            await _meetingRepository.AddAsync(dbMeeting);
            await _meetingRepository.SaveAsync();
            _logger.LogInformation("Toplantı başarılı bir şekilde eklendi!");

            return dbMeeting.Id;
        }
    }
}
