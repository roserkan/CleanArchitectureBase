using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using FastTicket.Application.Constants;
using FastTicket.Application.Dtos.CategoryDtos;
using FastTicket.Application.Features.Categories.Commands.Update;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Categories.Commands.Delete;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdatedCategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<UpdatedCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await CategoryIdShouldExist(request.Id);
        await CategoryNameCanNotBeDuplicatedWhenInserted(request.Name);

        var mappedCategory = _mapper.Map<Category>(request);
        var updatedCategory = await _categoryRepository.UpdateAsync(mappedCategory);
        var updatedCategoryDto = _mapper.Map<UpdatedCategoryDto>(updatedCategory);
        return updatedCategoryDto;
    }

    private async Task CategoryNameCanNotBeDuplicatedWhenInserted(string name)
    {
        var result = await _categoryRepository.GetListAsync(b => b.Name == name);
        if (result.Items.Any()) throw new BusinessException(Messages.Category_Name_CannotDuplicate);
    }

    private async Task CategoryIdShouldExist(Guid id)
    {
        var result = await _categoryRepository.GetAsync(b => b.Id == id, enableTracking: false);
        if (result == null) throw new BusinessException(Messages.Category_NotFound);
    }
}
  