using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCardCollection.Application.Features.Cards.Queries.GetTrainerCardDetails
{
    public class GetTrainerCardDetailsQuery : IRequest<TrainerCardDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
