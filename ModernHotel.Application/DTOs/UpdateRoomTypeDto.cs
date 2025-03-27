using System.ComponentModel.DataAnnotations;

namespace ModernHotel.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for updating an existing RoomType
    /// </summary>
    public class UpdateRoomTypeDto
    {
        /// <summary>
        /// ID of the room type
        /// </summary>
        [Required(ErrorMessage = "Room type ID is required")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the room type
        /// </summary>
        [Required(ErrorMessage = "Room type name is required")]
        [StringLength(100, ErrorMessage = "Room type name cannot exceed 100 characters")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the room type
        /// </summary>
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; }

        /// <summary>
        /// Base price per night for this room type
        /// </summary>
        [Required(ErrorMessage = "Base price is required")]
        [Range(0.01, 100000, ErrorMessage = "Base price must be greater than 0")]
        public decimal BasePrice { get; set; }

        /// <summary>
        /// Maximum number of people that can stay in this room type
        /// </summary>
        [Required(ErrorMessage = "Maximum occupancy is required")]
        [Range(1, 20, ErrorMessage = "Maximum occupancy must be between 1 and 20")]
        public int MaxOccupancy { get; set; }

        /// <summary>
        /// Amenities available in this room type (comma-separated)
        /// </summary>
        [StringLength(1000, ErrorMessage = "Amenities cannot exceed 1000 characters")]
        public string Amenities { get; set; }
    }
}
