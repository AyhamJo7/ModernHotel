using System.Collections.Generic;
using System.Threading.Tasks;
using ModernHotel.Application.DTOs;

namespace ModernHotel.Application.Interfaces
{
    /// <summary>
    /// Interface for RoomType service
    /// </summary>
    public interface IRoomTypeService
    {
        /// <summary>
        /// Gets all room types
        /// </summary>
        /// <returns>Collection of room type DTOs</returns>
        Task<IEnumerable<RoomTypeDto>> GetAllRoomTypesAsync();

        /// <summary>
        /// Gets a room type by ID
        /// </summary>
        /// <param name="id">Room type ID</param>
        /// <returns>Room type DTO if found, otherwise null</returns>
        Task<RoomTypeDto> GetRoomTypeByIdAsync(int id);

        /// <summary>
        /// Creates a new room type
        /// </summary>
        /// <param name="createRoomTypeDto">Data for creating the room type</param>
        /// <returns>Created room type DTO</returns>
        Task<RoomTypeDto> CreateRoomTypeAsync(CreateRoomTypeDto createRoomTypeDto);

        /// <summary>
        /// Updates an existing room type
        /// </summary>
        /// <param name="updateRoomTypeDto">Data for updating the room type</param>
        /// <returns>Updated room type DTO if successful, otherwise null</returns>
        Task<RoomTypeDto> UpdateRoomTypeAsync(UpdateRoomTypeDto updateRoomTypeDto);

        /// <summary>
        /// Deletes a room type
        /// </summary>
        /// <param name="id">Room type ID</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> DeleteRoomTypeAsync(int id);

        /// <summary>
        /// Checks if a room type exists
        /// </summary>
        /// <param name="id">Room type ID</param>
        /// <returns>True if the room type exists, otherwise false</returns>
        Task<bool> RoomTypeExistsAsync(int id);

        /// <summary>
        /// Gets room types with availability information
        /// </summary>
        /// <returns>Collection of room type DTOs with availability information</returns>
        Task<IEnumerable<RoomTypeDto>> GetRoomTypesWithAvailabilityAsync();

        /// <summary>
        /// Gets available room types
        /// </summary>
        /// <returns>Collection of available room type DTOs</returns>
        Task<IEnumerable<RoomTypeDto>> GetAvailableRoomTypesAsync();
    }
}
