using System;

namespace ModernHotel.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for BookingService
    /// </summary>
    public class BookingServiceDto
    {
        /// <summary>
        /// ID of the booking service
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID of the booking
        /// </summary>
        public int BookingId { get; set; }

        /// <summary>
        /// Reference number of the booking
        /// </summary>
        public string BookingReference { get; set; }

        /// <summary>
        /// ID of the service
        /// </summary>
        public int ServiceId { get; set; }

        /// <summary>
        /// Name of the service
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Quantity of the service
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Price of the service at the time of booking
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Total price (Price * Quantity)
        /// </summary>
        public decimal TotalPrice => Price * Quantity;

        /// <summary>
        /// Date and time when the service was used
        /// </summary>
        public DateTime ServiceDate { get; set; }

        /// <summary>
        /// Notes or comments about the service
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Date and time when the booking service was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date and time when the booking service was last updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
