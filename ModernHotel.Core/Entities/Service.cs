using System.Collections.Generic;

namespace ModernHotel.Core.Entities
{
    /// <summary>
    /// Represents a service offered by the hotel
    /// </summary>
    public class Service : BaseEntity
    {
        /// <summary>
        /// Name of the service
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the service
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Price of the service
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// ID of the service type
        /// </summary>
        public int ServiceTypeId { get; set; }

        /// <summary>
        /// Navigation property for service type
        /// </summary>
        public ServiceType ServiceType { get; set; }

        /// <summary>
        /// Collection of booking services
        /// </summary>
        public ICollection<BookingService> BookingServices { get; set; } = new List<BookingService>();

        /// <summary>
        /// Indicates if the service is currently available
        /// </summary>
        public bool IsAvailable { get; set; } = true;
    }
}
