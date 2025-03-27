using System.Threading.Tasks;
using ModernHotel.Application.DTOs;
using ModernHotel.Core.Entities;

namespace ModernHotel.Application.Interfaces
{
    /// <summary>
    /// Interface for authentication and authorization service
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Authenticates a user with the provided credentials
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>User DTO if authentication is successful, otherwise null</returns>
        Task<UserDto> AuthenticateAsync(string username, string password);

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="createUserDto">Data for creating the user</param>
        /// <returns>Created user DTO</returns>
        Task<UserDto> RegisterAsync(CreateUserDto createUserDto);

        /// <summary>
        /// Changes the password for a user
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="currentPassword">Current password</param>
        /// <param name="newPassword">New password</param>
        /// <returns>True if password change is successful, otherwise false</returns>
        Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);

        /// <summary>
        /// Resets the password for a user
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="newPassword">New password</param>
        /// <returns>True if password reset is successful, otherwise false</returns>
        Task<bool> ResetPasswordAsync(int userId, string newPassword);

        /// <summary>
        /// Checks if a user has a specific role
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="role">Role to check</param>
        /// <returns>True if the user has the specified role, otherwise false</returns>
        Task<bool> HasRoleAsync(int userId, string role);

        /// <summary>
        /// Checks if a user is authorized to perform a specific action
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="action">Action to check</param>
        /// <returns>True if the user is authorized, otherwise false</returns>
        Task<bool> IsAuthorizedAsync(int userId, string action);

        /// <summary>
        /// Gets the current user
        /// </summary>
        /// <returns>Current user DTO</returns>
        Task<UserDto> GetCurrentUserAsync();

        /// <summary>
        /// Sets the current user
        /// </summary>
        /// <param name="user">User to set as current</param>
        void SetCurrentUser(User user);

        /// <summary>
        /// Clears the current user
        /// </summary>
        void ClearCurrentUser();

        /// <summary>
        /// Hashes a password
        /// </summary>
        /// <param name="password">Password to hash</param>
        /// <param name="salt">Salt used for hashing (output)</param>
        /// <returns>Hashed password</returns>
        string HashPassword(string password, out string salt);

        /// <summary>
        /// Verifies a password against a hash
        /// </summary>
        /// <param name="password">Password to verify</param>
        /// <param name="hash">Hash to verify against</param>
        /// <param name="salt">Salt used for hashing</param>
        /// <returns>True if the password is valid, otherwise false</returns>
        bool VerifyPassword(string password, string hash, string salt);
    }
}
