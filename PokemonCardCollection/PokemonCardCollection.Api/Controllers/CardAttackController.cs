using MediatR;
using Microsoft.AspNetCore.Mvc;
using PokemonCardCollection.Application.Features.CardAttacks.Commands.CreateCardAttack;
using PokemonCardCollection.Application.Features.CardAttacks.Commands.UpdateCardAttack;
using PokemonCardCollection.Application.Features.CardAttacks.Queries.GetCardAttackDetails;
using PokemonCardCollection.Application.Features.CardAttacks.Queries.GetCardAttacksOverview;

namespace PokemonCardCollection.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardAttackController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardAttackController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetCardAttacksOverview()
        {
            var allCardAttacks = await _mediator.Send(new GetCardAttacksOverviewQuery());

            return Ok(allCardAttacks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardAttackDetails(Guid id)
        {
            var cardAttack = await _mediator.Send(new GetCardAttackDetailsQuery(id));

            return Ok(cardAttack);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCardAttack(CreateCardAttackDto cardAttack)
        {
            await _mediator.Send(new CreateCardAttackCommand(cardAttack));

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCardAttack(UpdateCardAttackDto cardAttack)
        {
            await _mediator.Send(new UpdateCardAttackCommand(cardAttack));

            return Ok();
        }
    }
}
