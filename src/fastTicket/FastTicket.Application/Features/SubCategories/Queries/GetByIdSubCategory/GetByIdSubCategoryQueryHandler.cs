using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using FastTicket.Application.Constants;
using FastTicket.Application.Dtos.SubCategoryDtos;
using FastTicket.Application.Interfaces.Repositories;
using MediatR;

namespace FastTicket.Application.Features.SubCategories.Queries.GetByIdSubCategory;

public class GetByIdSubCategoryQueryHandler : IRequestHandler<GetByIdSubCategoryQuery, SubCategoryDto>
{
    private readonly ISubCategoryRepository _subCategoryRepository;
    private readonly IMapper _mapper;
    public GetByIdSubCategoryQueryHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
    {
        _subCategoryRepository = subCategoryRepository;
        _mapper = mapper;
    }

    public async Task<SubCategoryDto> Handle(GetByIdSubCategoryQuery request, CancellationToken cancellationToken)
    {
        await SubCategoryIdShouldExist(request.Id);

        var subCategory = await _subCategoryRepository.GetAsync(b => b.Id == request.Id);
        SubCategoryDto subCategoryDto = _mapper.Map<SubCategoryDto>(subCategory);
        return subCategoryDto;
    }

    private async Task SubCategoryIdShouldExist(Guid id)
    {
        var result = await _subCategoryRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(Messages.SubCategory_NotFound);
    }
}

