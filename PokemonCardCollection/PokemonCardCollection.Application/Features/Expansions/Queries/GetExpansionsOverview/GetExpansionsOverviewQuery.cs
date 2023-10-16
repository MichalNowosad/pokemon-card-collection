using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCardCollection.Application.Features.Expansions.Queries.GetExpansionsOverview
{
    public class GetExpansionsOverviewQuery : IRequest<IEnumerable<ExpansionOverviewDto>>
    {

    }
}
