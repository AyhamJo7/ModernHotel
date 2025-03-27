using System;
using System.ComponentModel.DataAnnotations;
using ModernHotel.Core.Enums;

namespace ModernHotel.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for updating an existing Booking
    /// </summary>
    public class UpdateBookingDto
    {
        /// <summary>
        /// ID of the booking
        /// </summary>
        [Required(ErrorMessage = "Booking ID is required")]
        public int Id { get; set; }

        /// <summary>
        /// ID of the customer who made the booking
        /// </summary>
        [Required(ErrorMessage = "Customer is required")]
        public int CustomerId { get; set; }

        /// <summary>
        /// ID of the room that is booked
        /// </summary>
        [Required(ErrorMessage = "Room is required")]
        public int RoomId { get; set; }

        /// <summary>
        /// Date and time of check-in
        /// </summary>
        [Required(ErrorMessage = "Check-in date is required")]
        public DateTime CheckInDate { get; set; }

        /// <summary>
        /// Date and time of check-out
        /// </summary>
        [Required(ErrorMessage = "Check-out date is required")]
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
        [Required(ErrorMessage = "Number of adults is required")]
        [Range(1, 10, ErrorMessage = "Number of adults must be between 1 and 10")]
        public int NumberOfAdults { get; set; }

        /// <summary>
        /// Number of children
        /// </summary>
        [Range(0, 10, ErrorMessage = "Number of children must be between 0 and 10")]
        public int NumberOfChildren { get; set; }

        /// <summary>
        /// Special requests or notes for the booking
        /// </summary>
        [StringLength(1000, ErrorMessage = "Special requests cannot exceed 1000 characters")]
        public string SpecialRequests { get; set; }

        /// <summary>
        /// Total price of the booking
        /// </summary>
        [Required(ErrorMessage = "Total price is required")]
        [Range(0.01, 1000000, ErrorMessage = "Total price must be greater than 0")]
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Amount paid as deposit
        /// </summary>
        [Range(0, 1000000, ErrorMessage = "Deposit amount must be between 0 and 1,000,000")]
        public decimal DepositAmount { get; set; }

        /// <summary>
        /// Status of the booking
        /// </summary>
        [Required(ErrorMessage = "Booking status is required")]
        public BookingStatus Status { get; set; }
    }
}
