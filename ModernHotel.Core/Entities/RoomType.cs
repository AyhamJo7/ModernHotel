using System.Collections.Generic;

namespace ModernHotel.Core.Entities
{
    /// <summary>
    /// Represents a type of room in the hotel (e.g., Single, Double, Suite)
    /// </summary>
    public class RoomType : BaseEntity
    {
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
        /// Collection of rooms of this type
        /// </summary>
        public ICollection<Room> Rooms { get; set; } = new List<Room>();

        /// <summary>
        /// Amenities available in this room type (comma-separated)
        /// </summary>
        public string Amenities { get; set; }
    }
}
