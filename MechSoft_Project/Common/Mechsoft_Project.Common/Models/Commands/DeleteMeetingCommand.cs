using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechsoft_Project.Application.Features.Commands.DeleteMeeting
{
    public class DeleteMeetingCommand : IRequest<int>
    {
        public DeleteMeetingCommand()
        {

        }

        public DeleteMeetingCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
