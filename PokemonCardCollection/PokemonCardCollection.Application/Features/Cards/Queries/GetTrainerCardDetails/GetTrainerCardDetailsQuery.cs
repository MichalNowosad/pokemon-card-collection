﻿using MediatR;

namespace PokemonCardCollection.Application.Features.Cards.Queries.GetTrainerCardDetails
{
    public class GetTrainerCardDetailsQuery : IRequest<GetTrainerCardDetailsQueryResponse>
    {
        public GetTrainerCardDetailsQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
