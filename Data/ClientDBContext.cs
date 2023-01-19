using Data.EntityConfiguration;
using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ClientDBContext : DbContext
    {
        #region DbSet
        public DbSet<Client> Clients { get; set; }
        public DbSet<Gender> Genders { get; set; }
        #endregion
        public ClientDBContext(DbContextOptions<ClientDBContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new ClientEntityConfiguration())
                .ApplyConfiguration(new GenderEntityConfiguration());
        }

    }
}
