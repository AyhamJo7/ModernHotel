namespace ModernHotel.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for RoomType
    /// </summary>
    public class RoomTypeDto
    {
        /// <summary>
        /// ID of the room type
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the room type
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the room type
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Base price per night for this room type
        /// </summary>
        public decimal BasePrice { get; set; }

        /// <summary>
        /// Maximum number of people that can stay in this room type
        /// </summary>
        public int MaxOccupancy { get; set; }

        /// <summary>
        /// Amenities available in this room type (comma-separated)
        /// </summary>
        public string Amenities { get; set; }

        /// <summary>
        /// Number of rooms of this type
        /// </summary>
        public int RoomCount { get; set; }

        /// <summary>
        /// Number of available rooms of this type
        /// </summary>
        public int AvailableRoomCount { get; set; }
    }
}
