using AutoMapper;
using FastTicket.Application.Features.SubCategories.Models;
using FastTicket.Application.Interfaces.Repositories;
using MediatR;

namespace FastTicket.Application.Features.SubCategories.Queries.GetListSubCategory;

public class GetListSubCategoryQueryHandler : IRequestHandler<GetListSubCategoryQuery, SubCategoryListModel>
{
    private readonly ISubCategoryRepository _subCategoryRepository;
    private readonly IMapper _mapper;

    public GetListSubCategoryQueryHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
    {
        _subCategoryRepository = subCategoryRepository;
        _mapper = mapper;
    }

    public async Task<SubCategoryListModel> Handle(GetListSubCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await _subCategoryRepository.GetListAsync(index: request.PageRequest.Page,
                                                                size: request.PageRequest.PageSize);

        var mappedSubCategoryListModel = _mapper.Map<SubCategoryListModel>(categories);

        return mappedSubCategoryListModel;
    }
}