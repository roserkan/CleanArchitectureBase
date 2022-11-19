using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using FastTicket.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using FastTicket.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using FastTicket.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using FastTicket.Application.Features.OperationClaims.Dtos;
using FastTicket.Application.Features.OperationClaims.Models;

namespace FastTicket.Application.Features.OperationClaims.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();
        CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();
        CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();
        CreateMap<OperationClaim, OperationClaimDto>().ReverseMap();
        CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
    }
}