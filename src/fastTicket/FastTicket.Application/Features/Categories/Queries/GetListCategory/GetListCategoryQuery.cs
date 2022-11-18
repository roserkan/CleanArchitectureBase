﻿using Core.Application.Requests;
using FastTicket.Application.Models.CategoryModels;
using MediatR;

namespace FastTicket.Application.Features.Categories.Queries.GetByIdCategory;

public class GetListCategoryQuery : IRequest<CategoryListModel>
{
    public PageRequest PageRequest { get; set; }
}