using DomainModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfiguration
{
    public class GenderEntityConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable(nameof(Gender));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50);
        }
    }
}
