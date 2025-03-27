using System.ComponentModel.DataAnnotations;

namespace ModernHotel.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for updating an existing ServiceType
    /// </summary>
    public class UpdateServiceTypeDto
    {
        /// <summary>
        /// ID of the service type
        /// </summary>
        [Required(ErrorMessage = "Service type ID is required")]
        public int Id { get; set; }

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
