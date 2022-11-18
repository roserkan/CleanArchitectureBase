using AutoMapper;
using FastTicket.Application.Features.Categories.Commands.Update;
using FastTicket.Application.Features.Categories.Dtos;
using FastTicket.Application.Features.Categories.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Categories.Commands.Delete;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdatedCategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly CategoryBusinessRules _categoryBusinessRules;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _categoryBusinessRules = categoryBusinessRules;
    }

    public async Task<UpdatedCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryBusinessRules.CategoryIdShouldExist(request.Id);
        await _categoryBusinessRules.CategoryNameCanNotBeDuplicatedWhenInserted(request.Name);

        var mappedCategory = _mapper.Map<Category>(request);
        var updatedCategory = await _categoryRepository.UpdateAsync(mappedCategory);
        var updatedCategoryDto = _mapper.Map<UpdatedCategoryDto>(updatedCategory);
        return updatedCategoryDto;
    }
}
  