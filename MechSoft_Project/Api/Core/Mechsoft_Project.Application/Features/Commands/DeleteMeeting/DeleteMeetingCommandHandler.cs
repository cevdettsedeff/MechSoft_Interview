using Mechsoft_Project.Application.Interfaces.Repositories;
using Mechsoft_Project.Common.Models.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechsoft_Project.Application.Features.Commands.DeleteMeeting
{
    public class DeleteMeetingCommandHandler : IRequestHandler<DeleteMeetingCommand, int>
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly ILogger<DeleteMeetingCommandHandler> _logger;

        public DeleteMeetingCommandHandler(IMeetingRepository meetingRepository, ILogger<DeleteMeetingCommandHandler> logger)
        {
            _meetingRepository = meetingRepository;
            _logger = logger;
        }

        public async Task<int> Handle(DeleteMeetingCommand request, CancellationToken cancellationToken)
        {
            await _meetingRepository.RemoveAsync(request.Id);
            await _meetingRepository.SaveAsync();
            _logger.LogInformation("Toplantı başarılı bir şekilde silindi!");
            return 0;
        }
    }
}
