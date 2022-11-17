using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using HotelBooking.Domain.Models;

namespace HotelBooking.Domain.Validation
{
    public class CityValidation : AbstractValidator<City>
    {
        public CityValidation()
        {
            RuleFor(x => x.Id);
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name should be not null")
                .Length(1, 65)
                .WithMessage("Name max length is 65");
        }
}
}
