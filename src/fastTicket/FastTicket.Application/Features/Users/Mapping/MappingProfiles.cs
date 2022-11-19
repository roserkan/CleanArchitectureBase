using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using FastTicket.Application.Features.Users.Commands.CreateUser;
using FastTicket.Application.Features.Users.Commands.DeleteUser;
using FastTicket.Application.Features.Users.Commands.UpdateUser;
using FastTicket.Application.Features.Users.Dtos;
using FastTicket.Application.Features.Users.Models;

namespace FastTicket.Application.Features.Users.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, CreatedUserDto>().ReverseMap();
        CreateMap<User, UpdateUserCommand>().ReverseMap();
        CreateMap<User, UpdatedUserDto>().ReverseMap();
        CreateMap<User, DeleteUserCommand>().ReverseMap();
        CreateMap<User, DeletedUserDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<IPaginate<User>, UserListModel>().ReverseMap();
    }
}
