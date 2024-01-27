using FoodShop.Application.Filters;
using FoodShop.Application.Queries;
using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.Variations.Queries.GetVariations;

public record GetVariationsQuery(params IFilter<Variation>[] filters) : IRequest<IQueryResult>;
