using System.Collections.Generic;

namespace ModernHotel.Core.Entities
{
    /// <summary>
    /// Represents a type of service offered by the hotel
    /// </summary>
    public class ServiceType : BaseEntity
    {
        /// <summary>
        /// Name of the service type
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the service type
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Collection of services of this type
        /// </summary>
        public ICollection<Service> Services { get; set; } = new List<Service>();
    }
}
