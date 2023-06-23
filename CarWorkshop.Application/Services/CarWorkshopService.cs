using CarWorkshop.Domain.Interfaces;


namespace CarWorkshop.Application.Services
{
    public class CarWorkshopService : ICarWorkshopService
    {
        private readonly ICarWrokshopRepository _carWrokshopRepository;

        public CarWorkshopService(ICarWrokshopRepository carWrokshopRepository)
        {
            _carWrokshopRepository = carWrokshopRepository;
        }

        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            carWorkshop.EncodeName();
            await _carWrokshopRepository.Create(carWorkshop);

        }
    }
}
