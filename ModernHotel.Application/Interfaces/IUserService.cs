using System.Collections.Generic;
using System.Threading.Tasks;
using ModernHotel.Application.DTOs;
using ModernHotel.Core.Enums;

namespace ModernHotel.Application.Interfaces
{
    /// <summary>
    /// Interface for User service
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>Collection of user DTOs</returns>
        Task<IEnumerable<UserDto>> GetAllUsersAsync();

        /// <summary>
        /// Gets a user by ID
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User DTO if found, otherwise null</returns>
        Task<UserDto> GetUserByIdAsync(int id);

        /// <summary>
        /// Gets a user by username
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User DTO if found, otherwise null</returns>
        Task<UserDto> GetUserByUsernameAsync(string username);

        /// <summary>
        /// Gets a user by email
        /// </summary>
        /// <param name="email">Email address</param>
        /// <returns>User DTO if found, otherwise null</returns>
        Task<UserDto> GetUserByEmailAsync(string email);

        /// <summary>
        /// Gets users by role
        /// </summary>
        /// <param name="role">User role</param>
        /// <returns>Collection of user DTOs with the specified role</returns>
        Task<IEnumerable<UserDto>> GetUsersByRoleAsync(UserRole role);

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="createUserDto">Data for creating the user</param>
        /// <returns>Created user DTO</returns>
        Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);

        /// <summary>
        /// Updates an existing user
        /// </summary>
        /// <param name="updateUserDto">Data for updating the user</param>
        /// <returns>Updated user DTO if successful, otherwise null</returns>
        Task<UserDto> UpdateUserAsync(UpdateUserDto updateUserDto);

        /// <summary>
        /// Updates the role of a user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="role">New user role</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> UpdateUserRoleAsync(int id, UserRole role);

        /// <summary>
        /// Updates the active status of a user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="isActive">Active status</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> UpdateUserActiveStatusAsync(int id, bool isActive);

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>True if successful, otherwise false</returns>
        Task<bool> DeleteUserAsync(int id);

        /// <summary>
        /// Checks if a user exists
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>True if the user exists, otherwise false</returns>
        Task<bool> UserExistsAsync(int id);

        /// <summary>
        /// Checks if a username is already in use
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="excludeUserId">User ID to exclude from the check (for updates)</param>
        /// <returns>True if the username is already in use, otherwise false</returns>
        Task<bool> UsernameExistsAsync(string username, int? excludeUserId = null);

        /// <summary>
        /// Checks if an email is already in use
        /// </summary>
        /// <param name="email">Email address</param>
        /// <param name="excludeUserId">User ID to exclude from the check (for updates)</param>
        /// <returns>True if the email is already in use, otherwise false</returns>
        Task<bool> EmailExistsAsync(string email, int? excludeUserId = null);
    }
}
