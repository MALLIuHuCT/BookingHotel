using System.Threading.Tasks;
using AutoMapper;
using HotelBooking.Domain.Models;

namespace HotelBooking.DataAccess.MSSQL
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<AdditionalService, Entities.AdditionalService>()
                .ReverseMap();
            CreateMap<AdditionalServiceType, Entities.AdditionalServiceType>()
                .ReverseMap();
            CreateMap<Booking, Entities.Booking>()
                .ReverseMap();
            CreateMap<BookingAdditionalService, Entities.BookingAdditionalService>()
                .ReverseMap();
            CreateMap<BookingAssignedPerson, Entities.BookingAssignedPerson>()
                .ReverseMap();
            CreateMap<BookingStatus, Entities.BookingStatus>()
                .ReverseMap();
            CreateMap<Cheque, Entities.Cheque>()
                .ReverseMap();
            CreateMap<City, Entities.City>()
                .ReverseMap();
            CreateMap<Hotel, Entities.Hotel>()
                .ReverseMap();
            CreateMap<HotelClassification, Entities.HotelClassification>()
                .ReverseMap();
            CreateMap<HotelImage, Entities.HotelImage>()
                .ReverseMap();
            CreateMap<PaymentType, Entities.PaymentType>()
                .ReverseMap();
            CreateMap<PersonImage, Entities.PersonImage>()
                .ReverseMap();
            CreateMap<PersonInfo, Entities.PersonInfo>()
                .ReverseMap();
            CreateMap<Room, Entities.Room>()
                .ReverseMap();
            CreateMap<RoomImage, Entities.RoomImage>()
                .ReverseMap();
            CreateMap<RoomInfo, Entities.RoomInfo>()
                .ReverseMap();
            CreateMap<RoomType, Entities.RoomType>()
                .ReverseMap();
            CreateMap<Street, Entities.Street>()
                .ReverseMap();
        }
    }
}
