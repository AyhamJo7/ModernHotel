using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModernHotel.Application.DTOs;

namespace ModernHotel.Application.Interfaces
{
    /// <summary>
    /// Interface for BookingService service
    /// </summary>
    public interface IBookingServiceService
    {
        /// <summary>
        /// Gets all booking services
        /// </summary>
        /// <returns>Collection of booking service DTOs</returns>
        Task<IEnumerable<BookingServiceDto>> GetAllBookingServicesAsync();

        /// <summary>
        /// Gets a booking service by ID
        /// </summary>
        /// <param name="id">Booking service ID</param>
        /// <returns>Booking service DTO if found, otherwise null</returns>
        Task<BookingServiceDto> GetBookingServiceByIdAsync(int id);

        /// <summary>
        /// Gets booking services by booking ID
        /// </summary>
        /// <param name="bookingId">Booking ID</param>
        /// <returns>Collection of booking service DTOs for the specified booking</returns>
        Task<IEnumerable<BookingServiceDto>> GetBookingServicesByBookingIdAsync(int bookingId);

        /// <summary>
        /// Gets booking services by service ID
        /// </summary>
        /// <param name="serviceId">Service ID</param>
        /// <returns>Collection of booking service DTOs for the specified service</returns>
        Task<IEnumerable<BookingServiceDto>> GetBookingServicesByServiceIdAsync(int serviceId);

        /// <summary>
        /// Gets booking services by date range
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Collection of booking service DTOs within the specified date range</returns>
        Task<IEnumerable<BookingServiceDto>> GetBookingServicesByDateRangeAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Creates a new booking service
        /// </summary>
        /// <param name="createBookingServiceDto">Data for creating the booking service</param>
        /// <returns>Created booking service DTO</returns>
        Task<BookingServiceDto> CreateBookingServiceAsync(CreateBookingServiceDto createBookingServiceDto);

        /// <summary>
        /// Updates an existing booking service
        /// </summary>
        /// <param name="updateBookingServiceDto">Data for updating the booking service</param>
        /// <returns>Updated booking service DTO if successful, otherwise null</returns>
        Task<BookingServiceDto> UpdateBookingServiceAsync(UpdateBookingServiceDto updateBookingServiceDto);

        /// <summary>
        /// Deletes a booking service
        /// </summary>
        /// <param name="id">Booking service ID</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> DeleteBookingServiceAsync(int id);

        /// <summary>
        /// Checks if a booking service exists
        /// </summary>
        /// <param name="id">Booking service ID</param>
        /// <returns>True if the booking service exists, otherwise false</returns>
        Task<bool> BookingServiceExistsAsync(int id);

        /// <summary>
        /// Gets the total price of all services for a booking
        /// </summary>
        /// <param name="bookingId">Booking ID</param>
        /// <returns>Total price of all services for the booking</returns>
        Task<decimal> GetTotalServicePriceForBookingAsync(int bookingId);

        /// <summary>
        /// Gets the most popular services
        /// </summary>
        /// <param name="count">Number of services to return</param>
        /// <returns>Collection of the most popular services</returns>
        Task<IEnumerable<ServiceDto>> GetMostPopularServicesAsync(int count);
    }
}
