using CarWorkshop.Application.CarWorkshop;

namespace CarWorkshop.Application.Services
{
    public interface ICarWorkshopService
    {
        Task Create(CarWorkshopDTO carWorkshop);
        Task<IEnumerable<CarWorkshopDTO>> GetAll();
    }
}