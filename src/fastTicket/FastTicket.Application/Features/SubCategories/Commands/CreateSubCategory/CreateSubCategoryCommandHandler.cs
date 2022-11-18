using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using FastTicket.Application.Constants;
using FastTicket.Application.Dtos.SubCategoryDtos;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Application.Services.CategoryService;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.SubCategories.Commands.CreateSubSubCategory;

public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand, CreatedSubCategoryDto>
{
    private readonly ISubCategoryRepository _subcategoryRepository;
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CreateSubCategoryCommandHandler(ISubCategoryRepository subcategoryRepository, ICategoryService categoryService, IMapper mapper)
    {
        _subcategoryRepository = subcategoryRepository;
        _categoryService = categoryService;
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
        var result = await _categoryService.GetById(id);
        if (result is null) throw new BusinessException(Messages.Category_NotFound);
    }
}

