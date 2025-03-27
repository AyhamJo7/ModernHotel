using System.ComponentModel.DataAnnotations;

namespace ModernHotel.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for creating a new ServiceType
    /// </summary>
    public class CreateServiceTypeDto
    {
        /// <summary>
        /// Name of the service type
        /// </summary>
        [Required(ErrorMessage = "Service type name is required")]
        [StringLength(100, ErrorMessage = "Service type name cannot exceed 100 characters")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the service type
        /// </summary>
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; }
    }
}
