using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using HotelBooking.Domain.Models;

namespace HotelBooking.Domain.Validation
{
    public class BookingValidation : AbstractValidator<Booking>
    {
        public BookingValidation()
        {
            RuleFor(x => x.Id);
            RuleFor(x => x.HotelId)
                .GreaterThan(0)
                .WithMessage("Hotel Id should be greater than 0");

            RuleFor(x => x.RoomId)
                .GreaterThan(0)
                .WithMessage("Room Id should be greater than 0");

            RuleFor(x => x.BookingStatusId)
                .GreaterThan(0)
                .WithMessage("Booking status Id should be greater than 0");

            RuleFor(x => x.UserId)
                .GreaterThan(0)
                .WithMessage("User Id should be greater than 0");

            RuleFor(x => x.StartDate)
                .NotEmpty()
                .WithMessage("Start date cannot be null")
                .LessThanOrEqualTo(x => x.EndDate)
                .WithMessage("Start date cannot be greater than end date");

            RuleFor(x => x.EndDate)
                .NotEmpty()
                .WithMessage("End date cannot be null")
                .GreaterThanOrEqualTo(x => x.StartDate)
                .WithMessage("End date cannot be less than start date");

            RuleFor(x => x.StartTime)
                .NotEmpty()
                .WithMessage("Start time cannot be null")
                .LessThanOrEqualTo(x => x.EndTime)
                .WithMessage("Start time cannot be greater than end time");

            RuleFor(x => x.EndTime)
                .NotEmpty()
                .WithMessage("End date cannot be null")
                .GreaterThanOrEqualTo(x => x.StartTime)
                .WithMessage("End time cannot be less than start time");
        }
    }
}
