using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ModernHotel.Application.DTOs;
using ModernHotel.Application.Interfaces;
using ModernHotel.Core.Entities;
using ModernHotel.Core.Enums;
using ModernHotel.Core.Interfaces;

namespace ModernHotel.Application.Services
{
    /// <summary>
    /// Implementation of the RoomType service
    /// </summary>
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the RoomTypeService class
        /// </summary>
        /// <param name="unitOfWork">Unit of work</param>
        /// <param name="mapper">AutoMapper instance</param>
        public RoomTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RoomTypeDto>> GetAllRoomTypesAsync()
        {
            var roomTypes = await _unitOfWork.RoomTypes.GetAllAsync();
            return _mapper.Map<IEnumerable<RoomTypeDto>>(roomTypes);
        }

        /// <inheritdoc/>
        public async Task<RoomTypeDto> GetRoomTypeByIdAsync(int id)
        {
            var roomType = await _unitOfWork.RoomTypes.GetByIdAsync(id);
            return _mapper.Map<RoomTypeDto>(roomType);
        }

        /// <inheritdoc/>
        public async Task<RoomTypeDto> CreateRoomTypeAsync(CreateRoomTypeDto createRoomTypeDto)
        {
            // Create room type entity
            var roomType = _mapper.Map<RoomType>(createRoomTypeDto);
            
            // Add room type
            await _unitOfWork.RoomTypes.AddAsync(roomType);
            await _unitOfWork.SaveChangesAsync();

            // Get created room type
            var createdRoomType = await _unitOfWork.RoomTypes.GetByIdAsync(roomType.Id);
            return _mapper.Map<RoomTypeDto>(createdRoomType);
        }

        /// <inheritdoc/>
        public async Task<RoomTypeDto> UpdateRoomTypeAsync(UpdateRoomTypeDto updateRoomTypeDto)
        {
            // Validate room type exists
            var roomTypeExists = await _unitOfWork.RoomTypes.ExistsAsync(rt => rt.Id == updateRoomTypeDto.Id);
            if (!roomTypeExists)
                return null;

            // Update room type
            var roomType = _mapper.Map<RoomType>(updateRoomTypeDto);
            await _unitOfWork.RoomTypes.UpdateAsync(roomType);
            await _unitOfWork.SaveChangesAsync();

            // Get updated room type
            var updatedRoomType = await _unitOfWork.RoomTypes.GetByIdAsync(roomType.Id);
            return _mapper.Map<RoomTypeDto>(updatedRoomType);
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteRoomTypeAsync(int id)
        {
            // Check if room type exists
            var roomTypeExists = await _unitOfWork.RoomTypes.ExistsAsync(rt => rt.Id == id);
            if (!roomTypeExists)
                return false;

            // Check if room type has rooms
            var hasRooms = await _unitOfWork.Rooms.ExistsAsync(r => r.RoomTypeId == id);
            if (hasRooms)
                throw new InvalidOperationException("Cannot delete room type with existing rooms");

            // Delete room type
            var result = await _unitOfWork.RoomTypes.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return result;
        }

        /// <inheritdoc/>
        public async Task<bool> RoomTypeExistsAsync(int id)
        {
            return await _unitOfWork.RoomTypes.ExistsAsync(rt => rt.Id == id);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RoomTypeDto>> GetRoomTypesWithAvailabilityAsync()
        {
            // Get all room types
            var roomTypes = await _unitOfWork.RoomTypes.GetAllAsync();
            var roomTypeDtos = _mapper.Map<List<RoomTypeDto>>(roomTypes);

            // Get all rooms
            var rooms = await _unitOfWork.Rooms.GetAllAsync();
            var roomsByType = rooms.GroupBy(r => r.RoomTypeId).ToDictionary(g => g.Key, g => g.ToList());

            // Calculate room counts for each room type
            foreach (var roomTypeDto in roomTypeDtos)
            {
                if (roomsByType.TryGetValue(roomTypeDto.Id, out var roomsOfType))
                {
                    roomTypeDto.RoomCount = roomsOfType.Count;
                    roomTypeDto.AvailableRoomCount = roomsOfType.Count(r => r.Status == RoomStatus.Available);
                }
                else
                {
                    roomTypeDto.RoomCount = 0;
                    roomTypeDto.AvailableRoomCount = 0;
                }
            }

            return roomTypeDtos;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RoomTypeDto>> GetAvailableRoomTypesAsync()
        {
            // Get all room types with availability information
            var roomTypesWithAvailability = await GetRoomTypesWithAvailabilityAsync();
            
            // Filter room types with available rooms
            return roomTypesWithAvailability.Where(rt => rt.AvailableRoomCount > 0);
        }
    }
}
