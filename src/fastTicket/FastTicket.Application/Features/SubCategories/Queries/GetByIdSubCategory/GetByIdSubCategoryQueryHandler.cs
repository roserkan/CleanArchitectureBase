using AutoMapper;
using FastTicket.Application.Features.SubCategories.Dtos;
using FastTicket.Application.Features.SubCategories.Rules;
using FastTicket.Application.Interfaces.Repositories;
using MediatR;

namespace FastTicket.Application.Features.SubCategories.Queries.GetByIdSubCategory;

public class GetByIdSubCategoryQueryHandler : IRequestHandler<GetByIdSubCategoryQuery, SubCategoryDto>
{
    private readonly ISubCategoryRepository _subCategoryRepository;
    private readonly IMapper _mapper;
    private readonly SubCategoryBusinessRules _subCategoryBusinessRules;
    public GetByIdSubCategoryQueryHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper, SubCategoryBusinessRules subCategoryBusinessRules)
    {
        _subCategoryRepository = subCategoryRepository;
        _mapper = mapper;
        _subCategoryBusinessRules = subCategoryBusinessRules;
    }

    public async Task<SubCategoryDto> Handle(GetByIdSubCategoryQuery request, CancellationToken cancellationToken)
    {
        await _subCategoryBusinessRules.SubCategoryIdShouldExist(request.Id);

        var subCategory = await _subCategoryRepository.GetAsync(b => b.Id == request.Id);
        SubCategoryDto subCategoryDto = _mapper.Map<SubCategoryDto>(subCategory);
        return subCategoryDto;
    }
}

