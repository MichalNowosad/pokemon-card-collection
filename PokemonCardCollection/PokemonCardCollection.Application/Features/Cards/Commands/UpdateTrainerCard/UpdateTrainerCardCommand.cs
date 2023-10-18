using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdateTrainerCard
{
    public class UpdateTrainerCardCommand : IRequest<UpdateTrainerCardCommandResponse>
    {
        public UpdateTrainerCardDto TrainerCard { get; set; } = new UpdateTrainerCardDto();
    }
}
