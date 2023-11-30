using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ACSystem.Domain.Entity;

namespace ACSystem.Persistence.Configurations.Entities
{
    public class LetterConfiguration : IEntityTypeConfiguration<Letter>
    {
        public void Configure(EntityTypeBuilder<Letter> builder)
        {

            builder.HasKey(a => a.Id);
            builder.HasQueryFilter(a=> !a.IsDeleted);

        
        }
    }
}
