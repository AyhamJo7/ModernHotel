using System.ComponentModel.DataAnnotations;
using ModernHotel.Core.Enums;

namespace ModernHotel.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for creating a new Room
    /// </summary>
    public class CreateRoomDto
    {
        /// <summary>
        /// Name or number of the room
        /// </summary>
        [Required(ErrorMessage = "Room name/number is required")]
        [StringLength(50, ErrorMessage = "Room name/number cannot exceed 50 characters")]
        public string Name { get; set; }

        /// <summary>
        /// ID of the room type
        /// </summary>
        [Required(ErrorMessage = "Room type is required")]
        public int RoomTypeId { get; set; }

        /// <summary>
        /// Current status of the room
        /// </summary>
        [Required(ErrorMessage = "Room status is required")]
        public RoomStatus Status { get; set; } = RoomStatus.Available;

        /// <summary>
        /// Description of the room
        /// </summary>
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; }

        /// <summary>
        /// Floor number where the room is located
        /// </summary>
        [Required(ErrorMessage = "Floor number is required")]
        [Range(1, 100, ErrorMessage = "Floor number must be between 1 and 100")]
        public int Floor { get; set; }
    }
}
