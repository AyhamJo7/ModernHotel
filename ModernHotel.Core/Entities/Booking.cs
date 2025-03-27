using System;
using System.Collections.Generic;
using ModernHotel.Core.Enums;

namespace ModernHotel.Core.Entities
{
    /// <summary>
    /// Represents a booking in the hotel
    /// </summary>
    public class Booking : BaseEntity
    {
        /// <summary>
        /// Unique booking reference number
        /// </summary>
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// ID of the customer who made the booking
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Navigation property for the customer
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// ID of the room that is booked
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Navigation property for the room
        /// </summary>
        public Room Room { get; set; }

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
        /// Collection of services used during this booking
        /// </summary>
        public ICollection<BookingService> BookingServices { get; set; } = new List<BookingService>();

        /// <summary>
        /// Gets the duration of the booking in days
        /// </summary>
        public int DurationInDays => (CheckOutDate - CheckInDate).Days;

        /// <summary>
        /// Gets the remaining balance to be paid
        /// </summary>
        public decimal RemainingBalance => TotalPrice - DepositAmount;
    }
}
