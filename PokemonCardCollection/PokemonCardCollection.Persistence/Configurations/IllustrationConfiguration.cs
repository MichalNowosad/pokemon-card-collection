using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonCardCollection.Domain.Constants;
using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Persistence.Configurations
{
    public class IllustrationConfiguration : IEntityTypeConfiguration<Illustrator>
    {
        public void Configure(EntityTypeBuilder<Illustrator> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(IllustratorConstants.NameMaxLength);
        }
    }
}
