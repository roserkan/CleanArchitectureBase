using AutoMapper;
using Core.Persistence.Paging;
using FastTicket.Application.Features.Tickets.Commands.CreateTicket;
using FastTicket.Application.Features.Tickets.Commands.DeleteTicket;
using FastTicket.Application.Features.Tickets.Commands.UpdateTicket;
using FastTicket.Application.Features.Tickets.Dtos;
using FastTicket.Application.Features.Tickets.Models;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Features.Tickets.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Ticket, CreateTicketCommand>().ReverseMap();
        CreateMap<Ticket, CreatedTicketDto>().ReverseMap();
        CreateMap<Ticket, UpdateTicketCommand>().ReverseMap();
        CreateMap<Ticket, UpdatedTicketDto>().ReverseMap();
        CreateMap<Ticket, DeleteTicketCommand>().ReverseMap();
        CreateMap<Ticket, DeletedTicketDto>().ReverseMap();
        CreateMap<Ticket, TicketDto>().ReverseMap();
        CreateMap<IPaginate<Ticket>, TicketListModel>().ReverseMap();
    }
}
