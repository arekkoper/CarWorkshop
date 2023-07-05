using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Interfaces;


namespace CarWorkshop.Application.Services
{
    public class CarWorkshopService : ICarWorkshopService
    {
        private readonly ICarWrokshopRepository _carWrokshopRepository;
        private readonly IMapper _mapper;

        public CarWorkshopService(ICarWrokshopRepository carWrokshopRepository, IMapper mapper)
        {
            _carWrokshopRepository = carWrokshopRepository;
            _mapper = mapper;
        }

        public async Task Create(CarWorkshopDTO carWorkshopDTO)
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(carWorkshopDTO);

            carWorkshop.EncodeName();
            await _carWrokshopRepository.Create(carWorkshop);

        }
    }
}
