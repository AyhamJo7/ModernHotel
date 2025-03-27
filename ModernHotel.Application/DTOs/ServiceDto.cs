using System;

namespace ModernHotel.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for Service
    /// </summary>
    public class ServiceDto
    {
        /// <summary>
        /// ID of the service
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the service
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID of the service type
        /// </summary>
        public int ServiceTypeId { get; set; }

        /// <summary>
        /// Name of the service type
        /// </summary>
        public string ServiceTypeName { get; set; }

        /// <summary>
        /// Description of the service
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Price of the service
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Indicates if the service is available
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Date and time when the service was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date and time when the service was last updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
