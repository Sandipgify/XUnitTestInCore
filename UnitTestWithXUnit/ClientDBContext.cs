using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace UnitTestWithXUnit
{
    public class ClientDBContext : DbContext
    {
        #region DbSet
        public DbSet<Client> Clients { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public ClientDBContext(DbContextOptions<ClientDBContext> options) : base(options)
        {

        }
        #endregion
        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

    }
}
