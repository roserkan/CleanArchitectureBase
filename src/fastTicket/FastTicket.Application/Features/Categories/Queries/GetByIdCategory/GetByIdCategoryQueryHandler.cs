using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using FastTicket.Application.Constants;
using FastTicket.Application.Dtos.CategoryDtos;
using FastTicket.Application.Interfaces.Repositories;
using MediatR;

namespace FastTicket.Application.Features.Categories.Queries.GetByIdCategory;

public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
    {
        await CategoryIdShouldExist(request.Id);

        var category = await _categoryRepository.GetAsync(b => b.Id == request.Id);
        CategoryDto categoryDto = _mapper.Map<CategoryDto>(category);
        return categoryDto;
    }

    private async Task CategoryIdShouldExist(Guid id)
    {
        var result = await _categoryRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(Messages.Category_NotFound);
    }
}