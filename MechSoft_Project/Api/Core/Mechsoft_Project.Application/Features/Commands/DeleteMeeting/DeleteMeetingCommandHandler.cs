using Mechsoft_Project.Application.Interfaces.Repositories;
using Mechsoft_Project.Common.Models.Commands;
using MediatR;
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

        public DeleteMeetingCommandHandler(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }

        public async Task<int> Handle(DeleteMeetingCommand request, CancellationToken cancellationToken)
        {
            await _meetingRepository.RemoveAsync(request.Id);
            await _meetingRepository.SaveAsync();
            return 0;
        }
    }
}
