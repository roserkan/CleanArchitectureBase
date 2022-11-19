using AutoMapper;
using FastTicket.Application.Features.Performances.Dtos;
using FastTicket.Application.Features.Performances.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Performances.Queries.GetByIdPerformance;

public class GetByIdPerformanceQueryHandler : IRequestHandler<GetByIdPerformanceQuery, PerformanceDto>
{
    private readonly IPerformanceRepository _performanceRepository;
    private readonly IMapper _mapper;
    private readonly PerformanceBusinessRules _performanceBusinessRules;

    public GetByIdPerformanceQueryHandler(IPerformanceRepository performanceRepository, IMapper mapper,
                                   PerformanceBusinessRules performanceBusinessRules)
    {
        _performanceRepository = performanceRepository;
        _mapper = mapper;
        _performanceBusinessRules = performanceBusinessRules;
    }


    public async Task<PerformanceDto> Handle(GetByIdPerformanceQuery request, CancellationToken cancellationToken)
    {
        await _performanceBusinessRules.PerformanceIdShouldExist(request.Id);

        Performance? performance = await _performanceRepository.GetAsync(b => b.Id == request.Id);
        PerformanceDto performanceDto = _mapper.Map<PerformanceDto>(performance);
        return performanceDto;
    }
}
