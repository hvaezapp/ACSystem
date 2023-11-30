using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ACSystem.Domain.Entity;

namespace ACSystem.Persistence.Configurations.Entities
{
    public class LetterTypeConfiguration : IEntityTypeConfiguration<LetterType>
    {
        public void Configure(EntityTypeBuilder<LetterType> builder)
        {

            builder.HasKey(a => a.Id);
            builder.HasQueryFilter(a=> !a.IsDeleted);

        
        }
    }
}
