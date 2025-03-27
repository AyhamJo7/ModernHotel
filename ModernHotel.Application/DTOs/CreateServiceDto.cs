using System.ComponentModel.DataAnnotations;

namespace ModernHotel.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for creating a new Service
    /// </summary>
    public class CreateServiceDto
    {
        /// <summary>
        /// Name of the service
        /// </summary>
        [Required(ErrorMessage = "Service name is required")]
        [StringLength(100, ErrorMessage = "Service name cannot exceed 100 characters")]
        public string Name { get; set; }

        /// <summary>
        /// ID of the service type
        /// </summary>
        [Required(ErrorMessage = "Service type is required")]
        public int ServiceTypeId { get; set; }

        /// <summary>
        /// Description of the service
        /// </summary>
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; }

        /// <summary>
        /// Price of the service
        /// </summary>
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100000, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        /// <summary>
        /// Indicates if the service is available
        /// </summary>
        public bool IsAvailable { get; set; } = true;
    }
}
