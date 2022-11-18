using FastTicket.Domain.Entities;

namespace FastTicket.Application.Services.CategoryService;

public interface ICategoryService
{
    public Task<Category> GetById(Guid id);
}
