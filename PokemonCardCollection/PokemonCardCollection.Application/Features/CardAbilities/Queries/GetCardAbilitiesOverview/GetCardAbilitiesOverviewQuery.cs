using MediatR;

namespace PokemonCardCollection.Application.Features.CardAbilities.Queries.GetCardAbilitiesOverview
{
    public class GetCardAbilitiesOverviewQuery : IRequest<IEnumerable<CardAbilityOverviewDto>>
    {
    }
}
