using MediatR;

namespace PokemonCardCollection.Application.Features.CardAttacks.Queries.GetCardAttacksOverview
{
    public class GetCardAttacksOverviewQuery : IRequest<IEnumerable<CardAttackOverviewDto>>
    {
    }
}
