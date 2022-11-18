using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using FastTicket.Application.Constants;
using FastTicket.Application.Dtos.CategoryDtos;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Categories.Commands.Create;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CreatedCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await CategoryNameCanNotBeDuplicatedWhenInserted(request.Name);

        var mappedCategory = _mapper.Map<Category>(request);
        var createdCategory = await _categoryRepository.AddAsync(mappedCategory);
        var createdCategoryDto = _mapper.Map<CreatedCategoryDto>(createdCategory);
        return createdCategoryDto;
    }

    private async Task CategoryNameCanNotBeDuplicatedWhenInserted(string name)
    {
        var result = await _categoryRepository.GetListAsync(b => b.Name == name);
        if (result.Items.Any()) throw new BusinessException(Messages.Category_Name_CannotDuplicate);
    }
}