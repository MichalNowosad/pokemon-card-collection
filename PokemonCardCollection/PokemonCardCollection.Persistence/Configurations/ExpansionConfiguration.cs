using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonCardCollection.Domain.Constants;
using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Persistence.Configurations
{
    public class ExpansionConfiguration : IEntityTypeConfiguration<Expansion>
    {
        public void Configure(EntityTypeBuilder<Expansion> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(ExpansionConstants.NameMaxLength);

            builder.Property(e => e.Abbreviation)
                .IsRequired()
                .HasMaxLength(ExpansionConstants.AbbreviationMaxLength);
        }
    }
}
