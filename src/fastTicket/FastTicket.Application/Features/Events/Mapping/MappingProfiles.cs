using AutoMapper;
using Core.Persistence.Paging;
using FastTicket.Application.Features.Events.Commands.CreateEvent;
using FastTicket.Application.Features.Events.Commands.DeleteEvent;
using FastTicket.Application.Features.Events.Commands.UpdateEvent;
using FastTicket.Application.Features.Events.Dtos;
using FastTicket.Application.Features.Events.Models;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Features.Events.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Event, CreateEventCommand>().ReverseMap();
        CreateMap<Event, CreatedEventDto>().ReverseMap();
        CreateMap<Event, UpdateEventCommand>().ReverseMap();
        CreateMap<Event, UpdatedEventDto>().ReverseMap();
        CreateMap<Event, DeleteEventCommand>().ReverseMap();
        CreateMap<Event, DeletedEventDto>().ReverseMap();
        CreateMap<Event, EventDto>().ReverseMap();
        CreateMap<IPaginate<Event>, EventListModel>().ReverseMap();
    }
}
