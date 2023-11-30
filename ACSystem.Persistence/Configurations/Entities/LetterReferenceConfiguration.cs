using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ACSystem.Domain.Entity;
using System.Reflection.Emit;

namespace ACSystem.Persistence.Configurations.Entities
{
    public class LetterReferenceConfiguration : IEntityTypeConfiguration<LetterReference>
    {
        public void Configure(EntityTypeBuilder<LetterReference> builder)
        {

            builder.HasKey(a => a.Id);
            builder.HasQueryFilter(a=> !a.IsDeleted);




        

        }
    }
}
