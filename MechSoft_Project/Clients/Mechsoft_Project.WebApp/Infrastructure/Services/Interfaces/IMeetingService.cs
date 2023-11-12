using Mechsoft_Project.Application.Features.Commands.UpdateMeeting;
using Mechsoft_Project.Common.Models.Commands;
using Mechsoft_Project.Common.Models.Queries;

namespace Mechsoft_Project.WebApp.Infrastructure.Services.Interfaces
{
    public interface IMeetingService
    {
        Task<int> CreateMeeting(CreateMeetingCommand command);
        Task<int> UpdateMeeting(UpdateMeetingCommand command);
        Task<List<GetMeetingViewModel>> GetMeetings();
        Task<GetMeetingViewModel> GetOneMeeting(int id);
        Task DeleteMeeting(int meetingId);

    }
}
