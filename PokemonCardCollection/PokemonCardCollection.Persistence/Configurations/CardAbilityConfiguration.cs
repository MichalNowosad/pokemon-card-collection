using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonCardCollection.Domain.Constants;
using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Persistence.Configurations
{
    public class CardAbilityConfiguration : IEntityTypeConfiguration<CardAbility>
    {
        public void Configure(EntityTypeBuilder<CardAbility> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(CardAbilityConstants.NameMaxLength);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(CardAbilityConstants.DescriptionMaxLength);

            builder.HasMany(e => e.PokemonCards)
                .WithOne(e => e.Ability)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
