using MediatR;
using Microsoft.AspNetCore.Mvc;
using PokemonCardCollection.Application.Features.Cards.Commands.CreatePokemonCard;
using PokemonCardCollection.Application.Features.Cards.Commands.UpdatePokemonCard;
using PokemonCardCollection.Application.Features.Cards.Queries.GetPokemonCardDetails;

namespace PokemonCardCollection.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonCardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PokemonCardController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPokemonCardDetails(Guid id)
        {
            var pokemonCard = await _mediator.Send(new GetPokemonCardDetailsQuery(id));

            return Ok(pokemonCard);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePokemonCard()
        {
            await _mediator.Send(new CreatePokemonCardCommand(Request.Form));

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePokemonCard()
        {
            await _mediator.Send(new UpdatePokemonCardCommand(Request.Form));

            return Ok();
        }
    }
}
