using Mechsoft_Project.Application.Features.Commands.UpdateMeeting;
using Mechsoft_Project.Common.Models.Commands;
using Mechsoft_Project.Common.Models.Queries;
using Mechsoft_Project.WebApp.Infrastructure.Services.Interfaces;
using System.Net.Http.Json;

namespace Mechsoft_Project.WebApp.Infrastructure.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly HttpClient _httpClient;

        public MeetingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> CreateMeeting(CreateMeetingCommand command)
        {
            var res = await _httpClient.PostAsJsonAsync("/api/Meeting/create", command);

            if (!res.IsSuccessStatusCode)
                return 0;

            return 1;
        }

        public async Task DeleteMeeting(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Meeting/delete/{id}");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Delete error!");
        }

        public async Task<List<GetMeetingViewModel>> GetMeetings()
        {
            var result = await _httpClient.GetFromJsonAsync<List<GetMeetingViewModel>>($"/api/Meeting/get");

            return result;
        }

        public async Task<GetMeetingViewModel> GetOneMeeting(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<GetMeetingViewModel>($"/api/Meeting/get/{id}");

            return result;
        }

        public async Task<int> UpdateMeeting(UpdateMeetingCommand command)
        {
            var res = await _httpClient.PostAsJsonAsync($"/api/Meeting/update/{command.Id}", command);

            if (!res.IsSuccessStatusCode)
                return 0;

            return 1;

        }
    }
}
