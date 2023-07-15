using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshopService.Queries
{
    public class GetCarWorkshopServiceQueryHandler : IRequestHandler<GetCarWorkshopServiceQuery, IEnumerable<CarWorkshopServiceDto>>
    {
        private readonly ICarWorkshopServiceRespository _carWorkshopServiceRespository;
        private readonly IMapper _mapper;

        public GetCarWorkshopServiceQueryHandler(ICarWorkshopServiceRespository carWorkshopServiceRespository, IMapper mapper)
        {
            _carWorkshopServiceRespository = carWorkshopServiceRespository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarWorkshopServiceDto>> Handle(GetCarWorkshopServiceQuery request, CancellationToken cancellationToken)
        {
            var result = await _carWorkshopServiceRespository.GetAllByEncodedName(request.EncodedName);
            var dtos = _mapper.Map<IEnumerable<CarWorkshopServiceDto>>(result);
            return dtos;
        }
    }
}