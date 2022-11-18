using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using FastTicket.Application.Constants;
using FastTicket.Application.Dtos.SubCategoryDtos;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.SubCategories.Commands.DeleteSubCategory;

public class DeleteSubCategoryCommandHandler : IRequestHandler<DeleteSubCategoryCommand, DeletedSubCategoryDto>
{
    private readonly ISubCategoryRepository _subCategoryRepository;
    private readonly IMapper _mapper;

    public DeleteSubCategoryCommandHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
    {
        _subCategoryRepository = subCategoryRepository;
        _mapper = mapper;
    }

    public async Task<DeletedSubCategoryDto> Handle(DeleteSubCategoryCommand request, CancellationToken cancellationToken)
    {
        await MakeSureYouHaveASubCategory(request.Id);

        var mappedSubCategory = _mapper.Map<SubCategory>(request);
        var deletedSubCategory = await _subCategoryRepository.DeleteAsync(mappedSubCategory);
        var deletedSubCategoryDto = _mapper.Map<DeletedSubCategoryDto>(deletedSubCategory);
        return deletedSubCategoryDto;
    }

    private async Task MakeSureYouHaveASubCategory(Guid id)
    {
        var result = await _subCategoryRepository.GetAsync(c => c.Id == id, enableTracking: false);
        if (result is null) throw new BusinessException(Messages.SubCategory_NotFound);
    }
}


