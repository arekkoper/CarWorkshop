using CarWorkshop.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarWorkshopServiceRespository
    {
        Task Create(CarWorkshopService carWorkshopService);
        Task<IEnumerable<CarWorkshopService>> GetAllByEncodedName(string encodedName);
    }
}
