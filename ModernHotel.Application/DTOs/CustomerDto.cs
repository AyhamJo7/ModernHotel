using System;

namespace ModernHotel.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for Customer
    /// </summary>
    public class CustomerDto
    {
        /// <summary>
        /// ID of the customer
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First name of the customer
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the customer
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Full name of the customer
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";

        /// <summary>
        /// Email address of the customer
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone number of the customer
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Address of the customer
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// City of the customer
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Country of the customer
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Postal/Zip code of the customer
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// ID card or passport number of the customer
        /// </summary>
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Date of birth of the customer
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Date and time when the customer was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date and time when the customer was last updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
