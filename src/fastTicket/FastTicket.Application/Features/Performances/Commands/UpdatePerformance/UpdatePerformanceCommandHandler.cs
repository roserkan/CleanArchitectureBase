using AutoMapper;
using FastTicket.Application.Features.Performances.Dtos;
using FastTicket.Application.Features.Performances.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;


namespace FastTicket.Application.Features.Performances.Commands.UpdatePerformance;

public class UpdatePerformanceCommandHandler : IRequestHandler<UpdatePerformanceCommand, UpdatedPerformanceDto>
{
    private readonly IPerformanceRepository _performanceRepository;
    private readonly IMapper _mapper;
    private readonly PerformanceBusinessRules _performanceBusinessRules;

    public UpdatePerformanceCommandHandler(IPerformanceRepository performanceRepository, IMapper mapper, PerformanceBusinessRules performanceBusinessRules)
    {
        _performanceRepository = performanceRepository;
        _mapper = mapper;
        _performanceBusinessRules = performanceBusinessRules;
    }

    public async Task<UpdatedPerformanceDto> Handle(UpdatePerformanceCommand request, CancellationToken cancellationToken)
    {
        await _performanceBusinessRules.PerformanceIdShouldExist(request.Id);
        await _performanceBusinessRules.EventIdShouldExist(request.EventId);

        Performance mappedPerformance = _mapper.Map<Performance>(request);
        Performance updatedPerformance = await _performanceRepository.AddAsync(mappedPerformance);
        UpdatedPerformanceDto updatedPerformanceDto = _mapper.Map<UpdatedPerformanceDto>(updatedPerformance);
        return updatedPerformanceDto;
    }
}
