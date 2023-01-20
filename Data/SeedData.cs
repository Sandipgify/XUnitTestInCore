using DomainModel.Model;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Data
{
    public class SeedData
    {
        private readonly ClientDBContext _clientDBContext;

        public SeedData(ClientDBContext clientDBContext)
        {
            _clientDBContext = clientDBContext;
        }
        public async void Gender()
        {
            var exist = await _clientDBContext.Genders.AnyAsync(x => x.Name == "Male");
            if (!exist)
            {
                var genders = new List<Gender>
            {
                new Gender{Name = "Male"},
                new Gender{Name = "Female"}
            };

                _clientDBContext.Genders.AddRange(genders);
                _clientDBContext.SaveChanges();
            }
        }
    }
}
