﻿using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceCommandHandler : IRequestHandler<CreateCarWorkshopServiceCommand>
    {
        private readonly IUserContext _userContext;
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly ICarWorkshopServiceRespository _carWorkshopServiceRespository;

        public CreateCarWorkshopServiceCommandHandler(IUserContext userContext, ICarWorkshopRepository carWorkshopRepository, ICarWorkshopServiceRespository carWorkshopServiceRespository)
        {
            _userContext = userContext;
            _carWorkshopRepository = carWorkshopRepository;
            _carWorkshopServiceRespository = carWorkshopServiceRespository;
        }

        public async Task<Unit> Handle(CreateCarWorkshopServiceCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.CarWorkshopEncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (carWorkshop.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (!isEditable)
            {
                return Unit.Value;
            }

            var carWorkshopService = new Domain.Entities.CarWorkshopService()
            {
                Cost = request.Cost,
                Description = request.Description,
                CarWorkshopId = carWorkshop.Id
            };

            await _carWorkshopServiceRespository.Create(carWorkshopService);

            return Unit.Value;
        }
    }
}