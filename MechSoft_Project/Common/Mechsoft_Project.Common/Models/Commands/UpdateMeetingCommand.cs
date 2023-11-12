using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechsoft_Project.Application.Features.Commands.UpdateMeeting
{
    public class UpdateMeetingCommand : IRequest<int>
    {
        public UpdateMeetingCommand()
        {
        }

        public UpdateMeetingCommand(int ıd, string subject, DateTime meetingDate, DateTime startTime, DateTime endTime, string participants)
        {
            Id = ıd;
            Subject = subject;
            MeetingDate = meetingDate;
            StartTime = startTime;
            EndTime = endTime;
            Participants = participants;
        }

        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime MeetingDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Participants { get; set; }
    }
}
