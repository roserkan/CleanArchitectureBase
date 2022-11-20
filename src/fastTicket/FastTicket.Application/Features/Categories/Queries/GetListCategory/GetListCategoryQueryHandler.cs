using AutoMapper;
using FastTicket.Application.Features.Categories.Models;
using FastTicket.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FastTicket.Application.Features.Categories.Queries.GetByIdCategory;

public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, CategoryListModel>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryListModel> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetListAsync(index: request.PageRequest.Page,
                                                                size: request.PageRequest.PageSize,
                                                                include: i => i.Include(i => i.SubCategories));

        var mappedCategoryListModel = _mapper.Map<CategoryListModel>(categories);

        return mappedCategoryListModel;
    }
}