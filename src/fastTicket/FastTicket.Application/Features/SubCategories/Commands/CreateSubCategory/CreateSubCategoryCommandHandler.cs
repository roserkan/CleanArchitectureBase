using AutoMapper;
using FastTicket.Application.Features.SubCategories.Dtos;
using FastTicket.Application.Features.SubCategories.Rules;
using FastTicket.Application.Interfaces.Repositories;
using FastTicket.Domain.Entities;
using MediatR;

namespace FastTicket.Application.Features.SubCategories.Commands.CreateSubSubCategory;

public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand, CreatedSubCategoryDto>
{
    private readonly ISubCategoryRepository _subCategoryRepository;
    private readonly IMapper _mapper;
    private readonly SubCategoryBusinessRules _subCategoryBusinessRules;

    public CreateSubCategoryCommandHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper, SubCategoryBusinessRules subCategoryBusinessRules)
    {
        _subCategoryRepository = subCategoryRepository;
        _mapper = mapper;
        _subCategoryBusinessRules = subCategoryBusinessRules;
    }

    public async Task<CreatedSubCategoryDto> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
    {
        await _subCategoryBusinessRules.MakeSureYouHaveACategory(request.CategoryId);
        var mappedSubCategory = _mapper.Map<SubCategory>(request);
        var createdSubCategory = await _subCategoryRepository.AddAsync(mappedSubCategory);
        var createdSubCategoryDto = _mapper.Map<CreatedSubCategoryDto>(createdSubCategory);
        return createdSubCategoryDto;
    }
}

