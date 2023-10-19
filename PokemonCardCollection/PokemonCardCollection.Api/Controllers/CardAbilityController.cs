using MediatR;
using Microsoft.AspNetCore.Mvc;
using PokemonCardCollection.Application.Features.CardAbilities.Commands.CreateCardAbility;
using PokemonCardCollection.Application.Features.CardAbilities.Commands.UpdateCardAbility;
using PokemonCardCollection.Application.Features.CardAbilities.Queries.GetCardAbilitiesOverview;
using PokemonCardCollection.Application.Features.CardAbilities.Queries.GetCardAbilityDetails;

namespace PokemonCardCollection.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardAbilityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardAbilityController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetCardAbilitiesOverview()
        {
            var allCardAbilities = await _mediator.Send(new GetCardAbilitiesOverviewQuery());

            return Ok(allCardAbilities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardAbilityDetails(Guid id)
        {
            var cardAbility = await _mediator.Send(new GetCardAbilityDetailsQuery(id));

            return Ok(cardAbility);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCardAbility(CreateCardAbilityDto cardAbility)
        {
            await _mediator.Send(new CreateCardAbilityCommand(cardAbility));

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCardAbility(UpdateCardAbilityDto cardAbility)
        {
            await _mediator.Send(new UpdateCardAbilityCommand(cardAbility));

            return Ok();
        }
    }
}
