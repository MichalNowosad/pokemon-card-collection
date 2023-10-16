using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCardCollection.Application.Features.Cards.Queries.GetCardsOverviewByExpansion
{
    public class GetCardsOverviewByExpansionQuery : IRequest<IEnumerable<CardOverviewDto>>
    {
        public Guid ExpansionId { get; set; }
    }
}
