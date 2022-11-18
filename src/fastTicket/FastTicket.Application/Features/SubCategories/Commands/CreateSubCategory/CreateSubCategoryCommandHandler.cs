using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using FastTicket.Application.Constants;
using FastTicket.Application.Dtos.SubCategoryDtos;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.SubCategories.Commands.CreateSubSubCategory;

public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand, CreatedSubCategoryDto>
{
    private readonly ISubCategoryRepository _subcategoryRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CreateSubCategoryCommandHandler(ISubCategoryRepository subcategoryRepository, IMapper mapper, ICategoryRepository categoryRepository)
    {
        _subcategoryRepository = subcategoryRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CreatedSubCategoryDto> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
    {
        await MakeSureYouHaveACategory(request.CategoryId);
        var mappedSubCategory = _mapper.Map<SubCategory>(request);
        var createdSubCategory = await _subcategoryRepository.AddAsync(mappedSubCategory);
        var createdSubCategoryDto = _mapper.Map<CreatedSubCategoryDto>(createdSubCategory);
        return createdSubCategoryDto;
    }

    private async Task MakeSureYouHaveACategory(Guid id)
    {
        var result = await _categoryRepository.GetAsync(c => c.Id == id, enableTracking: false);
        if (result is null) throw new BusinessException(Messages.Category_NotFound);
    }
}

