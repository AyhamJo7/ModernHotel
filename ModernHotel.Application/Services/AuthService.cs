using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ModernHotel.Application.DTOs;
using ModernHotel.Application.Interfaces;
using ModernHotel.Core.Entities;
using ModernHotel.Core.Exceptions;
using ModernHotel.Core.Interfaces;

namespace ModernHotel.Application.Services
{
    /// <summary>
    /// Implementation of the authentication and authorization service
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private User _currentUser;

        /// <summary>
        /// Initializes a new instance of the AuthService class
        /// </summary>
        /// <param name="unitOfWork">Unit of work</param>
        /// <param name="mapper">AutoMapper instance</param>
        public AuthService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <inheritdoc/>
        public async Task<UserDto> AuthenticateAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new ArgumentException("Username and password are required");

            // Get user by username
            var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
                return null;

            // Verify password
            if (!VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // Check if user is active
            if (!user.IsActive)
                throw new AuthenticationException("User account is inactive");

            // Update last login date
            user.LastLoginDate = DateTime.Now;
            await _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            // Set current user
            _currentUser = user;

            return _mapper.Map<UserDto>(user);
        }

        /// <inheritdoc/>
        public async Task<UserDto> RegisterAsync(CreateUserDto createUserDto)
        {
            if (createUserDto == null)
                throw new ArgumentNullException(nameof(createUserDto));

            // Validate username and email
            if (await _unitOfWork.Users.ExistsAsync(u => u.Username == createUserDto.Username))
                throw new ValidationException($"Username '{createUserDto.Username}' is already taken");

            if (await _unitOfWork.Users.ExistsAsync(u => u.Email == createUserDto.Email))
                throw new ValidationException($"Email '{createUserDto.Email}' is already registered");

            // Create user entity
            var user = _mapper.Map<User>(createUserDto);

            // Hash password
            user.PasswordHash = HashPassword(createUserDto.Password, out string salt);
            user.PasswordSalt = salt;

            // Add user
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        /// <inheritdoc/>
        public async Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword))
                throw new ArgumentException("Current password and new password are required");

            // Get user
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                throw new EntityNotFoundException("User", userId);

            // Verify current password
            if (!VerifyPassword(currentPassword, user.PasswordHash, user.PasswordSalt))
                return false;

            // Hash new password
            user.PasswordHash = HashPassword(newPassword, out string salt);
            user.PasswordSalt = salt;
            user.UpdatedAt = DateTime.Now;

            // Update user
            await _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> ResetPasswordAsync(int userId, string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword))
                throw new ArgumentException("New password is required");

            // Get user
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                throw new EntityNotFoundException("User", userId);

            // Hash new password
            user.PasswordHash = HashPassword(newPassword, out string salt);
            user.PasswordSalt = salt;
            user.UpdatedAt = DateTime.Now;

            // Update user
            await _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> HasRoleAsync(int userId, string role)
        {
            // Get user
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                throw new EntityNotFoundException("User", userId);

            // Check role
            return user.Role.ToString() == role;
        }

        /// <inheritdoc/>
        public async Task<bool> IsAuthorizedAsync(int userId, string action)
        {
            // Get user
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                throw new EntityNotFoundException("User", userId);

            // Check if user is active
            if (!user.IsActive)
                return false;

            // Implement authorization logic based on user role and action
            // This is a simplified example, you may want to implement a more sophisticated authorization system
            switch (action)
            {
                case "ManageUsers":
                    return user.Role == Core.Enums.UserRole.Administrator;
                case "ManageRooms":
                    return user.Role == Core.Enums.UserRole.Administrator || user.Role == Core.Enums.UserRole.Manager;
                case "ManageBookings":
                    return user.Role == Core.Enums.UserRole.Administrator || user.Role == Core.Enums.UserRole.Manager || user.Role == Core.Enums.UserRole.Receptionist;
                case "ViewReports":
                    return user.Role == Core.Enums.UserRole.Administrator || user.Role == Core.Enums.UserRole.Manager;
                default:
                    return false;
            }
        }

        /// <inheritdoc/>
        public async Task<UserDto> GetCurrentUserAsync()
        {
            if (_currentUser == null)
                return null;

            // Get fresh user data from database
            var user = await _unitOfWork.Users.GetByIdAsync(_currentUser.Id);
            return _mapper.Map<UserDto>(user);
        }

        /// <inheritdoc/>
        public void SetCurrentUser(User user)
        {
            _currentUser = user ?? throw new ArgumentNullException(nameof(user));
        }

        /// <inheritdoc/>
        public void ClearCurrentUser()
        {
            _currentUser = null;
        }

        /// <inheritdoc/>
        public string HashPassword(string password, out string salt)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Password cannot be empty");

            // Generate a random salt
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] saltBytes = new byte[16];
                rng.GetBytes(saltBytes);
                salt = Convert.ToBase64String(saltBytes);
            }

            // Hash the password with the salt
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        /// <inheritdoc/>
        public bool VerifyPassword(string password, string hash, string salt)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hash) || string.IsNullOrEmpty(salt))
                return false;

            // Hash the password with the salt
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                string computedHash = Convert.ToBase64String(hashBytes);
                return computedHash == hash;
            }
        }
    }
}
