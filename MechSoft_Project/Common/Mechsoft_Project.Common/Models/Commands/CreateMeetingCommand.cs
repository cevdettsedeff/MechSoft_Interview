using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechsoft_Project.Common.Models.Commands
{
    public class CreateMeetingCommand : IRequest<int>
    {
        public CreateMeetingCommand()
        {

        }

        public CreateMeetingCommand(string subject, DateTime meetingDate, DateTime startTime, DateTime endTime, string participants)
        {
            Subject = subject;
            MeetingDate = meetingDate;
            StartTime = startTime;
            EndTime = endTime;
            Participants = participants;
        }

        public string Subject { get; set; }
        public DateTime MeetingDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Participants { get; set; }
    }
}
