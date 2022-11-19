using AutoMapper;
using FastTicket.Application.Features.Performances.Dtos;
using FastTicket.Application.Features.Performances.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Performances.Commands.CreatePerformance;

public class CreatePerformanceCommandHandler : IRequestHandler<CreatePerformanceCommand, CreatedPerformanceDto>
{
    private readonly IPerformanceRepository _performanceRepository;
    private readonly IMapper _mapper;
    private readonly PerformanceBusinessRules _performanceBusinessRules;

    public CreatePerformanceCommandHandler(IPerformanceRepository performanceRepository, IMapper mapper, PerformanceBusinessRules performanceBusinessRules)
    {
        _performanceRepository = performanceRepository;
        _mapper = mapper;
        _performanceBusinessRules = performanceBusinessRules;
    }

    public async Task<CreatedPerformanceDto> Handle(CreatePerformanceCommand request, CancellationToken cancellationToken)
    {
        await _performanceBusinessRules.EventIdShouldExist(request.EventId);

        Performance mappedPerformance = _mapper.Map<Performance>(request);
        Performance createdPerformance = await _performanceRepository.AddAsync(mappedPerformance);
        CreatedPerformanceDto createdPerformanceDto = _mapper.Map<CreatedPerformanceDto>(createdPerformance);
        return createdPerformanceDto;
    }
}