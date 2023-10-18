using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonCardCollection.Domain.Constants;
using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Persistence.Configurations
{
    public class PokemonCardConfiguration : IEntityTypeConfiguration<PokemonCard>
    {
        public void Configure(EntityTypeBuilder<PokemonCard> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(CardConstants.NameMaxLength);

            builder.HasOne(e => e.Expansion)
                .WithMany(e => e.PokemonCards)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Illustrator)
                .WithMany(e => e.PokemonCards)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.PokemonDescription)
                .HasMaxLength(CardConstants.PokemonDescriptionMaxLength);

            builder.HasOne(e => e.Ability)
                .WithMany(e => e.PokemonCards)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
