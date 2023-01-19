using DomainModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfiguration
{
    public class ClientEntityConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable(nameof(Client));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(300).IsRequired(false);
            builder.Property(x => x.CreateDate).HasDefaultValue(DateTime.Now).IsRequired(true);
            builder.Property(x => x.GenderId).IsRequired(true);
        }
    }
}
