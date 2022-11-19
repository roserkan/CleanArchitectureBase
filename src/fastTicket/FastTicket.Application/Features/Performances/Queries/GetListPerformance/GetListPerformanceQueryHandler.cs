using AutoMapper;
using Core.Persistence.Paging;
using FastTicket.Application.Features.Performances.Models;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Performances.Queries.GetListPerformance;

public class GetListPerformanceQueryHandler : IRequestHandler<GetListPerformanceQuery, PerformanceListModel>
{
    private readonly IPerformanceRepository _performanceRepository;
    private readonly IMapper _mapper;

    public GetListPerformanceQueryHandler(IPerformanceRepository performanceRepository, IMapper mapper)
    {
        _performanceRepository = performanceRepository;
        _mapper = mapper;
    }

    public async Task<PerformanceListModel> Handle(GetListPerformanceQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Performance> performances = await _performanceRepository.GetListAsync(index: request.PageRequest.Page,
                                                                   size: request.PageRequest.PageSize);
        PerformanceListModel mappedPerformanceListModel = _mapper.Map<PerformanceListModel>(performances);
        return mappedPerformanceListModel;
    }
}