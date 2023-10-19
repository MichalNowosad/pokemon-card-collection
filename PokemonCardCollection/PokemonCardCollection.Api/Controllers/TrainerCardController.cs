using MediatR;
using Microsoft.AspNetCore.Mvc;
using PokemonCardCollection.Application.Features.Cards.Commands.CreatePokemonCard;
using PokemonCardCollection.Application.Features.Cards.Commands.CreateTrainerCard;
using PokemonCardCollection.Application.Features.Cards.Commands.UpdatePokemonCard;
using PokemonCardCollection.Application.Features.Cards.Commands.UpdateTrainerCard;
using PokemonCardCollection.Application.Features.Cards.Queries.GetPokemonCardDetails;
using PokemonCardCollection.Application.Features.Cards.Queries.GetTrainerCardDetails;

namespace PokemonCardCollection.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainerCardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrainerCardController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainerCardDetails(Guid id)
        {
            var trainerCard = await _mediator.Send(new GetTrainerCardDetailsQuery(id));

            return Ok(trainerCard);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrainerCard()
        {
            await _mediator.Send(new CreateTrainerCardCommand(Request.Form));

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTrainerCard()
        {
            await _mediator.Send(new UpdateTrainerCardCommand(Request.Form));

            return Ok();
        }
    }
}
