using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModernHotel.Application.DTOs;
using ModernHotel.Core.Enums;

namespace ModernHotel.Application.Interfaces
{
    /// <summary>
    /// Interface for Booking service
    /// </summary>
    public interface IBookingService
    {
        /// <summary>
        /// Gets all bookings
        /// </summary>
        /// <returns>Collection of booking DTOs</returns>
        Task<IEnumerable<BookingDto>> GetAllBookingsAsync();

        /// <summary>
        /// Gets a booking by ID
        /// </summary>
        /// <param name="id">Booking ID</param>
        /// <returns>Booking DTO if found, otherwise null</returns>
        Task<BookingDto> GetBookingByIdAsync(int id);

        /// <summary>
        /// Gets a booking by reference number
        /// </summary>
        /// <param name="referenceNumber">Booking reference number</param>
        /// <returns>Booking DTO if found, otherwise null</returns>
        Task<BookingDto> GetBookingByReferenceNumberAsync(string referenceNumber);

        /// <summary>
        /// Gets bookings by customer ID
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <returns>Collection of booking DTOs for the specified customer</returns>
        Task<IEnumerable<BookingDto>> GetBookingsByCustomerIdAsync(int customerId);

        /// <summary>
        /// Gets bookings by room ID
        /// </summary>
        /// <param name="roomId">Room ID</param>
        /// <returns>Collection of booking DTOs for the specified room</returns>
        Task<IEnumerable<BookingDto>> GetBookingsByRoomIdAsync(int roomId);

        /// <summary>
        /// Gets bookings by status
        /// </summary>
        /// <param name="status">Booking status</param>
        /// <returns>Collection of booking DTOs with the specified status</returns>
        Task<IEnumerable<BookingDto>> GetBookingsByStatusAsync(BookingStatus status);

        /// <summary>
        /// Gets bookings for a date range
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Collection of booking DTOs within the specified date range</returns>
        Task<IEnumerable<BookingDto>> GetBookingsByDateRangeAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Gets current bookings (checked in but not checked out)
        /// </summary>
        /// <returns>Collection of current booking DTOs</returns>
        Task<IEnumerable<BookingDto>> GetCurrentBookingsAsync();

        /// <summary>
        /// Gets upcoming bookings (not checked in yet)
        /// </summary>
        /// <returns>Collection of upcoming booking DTOs</returns>
        Task<IEnumerable<BookingDto>> GetUpcomingBookingsAsync();

        /// <summary>
        /// Creates a new booking
        /// </summary>
        /// <param name="createBookingDto">Data for creating the booking</param>
        /// <returns>Created booking DTO</returns>
        Task<BookingDto> CreateBookingAsync(CreateBookingDto createBookingDto);

        /// <summary>
        /// Updates an existing booking
        /// </summary>
        /// <param name="updateBookingDto">Data for updating the booking</param>
        /// <returns>Updated booking DTO if successful, otherwise null</returns>
        Task<BookingDto> UpdateBookingAsync(UpdateBookingDto updateBookingDto);

        /// <summary>
        /// Updates the status of a booking
        /// </summary>
        /// <param name="id">Booking ID</param>
        /// <param name="status">New booking status</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> UpdateBookingStatusAsync(int id, BookingStatus status);

        /// <summary>
        /// Checks in a booking
        /// </summary>
        /// <param name="id">Booking ID</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> CheckInAsync(int id);

        /// <summary>
        /// Checks out a booking
        /// </summary>
        /// <param name="id">Booking ID</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> CheckOutAsync(int id);

        /// <summary>
        /// Cancels a booking
        /// </summary>
        /// <param name="id">Booking ID</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> CancelBookingAsync(int id);

        /// <summary>
        /// Deletes a booking
        /// </summary>
        /// <param name="id">Booking ID</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> DeleteBookingAsync(int id);

        /// <summary>
        /// Checks if a booking exists
        /// </summary>
        /// <param name="id">Booking ID</param>
        /// <returns>True if the booking exists, otherwise false</returns>
        Task<bool> BookingExistsAsync(int id);

        /// <summary>
        /// Checks if a room is available for a date range
        /// </summary>
        /// <param name="roomId">Room ID</param>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <param name="excludeBookingId">Booking ID to exclude from the check (for updates)</param>
        /// <returns>True if the room is available, otherwise false</returns>
        Task<bool> IsRoomAvailableAsync(int roomId, DateTime startDate, DateTime endDate, int? excludeBookingId = null);

        /// <summary>
        /// Gets available rooms for a date range
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Collection of room DTOs available for the specified date range</returns>
        Task<IEnumerable<RoomDto>> GetAvailableRoomsForDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
