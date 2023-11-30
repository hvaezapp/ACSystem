using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ACSystem.Domain.Entity;

namespace ACSystem.Persistence.Configurations.Entities
{
    public class LetterNoteConfiguration : IEntityTypeConfiguration<LetterNote>
    {
        public void Configure(EntityTypeBuilder<LetterNote> builder)
        {

            builder.HasKey(a => a.Id);
            builder.HasQueryFilter(a=> !a.IsDeleted);

        
        }
    }
}
