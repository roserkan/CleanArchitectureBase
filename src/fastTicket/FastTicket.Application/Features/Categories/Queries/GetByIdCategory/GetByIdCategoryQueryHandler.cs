using AutoMapper;
using FastTicket.Application.Features.Categories.Dtos;
using FastTicket.Application.Features.Categories.Rules;
using FastTicket.Application.Interfaces.Repositories;
using MediatR;

namespace FastTicket.Application.Features.Categories.Queries.GetByIdCategory;

public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly CategoryBusinessRules _categoryBusinessRules;
    public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _categoryBusinessRules = categoryBusinessRules;
    }

    public async Task<CategoryDto> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
    {
        await _categoryBusinessRules.CategoryIdShouldExist(request.Id);

        var category = await _categoryRepository.GetAsync(b => b.Id == request.Id);
        CategoryDto categoryDto = _mapper.Map<CategoryDto>(category);
        return categoryDto;
    }
}