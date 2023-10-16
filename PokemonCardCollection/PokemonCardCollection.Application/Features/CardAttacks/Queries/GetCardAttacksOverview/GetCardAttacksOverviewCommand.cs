using MediatR;

namespace PokemonCardCollection.Application.Features.CardAttacks.Queries.GetCardAttacksOverview
{
    public class GetCardAttacksOverviewCommand : IRequest<IEnumerable<CardAttackOverviewDto>>
    {
    }
}
