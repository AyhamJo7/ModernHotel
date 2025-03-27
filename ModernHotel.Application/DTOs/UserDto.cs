using System;
using ModernHotel.Core.Enums;

namespace ModernHotel.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for User
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// ID of the user
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Username for login
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Email address of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// First name of the user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Full name of the user
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";

        /// <summary>
        /// Phone number of the user
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Role of the user
        /// </summary>
        public UserRole Role { get; set; }

        /// <summary>
        /// Role of the user as a string
        /// </summary>
        public string RoleName => Role.ToString();

        /// <summary>
        /// Indicates if the user account is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Date and time when the user last logged in
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// Date and time when the user was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date and time when the user was last updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
