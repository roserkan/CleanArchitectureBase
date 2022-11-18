using AutoMapper;
using FastTicket.Application.Features.Categories.Dtos;
using FastTicket.Application.Features.Categories.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Categories.Commands.Create;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly CategoryBusinessRules _categoryBusinessRules;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _categoryBusinessRules = categoryBusinessRules;
    }

    public async Task<CreatedCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryBusinessRules.CategoryNameCanNotBeDuplicatedWhenInserted(request.Name);

        var mappedCategory = _mapper.Map<Category>(request);
        var createdCategory = await _categoryRepository.AddAsync(mappedCategory);
        var createdCategoryDto = _mapper.Map<CreatedCategoryDto>(createdCategory);
        return createdCategoryDto;
    }
}