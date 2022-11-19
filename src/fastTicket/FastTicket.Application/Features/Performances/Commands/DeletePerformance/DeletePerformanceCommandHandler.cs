using AutoMapper;
using FastTicket.Application.Features.Performances.Dtos;
using FastTicket.Application.Features.Performances.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Performances.Commands.DeletePerformance;

public class DeletePerformanceCommandHandler : IRequestHandler<DeletePerformanceCommand, DeletedPerformanceDto>
{
    private readonly IPerformanceRepository _performanceRepository;
    private readonly IMapper _mapper;
    private readonly PerformanceBusinessRules _performanceBusinessRules;

    public DeletePerformanceCommandHandler(IPerformanceRepository performanceRepository, IMapper mapper, PerformanceBusinessRules performanceBusinessRules)
    {
        _performanceRepository = performanceRepository;
        _mapper = mapper;
        _performanceBusinessRules = performanceBusinessRules;
    }

    public async Task<DeletedPerformanceDto> Handle(DeletePerformanceCommand request, CancellationToken cancellationToken)
    {
        await _performanceBusinessRules.PerformanceIdShouldExist(request.Id);

        Performance mappedPerformance = _mapper.Map<Performance>(request);
        Performance deletedPerformance = await _performanceRepository.DeleteAsync(mappedPerformance);
        DeletedPerformanceDto deletedPerformanceDto = _mapper.Map<DeletedPerformanceDto>(deletedPerformance);
        return deletedPerformanceDto;
    }
}