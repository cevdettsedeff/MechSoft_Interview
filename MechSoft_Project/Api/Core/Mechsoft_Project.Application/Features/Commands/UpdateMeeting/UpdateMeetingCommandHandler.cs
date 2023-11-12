using Mechsoft_Project.Application.Interfaces.Repositories;
using Mechsoft_Project.Domain.Models;
using Mechsoft_Project.Common.Models.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechsoft_Project.Application.Features.Commands.UpdateMeeting
{
    public class UpdateMeetingCommandHandler : IRequestHandler<UpdateMeetingCommand, int>
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly ILogger<UpdateMeetingCommandHandler> _logger;

        public UpdateMeetingCommandHandler(IMeetingRepository meetingRepository, ILogger<UpdateMeetingCommandHandler> logger)
        {
            _meetingRepository = meetingRepository;
            _logger = logger;
        }

        public async Task<int> Handle(UpdateMeetingCommand request, CancellationToken cancellationToken)
        {
            var meeting = await _meetingRepository.GetByIdAsync(request.Id);

            meeting.Subject = request.Subject;
            meeting.StartTime = request.StartTime;
            meeting.EndTime = request.EndTime;
            meeting.Participants = request.Participants;

            _meetingRepository.Update(meeting);
            await _meetingRepository.SaveAsync();

            _logger.LogInformation("Toplantı başarılı bir şekilde güncellendi.");

            return request.Id;
        }
    }
}
