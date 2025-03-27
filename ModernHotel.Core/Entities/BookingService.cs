using System;

namespace ModernHotel.Core.Entities
{
    /// <summary>
    /// Represents a service used during a booking (junction table between Booking and Service)
    /// </summary>
    public class BookingService : BaseEntity
    {
        /// <summary>
        /// ID of the booking
        /// </summary>
        public int BookingId { get; set; }

        /// <summary>
        /// Navigation property for the booking
        /// </summary>
        public Booking Booking { get; set; }

        /// <summary>
        /// ID of the service
        /// </summary>
        public int ServiceId { get; set; }

        /// <summary>
        /// Navigation property for the service
        /// </summary>
        public Service Service { get; set; }

        /// <summary>
        /// Quantity of the service used
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Price of the service at the time of booking
        /// </summary>
        public decimal ServicePrice { get; set; }

        /// <summary>
        /// Total price for this service (Quantity * ServicePrice)
        /// </summary>
        public decimal TotalPrice => Quantity * ServicePrice;

        /// <summary>
        /// Date and time when the service was used
        /// </summary>
        public DateTime ServiceDate { get; set; }

        /// <summary>
        /// Notes or comments about the service usage
        /// </summary>
        public string Notes { get; set; }
    }
}
