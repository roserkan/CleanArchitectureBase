using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using FastTicket.Application.Constants;
using FastTicket.Application.Dtos.SubCategoryDtos;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.SubCategories.Commands.UpdateSubCategory;

public class UpdateSubCategoryCommandHandler : IRequestHandler<UpdateSubCategoryCommand, UpdatedSubCategoryDto>
{
    private readonly ISubCategoryRepository _subCategoryRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public UpdateSubCategoryCommandHandler(ISubCategoryRepository subCategoryRepository, ICategoryRepository categoryRepository, IMapper mapper)
    {
        _subCategoryRepository = subCategoryRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<UpdatedSubCategoryDto> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
    {
        await SubCategoryIdShouldExist(request.Id);
        await MakeSureYouHaveACategory(request.CategoryId);

        var mappedSubCategory = _mapper.Map<SubCategory>(request);
        var updatedSubCategory = await _subCategoryRepository.UpdateAsync(mappedSubCategory);
        var updatedSubCategoryDto = _mapper.Map<UpdatedSubCategoryDto>(updatedSubCategory);
        return updatedSubCategoryDto;
    }

    private async Task SubCategoryIdShouldExist(Guid id)
    {
        var result = await _subCategoryRepository.GetAsync(b => b.Id == id, enableTracking: false);
        if (result == null) throw new BusinessException(Messages.SubCategory_NotFound);
    }

    private async Task MakeSureYouHaveACategory(Guid id)
    {
        var result = await _categoryRepository.GetAsync(c => c.Id == id, enableTracking: false);
        if (result is null) throw new BusinessException(Messages.Category_NotFound);
    }
}
