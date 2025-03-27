using System;

namespace ModernHotel.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for ServiceType
    /// </summary>
    public class ServiceTypeDto
    {
        /// <summary>
        /// ID of the service type
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the service type
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the service type
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Number of services of this type
        /// </summary>
        public int ServiceCount { get; set; }

        /// <summary>
        /// Date and time when the service type was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date and time when the service type was last updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
