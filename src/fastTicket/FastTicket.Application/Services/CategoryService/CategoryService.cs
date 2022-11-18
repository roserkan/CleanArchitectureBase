using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;

namespace FastTicket.Application.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category> GetById(Guid id)
    {
        Category category = await _categoryRepository.GetAsync(u => u.Id == id);
        return category;
    }
}
