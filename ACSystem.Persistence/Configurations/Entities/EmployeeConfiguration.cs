using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ACSystem.Domain.Entity;
using System.Reflection.Emit;

namespace ACSystem.Persistence.Configurations.Entities
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.HasKey(a => a.Id);
            builder.HasQueryFilter(a=> !a.IsDeleted);


            builder
                 .HasIndex(u => u.Email)
                 .IsUnique();


            builder
                 .HasIndex(u => u.IdentityCode)
                 .IsUnique();
        }
    }
}
