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
    /// Implementation of the Room service
    /// </summary>
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the RoomService class
        /// </summary>
        /// <param name="unitOfWork">Unit of work</param>
        /// <param name="mapper">AutoMapper instance</param>
        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RoomDto>> GetAllRoomsAsync()
        {
            var rooms = await _unitOfWork.Rooms.GetAllAsync();
            return _mapper.Map<IEnumerable<RoomDto>>(rooms);
        }

        /// <inheritdoc/>
        public async Task<RoomDto> GetRoomByIdAsync(int id)
        {
            var room = await _unitOfWork.Rooms.GetByIdAsync(id);
            return _mapper.Map<RoomDto>(room);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RoomDto>> GetRoomsByStatusAsync(RoomStatus status)
        {
            var rooms = await _unitOfWork.Rooms.GetAsync(r => r.Status == status);
            return _mapper.Map<IEnumerable<RoomDto>>(rooms);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RoomDto>> GetRoomsByRoomTypeAsync(int roomTypeId)
        {
            var rooms = await _unitOfWork.Rooms.GetAsync(r => r.RoomTypeId == roomTypeId);
            return _mapper.Map<IEnumerable<RoomDto>>(rooms);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RoomDto>> GetAvailableRoomsAsync()
        {
            var rooms = await _unitOfWork.Rooms.GetAsync(r => r.Status == RoomStatus.Available);
            return _mapper.Map<IEnumerable<RoomDto>>(rooms);
        }

        /// <inheritdoc/>
        public async Task<RoomDto> CreateRoomAsync(CreateRoomDto createRoomDto)
        {
            // Validate room type exists
            var roomTypeExists = await _unitOfWork.RoomTypes.ExistsAsync(rt => rt.Id == createRoomDto.RoomTypeId);
            if (!roomTypeExists)
                throw new ArgumentException($"Room type with ID {createRoomDto.RoomTypeId} does not exist");

            // Create room entity
            var room = _mapper.Map<Room>(createRoomDto);
            
            // Add room
            await _unitOfWork.Rooms.AddAsync(room);
            await _unitOfWork.SaveChangesAsync();

            // Get room with room type
            var createdRoom = await _unitOfWork.Rooms.GetByIdAsync(room.Id);
            return _mapper.Map<RoomDto>(createdRoom);
        }

        /// <inheritdoc/>
        public async Task<RoomDto> UpdateRoomAsync(UpdateRoomDto updateRoomDto)
        {
            // Validate room exists
            var roomExists = await _unitOfWork.Rooms.ExistsAsync(r => r.Id == updateRoomDto.Id);
            if (!roomExists)
                return null;

            // Validate room type exists
            var roomTypeExists = await _unitOfWork.RoomTypes.ExistsAsync(rt => rt.Id == updateRoomDto.RoomTypeId);
            if (!roomTypeExists)
                throw new ArgumentException($"Room type with ID {updateRoomDto.RoomTypeId} does not exist");

            // Update room
            var room = _mapper.Map<Room>(updateRoomDto);
            await _unitOfWork.Rooms.UpdateAsync(room);
            await _unitOfWork.SaveChangesAsync();

            // Get updated room
            var updatedRoom = await _unitOfWork.Rooms.GetByIdAsync(room.Id);
            return _mapper.Map<RoomDto>(updatedRoom);
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateRoomStatusAsync(int id, RoomStatus status)
        {
            // Get room
            var room = await _unitOfWork.Rooms.GetByIdAsync(id);
            if (room == null)
                return false;

            // Update status
            room.Status = status;
            await _unitOfWork.Rooms.UpdateAsync(room);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteRoomAsync(int id)
        {
            // Check if room exists
            var roomExists = await _unitOfWork.Rooms.ExistsAsync(r => r.Id == id);
            if (!roomExists)
                return false;

            // Check if room has bookings
            var hasBookings = await _unitOfWork.Bookings.ExistsAsync(b => b.RoomId == id);
            if (hasBookings)
                throw new InvalidOperationException("Cannot delete room with existing bookings");

            // Delete room
            var result = await _unitOfWork.Rooms.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return result;
        }

        /// <inheritdoc/>
        public async Task<bool> RoomExistsAsync(int id)
        {
            return await _unitOfWork.Rooms.ExistsAsync(r => r.Id == id);
        }
    }
}
