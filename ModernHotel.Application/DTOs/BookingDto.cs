using System;
using ModernHotel.Core.Enums;

namespace ModernHotel.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for Booking
    /// </summary>
    public class BookingDto
    {
        /// <summary>
        /// ID of the booking
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Unique booking reference number
        /// </summary>
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// ID of the customer who made the booking
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Name of the customer who made the booking
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// ID of the room that is booked
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Name or number of the room
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        /// Name of the room type
        /// </summary>
        public string RoomTypeName { get; set; }

        /// <summary>
        /// Date and time of check-in
        /// </summary>
        public DateTime CheckInDate { get; set; }

        /// <summary>
        /// Date and time of check-out
        /// </summary>
        public DateTime CheckOutDate { get; set; }

        /// <summary>
        /// Actual date and time when the customer checked in
        /// </summary>
        public DateTime? ActualCheckInDate { get; set; }

        /// <summary>
        /// Actual date and time when the customer checked out
        /// </summary>
        public DateTime? ActualCheckOutDate { get; set; }

        /// <summary>
        /// Number of adults
        /// </summary>
        public int NumberOfAdults { get; set; }

        /// <summary>
        /// Number of children
        /// </summary>
        public int NumberOfChildren { get; set; }

        /// <summary>
        /// Special requests or notes for the booking
        /// </summary>
        public string SpecialRequests { get; set; }

        /// <summary>
        /// Total price of the booking
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Amount paid as deposit
        /// </summary>
        public decimal DepositAmount { get; set; }

        /// <summary>
        /// Status of the booking
        /// </summary>
        public BookingStatus Status { get; set; }

        /// <summary>
        /// Status of the booking as a string
        /// </summary>
        public string StatusName => Status.ToString();

        /// <summary>
        /// Duration of the booking in days
        /// </summary>
        public int DurationInDays => (CheckOutDate - CheckInDate).Days;

        /// <summary>
        /// Remaining balance to be paid
        /// </summary>
        public decimal RemainingBalance => TotalPrice - DepositAmount;

        /// <summary>
        /// Date and time when the booking was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date and time when the booking was last updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
