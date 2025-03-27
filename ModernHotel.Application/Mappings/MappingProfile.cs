using AutoMapper;
using ModernHotel.Application.DTOs;
using ModernHotel.Core.Entities;

namespace ModernHotel.Application.Mappings
{
    /// <summary>
    /// AutoMapper profile for mapping between entities and DTOs
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the MappingProfile class
        /// </summary>
        public MappingProfile()
        {
            // Room mappings
            CreateMap<Room, RoomDto>()
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.RoomType != null ? src.RoomType.Name : null))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.RoomType != null ? src.RoomType.BasePrice : 0))
                .ForMember(dest => dest.MaxOccupancy, opt => opt.MapFrom(src => src.RoomType != null ? src.RoomType.MaxOccupancy : 0));

            CreateMap<CreateRoomDto, Room>();
            CreateMap<UpdateRoomDto, Room>();

            // RoomType mappings
            CreateMap<RoomType, RoomTypeDto>()
                .ForMember(dest => dest.RoomCount, opt => opt.Ignore())
                .ForMember(dest => dest.AvailableRoomCount, opt => opt.Ignore());

            CreateMap<CreateRoomTypeDto, RoomType>();
            CreateMap<UpdateRoomTypeDto, RoomType>();

            // Customer mappings
            CreateMap<Customer, CustomerDto>();
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>();

            // Booking mappings
            CreateMap<Booking, BookingDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.FullName : null))
                .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.Room != null ? src.Room.Name : null))
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.Room != null && src.Room.RoomType != null ? src.Room.RoomType.Name : null));

            CreateMap<CreateBookingDto, Booking>();
            CreateMap<UpdateBookingDto, Booking>();

            // Service mappings
            CreateMap<Service, ServiceDto>()
                .ForMember(dest => dest.ServiceTypeName, opt => opt.MapFrom(src => src.ServiceType != null ? src.ServiceType.Name : null));

            CreateMap<CreateServiceDto, Service>();
            CreateMap<UpdateServiceDto, Service>();

            // ServiceType mappings
            CreateMap<ServiceType, ServiceTypeDto>();
            CreateMap<CreateServiceTypeDto, ServiceType>();
            CreateMap<UpdateServiceTypeDto, ServiceType>();

            // BookingService mappings
            CreateMap<BookingService, BookingServiceDto>()
                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service != null ? src.Service.Name : null))
                .ForMember(dest => dest.BookingReference, opt => opt.MapFrom(src => src.Booking != null ? src.Booking.ReferenceNumber : null));

            CreateMap<CreateBookingServiceDto, BookingService>();
            CreateMap<UpdateBookingServiceDto, BookingService>();

            // User mappings
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            // Bill mappings
            CreateMap<Bill, BillDto>()
                .ForMember(dest => dest.BookingReference, opt => opt.MapFrom(src => src.Booking != null ? src.Booking.ReferenceNumber : null))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Booking != null && src.Booking.Customer != null ? src.Booking.Customer.FullName : null))
                .ForMember(dest => dest.IssuedByName, opt => opt.MapFrom(src => src.IssuedBy != null ? src.IssuedBy.FullName : null));

            CreateMap<CreateBillDto, Bill>();
            CreateMap<UpdateBillDto, Bill>();
        }
    }
}
