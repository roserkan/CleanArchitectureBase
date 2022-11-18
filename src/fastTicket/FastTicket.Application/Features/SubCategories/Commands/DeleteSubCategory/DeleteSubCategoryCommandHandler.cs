using AutoMapper;
using FastTicket.Application.Features.SubCategories.Dtos;
using FastTicket.Application.Features.SubCategories.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.SubCategories.Commands.DeleteSubCategory;

public class DeleteSubCategoryCommandHandler : IRequestHandler<DeleteSubCategoryCommand, DeletedSubCategoryDto>
{
    private readonly ISubCategoryRepository _subCategoryRepository;
    private readonly IMapper _mapper;
    private readonly SubCategoryBusinessRules _subCategoryBusinessRules;

    public DeleteSubCategoryCommandHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper, SubCategoryBusinessRules subCategoryBusinessRules)
    {
        _subCategoryRepository = subCategoryRepository;
        _mapper = mapper;
        _subCategoryBusinessRules = subCategoryBusinessRules;
    }

    public async Task<DeletedSubCategoryDto> Handle(DeleteSubCategoryCommand request, CancellationToken cancellationToken)
    {
        await _subCategoryBusinessRules.MakeSureYouHaveASubCategory(request.Id);

        var mappedSubCategory = _mapper.Map<SubCategory>(request);
        var deletedSubCategory = await _subCategoryRepository.DeleteAsync(mappedSubCategory);
        var deletedSubCategoryDto = _mapper.Map<DeletedSubCategoryDto>(deletedSubCategory);
        return deletedSubCategoryDto;
    }
}


