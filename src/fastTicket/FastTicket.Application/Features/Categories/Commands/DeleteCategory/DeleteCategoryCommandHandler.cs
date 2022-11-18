using AutoMapper;
using FastTicket.Application.Features.Categories.Dtos;
using FastTicket.Application.Features.Categories.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Categories.Commands.Delete;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeletedCategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly CategoryBusinessRules _categoryBusinessRules;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _categoryBusinessRules = categoryBusinessRules;
    }

    public async Task<DeletedCategoryDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryBusinessRules.MakeSureYouHaveACategory(request.Id);

        var mappedCategory = _mapper.Map<Category>(request);
        var deletedCategory = await _categoryRepository.DeleteAsync(mappedCategory);
        var deletedCategoryDto = _mapper.Map<DeletedCategoryDto>(deletedCategory);
        return deletedCategoryDto;
    }
}


