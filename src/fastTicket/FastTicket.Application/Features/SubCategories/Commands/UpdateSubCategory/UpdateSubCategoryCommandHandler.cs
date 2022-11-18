using AutoMapper;
using FastTicket.Application.Features.SubCategories.Dtos;
using FastTicket.Application.Features.SubCategories.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.SubCategories.Commands.UpdateSubCategory;

public class UpdateSubCategoryCommandHandler : IRequestHandler<UpdateSubCategoryCommand, UpdatedSubCategoryDto>
{
    private readonly ISubCategoryRepository _subCategoryRepository;
    private readonly IMapper _mapper;
    private readonly SubCategoryBusinessRules _subCategoryBusinessRules;

    public UpdateSubCategoryCommandHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper, SubCategoryBusinessRules subCategoryBusinessRules)
    {
        _subCategoryRepository = subCategoryRepository;
        _mapper = mapper;
        _subCategoryBusinessRules = subCategoryBusinessRules;
    }

    public async Task<UpdatedSubCategoryDto> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
    {
        await _subCategoryBusinessRules.SubCategoryIdShouldExist(request.Id);
        await _subCategoryBusinessRules.MakeSureYouHaveACategory(request.CategoryId);

        var mappedSubCategory = _mapper.Map<SubCategory>(request);
        var updatedSubCategory = await _subCategoryRepository.UpdateAsync(mappedSubCategory);
        var updatedSubCategoryDto = _mapper.Map<UpdatedSubCategoryDto>(updatedSubCategory);
        return updatedSubCategoryDto;
    }
}
