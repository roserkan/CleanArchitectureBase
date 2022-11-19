using AutoMapper;
using Core.Persistence.Paging;
using FastTicket.Application.Features.Venues.Commands.CreateVenue;
using FastTicket.Application.Features.Venues.Commands.DeleteVenue;
using FastTicket.Application.Features.Venues.Commands.UpdateVenue;
using FastTicket.Application.Features.Venues.Dtos;
using FastTicket.Application.Features.Venues.Models;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Features.Venues.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Venue, CreateVenueCommand>().ReverseMap();
        CreateMap<Venue, CreatedVenueDto>().ReverseMap();
        CreateMap<Venue, UpdateVenueCommand>().ReverseMap();
        CreateMap<Venue, UpdatedVenueDto>().ReverseMap();
        CreateMap<Venue, DeleteVenueCommand>().ReverseMap();
        CreateMap<Venue, DeletedVenueDto>().ReverseMap();
        CreateMap<Venue, VenueDto>().ReverseMap();
        CreateMap<IPaginate<Venue>, VenueListModel>().ReverseMap();
    }
}
