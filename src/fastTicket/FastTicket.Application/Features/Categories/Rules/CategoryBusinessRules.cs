using Core.CrossCuttingConcerns.Exceptions;
using FastTicket.Application.Features.Categories.Constants;
using FastTicket.Application.Interfaces.Repositories;

namespace FastTicket.Application.Features.Categories.Rules
{
    public class CategoryBusinessRules
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBusinessRules(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CategoryNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _categoryRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException(CategoryMessages.Category_Name_CannotDuplicate);
        }

        public async Task MakeSureYouHaveACategory(Guid id)
        {
            var result = await _categoryRepository.GetAsync(c => c.Id == id, enableTracking: false);
            if (result is null) throw new BusinessException(CategoryMessages.Category_NotFound);
        }

        public async Task CategoryIdShouldExist(Guid id)
        {
            var result = await _categoryRepository.GetAsync(b => b.Id == id, enableTracking: false);
            if (result == null) throw new BusinessException(CategoryMessages.Category_NotFound);
        }
    }
}
