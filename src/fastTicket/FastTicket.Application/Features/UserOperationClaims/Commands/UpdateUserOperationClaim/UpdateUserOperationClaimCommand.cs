﻿using Core.Application.Pipelines.Authorization;
using FastTicket.Application.Features.UserOperationClaims.Dtos;
using MediatR;
using static FastTicket.Application.Features.UserOperationClaims.Constants.OperationClaims;
using static FastTicket.Domain.Constants.OperationClaims;

namespace FastTicket.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;

public class UpdateUserOperationClaimCommand : IRequest<UpdatedUserOperationClaimDto>, ISecuredRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }
    public string[] Roles => new[] { Admin, UserOperationClaimUpdate };
}
