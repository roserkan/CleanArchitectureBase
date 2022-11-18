using Core.CrossCuttingConcerns.Exceptions;
using FastTicket.Application.Features.SubCategories.Constants;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Application.Services.CategoryService;

namespace FastTicket.Application.Features.SubCategories.Rules;

public class SubCategoryBusinessRules
{
    private readonly ISubCategoryRepository _subCategoryRepository;
    private readonly ICategoryService _categoryService;

    public SubCategoryBusinessRules(ISubCategoryRepository subCategoryRepository, ICategoryService categoryService)
    {
        _subCategoryRepository = subCategoryRepository;
        _categoryService = categoryService;
    }

    public async Task MakeSureYouHaveASubCategory(Guid id)
    {
        var result = await _subCategoryRepository.GetAsync(c => c.Id == id, enableTracking: false);
        if (result is null) throw new BusinessException(SubCategoryMessages.SubCategory_NotFound);
    }

    public async Task SubCategoryIdShouldExist(Guid id)
    {
        var result = await _subCategoryRepository.GetAsync(b => b.Id == id, enableTracking: false);
        if (result == null) throw new BusinessException(SubCategoryMessages.SubCategory_NotFound);
    }

    public async Task MakeSureYouHaveACategory(Guid id)
    {
        var result = await _categoryService.GetById(id);
        if (result is null) throw new BusinessException(SubCategoryMessages.SubCategory_NotFound);
    }
}
