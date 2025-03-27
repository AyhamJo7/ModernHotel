using ModernHotel.Core.Enums;

namespace ModernHotel.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for Room
    /// </summary>
    public class RoomDto
    {
        /// <summary>
        /// ID of the room
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name or number of the room
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID of the room type
        /// </summary>
        public int RoomTypeId { get; set; }

        /// <summary>
        /// Name of the room type
        /// </summary>
        public string RoomTypeName { get; set; }

        /// <summary>
        /// Current status of the room
        /// </summary>
        public RoomStatus Status { get; set; }

        /// <summary>
        /// Status of the room as a string
        /// </summary>
        public string StatusName => Status.ToString();

        /// <summary>
        /// Description of the room
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Floor number where the room is located
        /// </summary>
        public int Floor { get; set; }

        /// <summary>
        /// Price of the room per night
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Maximum number of people that can stay in the room
        /// </summary>
        public int MaxOccupancy { get; set; }

        /// <summary>
        /// Indicates if the room is currently available
        /// </summary>
        public bool IsAvailable => Status == RoomStatus.Available;
    }
}
