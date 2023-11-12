using AutoMapper;
using Mechsoft_Project.Application.Features.Commands.CreateMeeting;
using Mechsoft_Project.Application.Features.Commands.DeleteMeeting;
using Mechsoft_Project.Application.Features.Commands.UpdateMeeting;
using Mechsoft_Project.Common.Models.Commands;
using Mechsoft_Project.Common.Models.Queries;
using Mechsoft_Project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechsoft_Project.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Meeting, GetMeetingViewModel>().ReverseMap();
            CreateMap<Meeting, CreateMeetingCommand>().ReverseMap();
            CreateMap<Meeting, UpdateMeetingCommand>().ReverseMap();
            CreateMap<Meeting, DeleteMeetingCommand>().ReverseMap();
           


        }
    }
}
