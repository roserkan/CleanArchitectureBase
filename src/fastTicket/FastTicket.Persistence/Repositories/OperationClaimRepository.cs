﻿using Core.Persistence.Repositories;
using Core.Security.Entities;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Persistence.Contexts;

namespace FastTicket.Persistence.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, FastTicketDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(FastTicketDbContext context) : base(context)
    {
    }
}
