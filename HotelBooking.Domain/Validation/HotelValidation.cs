using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using HotelBooking.Domain.Models;

namespace HotelBooking.Domain.Validation
{
    public class HotelValidation : AbstractValidator<Hotel>
    {
        public HotelValidation()
        {
            RuleFor(x => x.Id);
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name should be not null")
                .Length(1, 65)
                .WithMessage("Name max length is 65");

            RuleFor(x => x.HotelClassId)
                .GreaterThan(0)
                .WithMessage("Classification Id should be greater than 0");

            RuleFor(x => (int)x.Stars)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Stars count should be not less than 0")
                .LessThanOrEqualTo(5)
                .WithMessage("Stars count cant be more than 5");

            RuleFor(x => x.StreetId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Street id cannot be less than 1");

            RuleFor(x => (int)x.HomeNumber)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Home number cannot be less than 1");

            RuleFor(x => x.ImageId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Image id cannot be less than 1");
        }
    }
}
