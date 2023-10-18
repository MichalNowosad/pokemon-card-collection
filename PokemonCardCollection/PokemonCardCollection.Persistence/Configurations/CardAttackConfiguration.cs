using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonCardCollection.Domain.Constants;
using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Persistence.Configurations
{
    public class CardAttackConfiguration : IEntityTypeConfiguration<CardAttack>
    {
        public void Configure(EntityTypeBuilder<CardAttack> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(CardAttackConstants.NameMaxLength);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(CardAttackConstants.DescriptionMaxLength);

            builder.HasMany(e => e.PokemonCards)
                .WithMany(e => e.Attacks)
                .UsingEntity<Dictionary<string, object>>(
                    b => b.HasOne<PokemonCard>().WithMany().HasForeignKey("PokemonCardId"),
                    b => b.HasOne<CardAttack>().WithMany().HasForeignKey("CardAttackId"))
                .ToTable("PokemonCardAttacks");
        }
    }
}
