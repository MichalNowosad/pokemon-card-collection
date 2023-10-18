using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonCardCollection.Domain.Constants;
using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Persistence.Configurations
{
    public class TrainerCardConfiguration : IEntityTypeConfiguration<TrainerCard>
    {
        public void Configure(EntityTypeBuilder<TrainerCard> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(CardConstants.NameMaxLength);

            builder.HasOne(e => e.Expansion)
                .WithMany(e => e.TrainerCards)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Illustrator)
                .WithMany(e => e.TrainerCards)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.EffectDescription)
                .HasMaxLength(CardConstants.EffectDescriptionMaxLength);
        }
    }
}
