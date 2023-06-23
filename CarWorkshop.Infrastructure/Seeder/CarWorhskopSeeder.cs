using CarWorkshop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Seeder
{
    public class CarWorhskopSeeder
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorhskopSeeder(CarWorkshopDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync()) 
            {
                if(!_dbContext.CarWorkshops.Any())
                {
                    var mazdaAso = new Domain.Entities.CarWorkshop()
                    {
                        Name = "Mazda ASO",
                        Description = "Autoryzowany serwis Mazda",
                        ContactDetails = new()
                        {
                            City = "Kraków",
                            Adress = "Szewska 2",
                            PostalCode = "30-001",
                            PhoneNumber = "+48321654987"
                        }
                    };
                    mazdaAso.EncodeName();

                    _dbContext.CarWorkshops.Add(mazdaAso);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
