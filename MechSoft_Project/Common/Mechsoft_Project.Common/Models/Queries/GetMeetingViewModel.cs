using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechsoft_Project.Common.Models.Queries
{
    public class GetMeetingViewModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime MeetingDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Participants { get; set; }
    }
}
