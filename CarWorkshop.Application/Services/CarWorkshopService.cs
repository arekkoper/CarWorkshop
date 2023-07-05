using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IEnumerable<CarWorkshopDTO>> GetAll()
        {
            var carWorkshops = await _carWrokshopRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<CarWorkshopDTO>>(carWorkshops);

            return dtos;
        }
    }
}
