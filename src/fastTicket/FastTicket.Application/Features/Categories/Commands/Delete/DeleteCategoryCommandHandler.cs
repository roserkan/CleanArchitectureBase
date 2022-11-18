using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using FastTicket.Application.Constants;
using FastTicket.Application.Dtos.CategoryDtos;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.Categories.Commands.Delete;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeletedCategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<DeletedCategoryDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await MakeSureYouHaveACategory(request.Id);

        var mappedCategory = _mapper.Map<Category>(request);
        var deletedCategory = await _categoryRepository.DeleteAsync(mappedCategory);
        var deletedCategoryDto = _mapper.Map<DeletedCategoryDto>(deletedCategory);
        return deletedCategoryDto;
    }

    private async Task MakeSureYouHaveACategory(Guid id)
    {
        var result = await _categoryRepository.GetAsync(c => c.Id == id, enableTracking: false);
        if (result is null) throw new BusinessException(Messages.Category_NotFound);
    }
}


