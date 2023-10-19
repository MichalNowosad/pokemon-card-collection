using MediatR;
using Microsoft.AspNetCore.Mvc;
using PokemonCardCollection.Application.Features.Cards.Queries.GetCardsOverviewByExpansion;

namespace PokemonCardCollection.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("expansion/{expansionId}")]
        public async Task<IActionResult> GetCardsOverview(Guid expansionId)
        {
            var allCards = await _mediator.Send(new GetCardsOverviewByExpansionQuery(expansionId));

            return Ok(allCards);
        }
    }
}
