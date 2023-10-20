using PokemonCardCollection.Application.Responses;

namespace PokemonCardCollection.Application.Features.Cards.Queries.GetTrainerCardDetails
{
    public class GetTrainerCardDetailsQueryResponse : ResponseBase
    {
        public GetTrainerCardDetailsQueryResponse(TrainerCardDetailsDto trainerCard) : base()
        {
            TrainerCard = trainerCard;
        }

        public TrainerCardDetailsDto TrainerCard { get; set; }
    }
}
