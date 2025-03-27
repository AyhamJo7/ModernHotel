using System.Collections.Generic;
using System.Threading.Tasks;
using ModernHotel.Application.DTOs;
using ModernHotel.Core.Enums;

namespace ModernHotel.Application.Interfaces
{
    /// <summary>
    /// Interface for Room service
    /// </summary>
    public interface IRoomService
    {
        /// <summary>
        /// Gets all rooms
        /// </summary>
        /// <returns>Collection of room DTOs</returns>
        Task<IEnumerable<RoomDto>> GetAllRoomsAsync();

        /// <summary>
        /// Gets a room by ID
        /// </summary>
        /// <param name="id">Room ID</param>
        /// <returns>Room DTO if found, otherwise null</returns>
        Task<RoomDto> GetRoomByIdAsync(int id);

        /// <summary>
        /// Gets rooms by status
        /// </summary>
        /// <param name="status">Room status</param>
        /// <returns>Collection of room DTOs with the specified status</returns>
        Task<IEnumerable<RoomDto>> GetRoomsByStatusAsync(RoomStatus status);

        /// <summary>
        /// Gets rooms by room type
        /// </summary>
        /// <param name="roomTypeId">Room type ID</param>
        /// <returns>Collection of room DTOs with the specified room type</returns>
        Task<IEnumerable<RoomDto>> GetRoomsByRoomTypeAsync(int roomTypeId);

        /// <summary>
        /// Gets available rooms
        /// </summary>
        /// <returns>Collection of available room DTOs</returns>
        Task<IEnumerable<RoomDto>> GetAvailableRoomsAsync();

        /// <summary>
        /// Creates a new room
        /// </summary>
        /// <param name="createRoomDto">Data for creating the room</param>
        /// <returns>Created room DTO</returns>
        Task<RoomDto> CreateRoomAsync(CreateRoomDto createRoomDto);

        /// <summary>
        /// Updates an existing room
        /// </summary>
        /// <param name="updateRoomDto">Data for updating the room</param>
        /// <returns>Updated room DTO if successful, otherwise null</returns>
        Task<RoomDto> UpdateRoomAsync(UpdateRoomDto updateRoomDto);

        /// <summary>
        /// Updates the status of a room
        /// </summary>
        /// <param name="id">Room ID</param>
        /// <param name="status">New room status</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> UpdateRoomStatusAsync(int id, RoomStatus status);

        /// <summary>
        /// Deletes a room
        /// </summary>
        /// <param name="id">Room ID</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> DeleteRoomAsync(int id);

        /// <summary>
        /// Checks if a room exists
        /// </summary>
        /// <param name="id">Room ID</param>
        /// <returns>True if the room exists, otherwise false</returns>
        Task<bool> RoomExistsAsync(int id);
    }
}
