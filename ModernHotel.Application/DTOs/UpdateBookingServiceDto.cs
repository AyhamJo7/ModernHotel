using System;
using System.ComponentModel.DataAnnotations;

namespace ModernHotel.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for updating an existing BookingService
    /// </summary>
    public class UpdateBookingServiceDto
    {
        /// <summary>
        /// ID of the booking service
        /// </summary>
        [Required(ErrorMessage = "Booking service ID is required")]
        public int Id { get; set; }

        /// <summary>
        /// ID of the booking
        /// </summary>
        [Required(ErrorMessage = "Booking ID is required")]
        public int BookingId { get; set; }

        /// <summary>
        /// ID of the service
        /// </summary>
        [Required(ErrorMessage = "Service ID is required")]
        public int ServiceId { get; set; }

        /// <summary>
        /// Quantity of the service
        /// </summary>
        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
        public int Quantity { get; set; }

        /// <summary>
        /// Price of the service at the time of booking
        /// </summary>
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100000, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        /// <summary>
        /// Date and time when the service was used
        /// </summary>
        [Required(ErrorMessage = "Service date is required")]
        public DateTime ServiceDate { get; set; }

        /// <summary>
        /// Notes or comments about the service
        /// </summary>
        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        public string Notes { get; set; }
    }
}
