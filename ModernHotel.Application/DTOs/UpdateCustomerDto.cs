using System;
using System.ComponentModel.DataAnnotations;

namespace ModernHotel.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for updating an existing Customer
    /// </summary>
    public class UpdateCustomerDto
    {
        /// <summary>
        /// ID of the customer
        /// </summary>
        [Required(ErrorMessage = "Customer ID is required")]
        public int Id { get; set; }

        /// <summary>
        /// First name of the customer
        /// </summary>
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the customer
        /// </summary>
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; }

        /// <summary>
        /// Email address of the customer
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; }

        /// <summary>
        /// Phone number of the customer
        /// </summary>
        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Address of the customer
        /// </summary>
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        public string Address { get; set; }

        /// <summary>
        /// City of the customer
        /// </summary>
        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters")]
        public string City { get; set; }

        /// <summary>
        /// Country of the customer
        /// </summary>
        [StringLength(100, ErrorMessage = "Country cannot exceed 100 characters")]
        public string Country { get; set; }

        /// <summary>
        /// Postal/Zip code of the customer
        /// </summary>
        [StringLength(20, ErrorMessage = "Postal code cannot exceed 20 characters")]
        public string PostalCode { get; set; }

        /// <summary>
        /// ID card or passport number of the customer
        /// </summary>
        [Required(ErrorMessage = "Identification number is required")]
        [StringLength(50, ErrorMessage = "Identification number cannot exceed 50 characters")]
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Date of birth of the customer
        /// </summary>
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }
    }
}
