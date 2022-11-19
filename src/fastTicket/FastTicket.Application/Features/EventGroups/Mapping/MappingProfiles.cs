using AutoMapper;
using Core.Persistence.Paging;
using FastTicket.Application.Features.EventGroups.Commands.CreateEventGroup;
using FastTicket.Application.Features.EventGroups.Commands.DeleteEventGroup;
using FastTicket.Application.Features.EventGroups.Commands.UpdateEventGroup;
using FastTicket.Application.Features.EventGroups.Dtos;
using FastTicket.Application.Features.EventGroups.Models;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Features.EventGroups.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<EventGroup, CreateEventGroupCommand>().ReverseMap();
        CreateMap<EventGroup, CreatedEventGroupDto>().ReverseMap();
        CreateMap<EventGroup, UpdateEventGroupCommand>().ReverseMap();
        CreateMap<EventGroup, UpdatedEventGroupDto>().ReverseMap();
        CreateMap<EventGroup, DeleteEventGroupCommand>().ReverseMap();
        CreateMap<EventGroup, DeletedEventGroupDto>().ReverseMap();
        CreateMap<EventGroup, EventGroupDto>().ReverseMap();
        CreateMap<IPaginate<EventGroup>, EventGroupListModel>().ReverseMap();
    }
}

