﻿using PokemonCardCollection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCardCollection.Application.Interfaces.Persistence
{
    public interface ITrainerCardRepository : IRepositoryBase<TrainerCard>
    {
        IQueryable<TrainerCard> GetByExpansionId(Guid expansionId);
    }
}
