using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop
{
    public class CarWorkshopDTOValidator : AbstractValidator<CarWorkshopDTO>
    {
        public CarWorkshopDTOValidator(ICarWrokshopRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(2).WithMessage("Name should have at least 2 characters")
                .MaximumLength(20)
                .Custom((value, context) => 
                {
                    var existingCarWorkshop = repository.GetByName(value).Result;
                    if(existingCarWorkshop != null) 
                    {
                        context.AddFailure($"\"{value}\" is not unique name for a car workshop");
                    }
                });

            RuleFor(c => c.Description)
                .NotEmpty();

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
