using System;
using System.Collections.Generic;
using ModernHotel.Core.Enums;

namespace ModernHotel.Core.Entities
{
    /// <summary>
    /// Represents a hotel room
    /// </summary>
    public class Room : BaseEntity
    {
        /// <summary>
        /// Name or number of the room
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID of the room type
        /// </summary>
        public int RoomTypeId { get; set; }

        /// <summary>
        /// Navigation property for room type
        /// </summary>
        public RoomType RoomType { get; set; }

        /// <summary>
        /// Current status of the room (available, occupied, maintenance, etc.)
        /// </summary>
        public RoomStatus Status { get; set; }

        /// <summary>
        /// Description of the room
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Floor number where the room is located
        /// </summary>
        public int Floor { get; set; }

        /// <summary>
        /// Collection of bookings for this room
        /// </summary>
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }

}
