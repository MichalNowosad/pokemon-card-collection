using MediatR;
using Microsoft.AspNetCore.Mvc;
using PokemonCardCollection.Application.Features.Cards.Commands.CreatePokemonCard;
using PokemonCardCollection.Application.Features.Cards.Commands.UpdatePokemonCard;
using PokemonCardCollection.Application.Features.Cards.Queries.GetCardsOverviewByExpansion;
using PokemonCardCollection.Application.Features.Cards.Queries.GetPokemonCardDetails;
using PokemonCardCollection.Application.Features.Expansions.Commands.CreateExpansion;
using PokemonCardCollection.Application.Features.Expansions.Commands.UpdateExpansion;
using PokemonCardCollection.Application.Features.Expansions.Queries.GetExpansionDetails;
using PokemonCardCollection.Application.Features.Expansions.Queries.GetExpansionsOverview;

namespace PokemonCardCollection.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpansionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpansionController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetExpansionsOverview()
        {
            var allExpansions = await _mediator.Send(new GetExpansionsOverviewQuery());

            return Ok(allExpansions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpansionDetails(Guid id)
        {
            var expansion = await _mediator.Send(new GetExpansionDetailsQuery(id));

            return Ok(expansion);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpansion()
        {
            await _mediator.Send(new CreateExpansionCommand(Request.Form));

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExpansion()
        {
            await _mediator.Send(new UpdateExpansionCommand(Request.Form));

            return Ok();
        }
    }
}
