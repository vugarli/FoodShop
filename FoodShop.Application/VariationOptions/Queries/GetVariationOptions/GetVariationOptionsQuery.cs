using FoodShop.Application.Filters;
using FoodShop.Application.Queries;
using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.VariationOptions.Queries.GetVariationOptions;

public record GetVariationOptionsQuery(params IFilter<VariationOption>[] filters) : IRequest<IQueryResult>;
